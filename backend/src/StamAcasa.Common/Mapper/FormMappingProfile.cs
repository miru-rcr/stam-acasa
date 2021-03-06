﻿using System.Text.Json;
using AutoMapper;
using StamAcasa.Common.DTO;
using StamAcasa.Common.Models;

namespace StamAcasa.Common.Mapper {
    public class FormMappingProfile : Profile {
        public FormMappingProfile() {
            CreateMap<FormInfo, Form>()
                .ForMember(dest => dest.Content,
                    o => o.MapFrom(src =>
                      JsonDocument.Parse(src.Content, new JsonDocumentOptions())
                        ));
        }
    }

    public class FormInfoMappingProfile : Profile {
        public FormInfoMappingProfile()
        {
            CreateMap<Form, FormInfo>()
            .ForMember(m => m.UserInfo, f => f.MapFrom(src => src.User))
            .ForMember(dest => dest.Content,
                o => o.MapFrom(src => JsonSerializer.Serialize(src.Content, new JsonSerializerOptions())));
        }
    }
}
