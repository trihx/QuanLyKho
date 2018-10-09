using AutoMapper;
using QuanLyKho.ModelDTO;
using QuanLyKho.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyKho.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to DTO
            CreateMap<HangHoa, HangHoaDTO>();
            CreateMap<NhomHangHoa, NhomHangHoaDTO>();

            //DTO to Domain
            CreateMap<HangHoaDTO, HangHoa>();
            CreateMap<NhomHangHoaDTO, NhomHangHoa>();
            
        }

    }
}