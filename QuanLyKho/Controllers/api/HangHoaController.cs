using AutoMapper;
using QuanLyKho.ModelDTO;
using QuanLyKho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;

namespace QuanLyKho.Controllers.api
{
    public class HangHoaController : ApiController
    {
        private QLK_Context _db;
        public HangHoaController()
        {
            _db = new QLK_Context();
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }

        //GET /api/hanghoa
        public IEnumerable<HangHoaDTO> GetAll()
        {
            return _db.HangHoa
                .Where(h => h._isLocked == false)
                .Include(h => h.NhomHangHoa)
                .ToList()
                .Select(Mapper.Map<HangHoa, HangHoaDTO>);
        }

        //public IEnumerable<HangHoa> GetAll()
        //{
        //    return _db.HangHoa
        //        .Include(h => h.NhomHangHoa)
        //        .Where(h => h._isLocked == false)
        //        .ToList();
        //}
        //GET /api/hanghoa/1

        //public HangHoa GetById(int id)
        //{
        //    var hanghoa = _db.HangHoa.SingleOrDefault(h => h.Id == id);

        //    if (hanghoa == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    return hanghoa;
        //}

        ////GET /api/hanghoa/1
        public HangHoaDTO GetById(int id)
        {
            var hanghoa = _db.HangHoa
                .Include(h => h.NhomHangHoa)
                .SingleOrDefault(h => h.Id == id);

            if (hanghoa == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<HangHoa, HangHoaDTO>(hanghoa);
        }

        //POST /api/hanghoa
        [HttpPost]
        public IHttpActionResult Create(HangHoaDTO hanghoaDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var hanghoa = Mapper.Map<HangHoaDTO, HangHoa>(hanghoaDTO);

            _db.HangHoa.Add(hanghoa);
            _db.SaveChanges();

            hanghoaDTO.Id = hanghoa.Id;

            return Created(new Uri(Request.RequestUri + "/" + hanghoaDTO.Id), hanghoaDTO);
        }


        ////PUT /api/hanghoa
        //public void UpdateHangHoa(int id, HangHoaDTO hanghoaDTO) {
        //    if (!ModelState.IsValid)
        //        throw new HttpResponseException(HttpStatusCode.BadRequest);

        //    var hanghoaInDb = _db.HangHoa.SingleOrDefault(h => h.Id == id);

        //    if (hanghoaInDb == null)
        //        throw new HttpResponseException(HttpStatusCode.NotFound);

        //    Mapper.Map<HangHoaDTO, HangHoa>(hanghoaDTO, hanghoaInDb);

        //    _db.SaveChanges();
            
        //}

        // PUT /api/hanghoa/1
        [HttpPut]
        [Route("api/hanghoa/{id}/{loai}")]
        public void UpdateProduct(int id, int loai, HangHoa hanghoa)
        {

            var hanghoaInDb = _db.HangHoa.SingleOrDefault(h => h.Id == id);

            if (hanghoaInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            if (loai == 1)
            {
                if (!ModelState.IsValid)
                    throw new HttpResponseException(HttpStatusCode.BadRequest);



                hanghoaInDb.MaHangHoa = hanghoa.MaHangHoa;
                hanghoaInDb.TenHangHoa = hanghoa.TenHangHoa;
                hanghoaInDb.NgayCapNhatCuoi = hanghoa.NgayCapNhatCuoi;
                hanghoaInDb.NhomHangHoaId = hanghoa.NhomHangHoaId;
            
            }
            else if (loai == 2)
            {
                hanghoaInDb._isLocked = true;
            }

            _db.SaveChanges();

        }
    }
}
