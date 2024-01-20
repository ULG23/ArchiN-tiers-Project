using System.Net.Mail;
using AutoMapper;
using JeBalance.DTOs;
using JeBalance.Entities;

namespace JeBalance;

public class JeBalanceApplicationAutoMapperProfile : Profile
{
    public JeBalanceApplicationAutoMapperProfile()
    {
        CreateMap<Entities.Denonciation, DenonciationDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Informateur, opt => opt.MapFrom(src => src.Informateur))
               .ForMember(dest => dest.Suspect, opt => opt.MapFrom(src => src.Suspect))
               .ForMember(dest => dest.Delit, opt => opt.MapFrom(src => src.Delit))
               .ForMember(dest => dest.PaysEvasion, opt => opt.MapFrom(src => src.PaysEvasion))
               .ForMember(dest => dest.Reponse, opt => opt.MapFrom(src => src.Reponse));

        // Mapping from DenonciationDTO to Denonciation
        CreateMap<DenonciationDTO, Entities.Denonciation>()
            .ForMember(dest => dest.Informateur, opt => opt.MapFrom(src => src.Informateur))
            .ForMember(dest => dest.Suspect, opt => opt.MapFrom(src => src.Suspect))
            .ForMember(dest => dest.Delit, opt => opt.MapFrom(src => src.Delit))
            .ForMember(dest => dest.PaysEvasion, opt => opt.MapFrom(src => src.PaysEvasion))
            .ForMember(dest => dest.Reponse, opt => opt.MapFrom(src => src.Reponse));


        // Suspect Mappings
        CreateMap<SuspectDTO, Suspect>()
            .ForMember(dest => dest.Accuse, opt => opt.MapFrom(src => src.Accuse))
            .ForMember(dest => dest.Denonciation, opt => opt.MapFrom(src => src.Denonciation));

        CreateMap<Suspect, SuspectDTO>()
            .ForMember(dest => dest.Accuse, opt => opt.MapFrom(src => src.Accuse))
            .ForMember(dest => dest.Denonciation, opt => opt.MapFrom(src => src.Denonciation));

        // Personne Mappings
        CreateMap<PersonneDTO, Personne>()
            .ForMember(dest => dest.Prenom, opt => opt.MapFrom(src => src.Prenom))
            .ForMember(dest => dest.Nom, opt => opt.MapFrom(src => src.Nom))
            .ForMember(dest => dest.Adresse, opt => opt.MapFrom(src => src.Adresse));

        CreateMap<Personne, PersonneDTO>()
            .ForMember(dest => dest.Prenom, opt => opt.MapFrom(src => src.Prenom))
            .ForMember(dest => dest.Nom, opt => opt.MapFrom(src => src.Nom))
            .ForMember(dest => dest.Adresse, opt => opt.MapFrom(src => src.Adresse));

        // Adressse Mappings
        CreateMap<AdresseDTO, Adresse>();
        CreateMap<Adresse, AdresseDTO>();

        // Response Mappings
        CreateMap<ReponseDTO, Reponse>();
        CreateMap<Reponse, ReponseDTO>();

        // Confirmation Mappings
        CreateMap<ConfirmationDTO, Confirmation>();
        CreateMap<Confirmation, ConfirmationDTO>();

    }
}
