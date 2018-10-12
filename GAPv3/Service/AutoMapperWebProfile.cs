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
            CreateMap<ReportValue, ReportValueStatisticViewModel>();
            CreateMap<Report, ReportStatisticViewModel>();
            CreateMap<Report, ReportFormViewModel>();
            CreateMap<ReportValue, ReportValueFormViewModel>();
            CreateMap<Report, ReportDetailsViewModel>();
        }

        public static void Run()
        {
            AutoMapper.Mapper.Initialize(x => { x.AddProfile<AutoMapperWebProfile>(); });
        }
    }
}