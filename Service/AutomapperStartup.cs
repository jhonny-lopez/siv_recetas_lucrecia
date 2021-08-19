using AutoMapper;
using Domain.Events;
using Microsoft.AspNetCore.Builder;
using Service.Events.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class AutomapperStartup : Profile
    {
        public AutomapperStartup()
        {
            CreateMap<CreateEventModel, Event>()
                .ForMember(em => em.Duration, s => s.MapFrom(source => new TimeSpan(source.Hours, 0, 0)));
        }
    }
}
