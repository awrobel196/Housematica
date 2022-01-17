using AutoMapper;
using Housematica.Data.Data.CMS;
using Housematica.Intranet.Controllers;
using Housematica.Intranet.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Housematica.Intranet
{
    public class ProjectEditProfile : Profile
    {
        public ProjectEditProfile()
        {
            CreateMap<Projects, ProjectEditViewModel>()
                .ForMember(x=>x.OwnerPhone,p=>p.MapFrom(x=>x.ProjectsContact.OwnerPhone))
                .ForMember(x=>x.OwnerEmail,p=>p.MapFrom(x=>x.ProjectsContact.OwnerEmail))
                .ForMember(x=>x.OwnerAdress, p=>p.MapFrom(x=>x.ProjectsContact.OwnerAdress))
                .ForMember(x=>x.ContactPerson, p=>p.MapFrom(x=>x.ProjectsContact.ContactPerson));
        }
    }
}
