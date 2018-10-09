using QuanLyKho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace QuanLyKho.Controllers.api
{
    public class NhomHangHoaController : ApiController
    {
        private QLK_Context _db;
        public NhomHangHoaController()
        {
            _db = new QLK_Context();
        }
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
        }


        //GET /api/NhomHangHoa
        public IEnumerable<NhomHangHoa> GetAll(string query = null)
        {
            var nhomhanghoaQuery = _db.NhomHangHoa.Where(n => n._isLocked == false);

            if (!String.IsNullOrWhiteSpace(query))
                nhomhanghoaQuery = nhomhanghoaQuery
                    .Where(n => (n.MaNhomHangHoa.Contains(query) || n.TenNhomHangHoa.Contains(query)) );

            var nhomhanghoa = nhomhanghoaQuery.ToList();

            return nhomhanghoa;
        }

        //public object GetFind()
        //{
        //    return _db.NhomHangHoa
        //        .Where(n => n._isLocked == false)
        //        .Select(n => new { find = n.MaNhomHangHoa + " | " + n.TenNhomHangHoa, n.TenNhomHangHoa, n.MaNhomHangHoa,n._isLocked,n.Id })
        //        .ToList();
        //}




        //GET /api/NhomHangHoa/1
        public NhomHangHoa GetGroupProduct(int id)
        {
            var nhomhanghoa = _db.NhomHangHoa.SingleOrDefault(n => n.Id == id);

            if (nhomhanghoa == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return nhomhanghoa;
        }


        // POST /api/nhomhanghoa
        [HttpPost]
        
        public IHttpActionResult CreateGroupProduct(NhomHangHoa nhomhanghoa)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _db.NhomHangHoa.Add(nhomhanghoa);
            _db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + nhomhanghoa.Id), nhomhanghoa);
        }


        // PUT /api/nhomhanghoa/1
        [HttpPut]
        [Route("api/nhomhanghoa/{id}/{loai}")]
        public void UpdateGroupProduct(int id, int loai, NhomHangHoa nhomhanghoa)
        {

            var nhomInDb = _db.NhomHangHoa.SingleOrDefault(c => c.Id == id);

            if (nhomInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            if (loai == 1)
            {
                if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

           
            
                nhomInDb.MaNhomHangHoa = nhomhanghoa.MaNhomHangHoa;
                nhomInDb.TenNhomHangHoa = nhomhanghoa.TenNhomHangHoa;
            }
            else if (loai == 2)
            {
                nhomInDb._isLocked = true;
            }

            _db.SaveChanges();

        }


    }
}
