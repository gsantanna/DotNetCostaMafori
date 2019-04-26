
using System;
using System.Collections.Generic;
using System.Data.Entity;
using TDLC.Infra.Entities;
using System.Linq;
namespace TDLC.Infra.Repository
{
    #region publicacao 
    public class RepositoryPublicacao : Repository<Publicacao>
    {
        public RepositoryPublicacao() { }
        public RepositoryPublicacao(DbContext Context) : base(Context) { }

        




        public  bool DeleteExp(Publicacao model)
        {
            //limpa os conteúdos 
            LimpaConteudo(model);
            this.Context.Entry<Publicacao>(model).State = EntityState.Detached;

            RepositoryPublicacao _repo = new RepositoryPublicacao();
            _repo.Delete(model.id_publicacao);
            return _repo.Save() > 0;
        }

        public void LimpaConteudo(Publicacao model)
        {
            Repository<ConteudoPublicacao> _repo = new RepositoryConteudoPublicacao();

            for (int i = 0; i < model.Conteudos.Count; i++)
            {
                this.Context.Entry<ConteudoPublicacao>(model.Conteudos[i]).State = EntityState.Detached;
                _repo.Delete(model.Conteudos[i].id_conteudopublicacao);
                _repo.Save();

            }
            this.Save();
            


        }


        public IEnumerable<PublicacaoApi> GetPublicacoesApi()
        {
            var strQuery = @"select p.id_publicacao,  p.Criado, p.Modificado, p.criadopor CriadoPor, p.modificadopor ModificadoPor, tp.nome Tipo, cp.titulo Titulo, p.publicacao DataPublicacao  from tb_publicacao p 
            inner join tb_conteudopublicacao cp on cp.id_publicacao=p.id_publicacao
            inner join tb_tipopublicacao tp on p.id_tipopublicacao=tp.id_tipopublicacao
            where id_linguagem=1 order by Modificado desc";

            return this.Context.Database.SqlQuery<PublicacaoApi>(strQuery).ToList();



        }




    }
    #endregion



    public class RepositoryConteudoPublicacao : Repository<ConteudoPublicacao>
    {
        public RepositoryConteudoPublicacao() { }
        public RepositoryConteudoPublicacao(DbContext Context) : base(Context) { }

    }






    }
