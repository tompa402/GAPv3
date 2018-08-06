using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using GAPv3.Models;
using GAPv3.ViewModels;

namespace GAPv3.Service
{
    public class AutoMapperWebProfile : Profile
    {
        public AutoMapperWebProfile()
        {
            CreateMap<Report, ReportViewModel>();
        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(x => { x.AddProfile<AutoMapperWebProfile>(); });
        }
    }
}