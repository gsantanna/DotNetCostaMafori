using AutoMapper;
using TDLC.Infra.Entities;
using TDLC.UI.Areas.Admin.Models.ViewModels;
using TDLC.UI.Models;

namespace TDLC.UI.Automapper
{
    public static class AutomapConfig
    {
        public static void Configure()
        {

            //  .ForMember(vm=>vm.IsUserMatch, m=>m.ResolveUsing<MatchingUserResolver>()));

            Mapper.Initialize(cfg =>
            {
                


                cfg.CreateMap<PublicacaoViewmodel, Publicacao>();
                cfg.CreateMap<Publicacao, PublicacaoViewmodel>()
                    .ForMember(o => o.Tipo, b => b.MapFrom(z => z.TipoPublicacao.Nome))
                    .ForMember(o => o.CaminhoImagemHeader, b => b.MapFrom(z => z.TipoPublicacao.CaminhoImagemHeader ));

                cfg.CreateMap<ConteudoPublicacao, ConteudoPublicacaoViewmodel>();
                cfg.CreateMap<ConteudoPublicacaoViewmodel, ConteudoPublicacao>();
                cfg.CreateMap<Publicacao, Publicacao>();
                cfg.CreateMap<PublicacaoApi, PublicacaoApiViewmodel>();


                cfg.CreateMap<Equipe, EquipeViewmodel>();
                cfg.CreateMap<EquipeViewmodel, Equipe>();


                cfg.CreateMap<ConteudoEquipe, ConteudoEquipeViewmodel>();
                cfg.CreateMap<ConteudoEquipeViewmodel, ConteudoEquipe>();
                //macete para o upload


                cfg.CreateMap<AreaAtuacao, AreaAtuacaoViewmodel>();
                cfg.CreateMap<AreaAtuacaoViewmodel, AreaAtuacao>();

                cfg.CreateMap<ConteudoAreaAtuacao, ConteudoAreaAtuacaoViewmodel>();
                cfg.CreateMap<ConteudoAreaAtuacaoViewmodel, ConteudoAreaAtuacao>();


                cfg.CreateMap<InstitucionalViewmodel, Institucional>();
                cfg.CreateMap<Institucional, InstitucionalViewmodel>();
                cfg.CreateMap<ConteudoInstitucional, ConteudoInstitucionalViewmodel>();
                cfg.CreateMap<ConteudoInstitucionalViewmodel, ConteudoInstitucional>();



            });
        }
    }

}

