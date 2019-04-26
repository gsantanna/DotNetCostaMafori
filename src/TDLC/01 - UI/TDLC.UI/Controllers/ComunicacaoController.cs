using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TDLC.Infra;
using TDLC.Infra.Entities;
using TDLC.Infra.Repository;
using TDLC.UI.Areas.Admin.Models.ViewModels;
using TDLC.UI.Utility;

namespace TDLC.UI.Controllers
{
    public class ComunicacaoController : Controller
    {

        public ActionResult Noticias(string item)
        {
            string tipo = "noticias";

            
            ViewBag.Voltar = Url.Content("~/comunicacao/noticias");
            #region TIPO DE PUBLICAÇÃO 

            IRepository<TipoPublicacao> _rep = new RepositoryTipoPublicacao();
            var objTpRepositorio = _rep.Query().FirstOrDefault(f => f.Nome_Tipo.ToLower().Contains(tipo.ToLower()));
            if (objTpRepositorio == null) return new HttpStatusCodeResult(404);
            ViewBag.imgheader = ConteudoInstitucionalHelper.GetImage("NEWS_IMG_HEADER");
            ViewBag.Tipo = objTpRepositorio.Nome_Tipo.Split(',')[0];


            #endregion


            IRepository<Publicacao> _repPublicacao = new RepositoryPublicacao();


            //Exibir um item 
            if (!string.IsNullOrEmpty(item))
            {
                //carrega a publicação pelo ID 
                var publicacao = _repPublicacao.Query().First(f => f.URL.ToLower() == item.ToLower() || f.id_publicacao.ToString() == item);
                if (publicacao != null)
                {


                    publicacao.Conteudos = new List<ConteudoPublicacao> { publicacao.GetConteudo("pt_BR") };
                    var mdl = AutoMapper.Mapper.Map<Publicacao, PublicacaoViewmodel>(publicacao);
                    return View("Publicacao", mdl);
                }

            }


            //cria a viewmodel
            Models.PublicacoesSiteViewmodel model = new Models.PublicacoesSiteViewmodel();



            //carrega todas as publicações ( limite 30 por questão de performance) 
            var publicacoes = _repPublicacao.AllIncluding(x => x.Conteudos).Where(f => f.DataPublicacao <= DateTime.Now && f.id_tipopublicacao == objTpRepositorio.id_tipoPublicacao).OrderByDescending(o => o.DataPublicacao).ToList();

            //mantém somente os itens da linguagem atual 
            foreach (var publicacao in publicacoes)
            {
                publicacao.Conteudos = new List<ConteudoPublicacao> { publicacao.GetConteudo("pt_BR") };
            }

            model.Publicacoes = AutoMapper.Mapper.Map<IEnumerable<Publicacao>, IEnumerable<PublicacaoViewmodel>>(publicacoes).ToList();


            //SACA o mais novo item com destaque topo 
            model.Destaques = model.Publicacoes.OrderByDescending(f => f.DataPublicacao).Take(2).ToList();
            foreach (var dm in model.Destaques)
            {
                model.Publicacoes.Remove(dm);
            }


            //SACA as 3 mais reventes 
            model.DestaquesMedio = model.Publicacoes.OrderByDescending(f => f.DataPublicacao).Take(3).ToList();
            foreach (var dm in model.DestaquesMedio)
            {
                model.Publicacoes.Remove(dm);
            }

            return View(objTpRepositorio.Nome_Tipo.Split(',')[0], model);

        }

        public ActionResult Informativos(string item)
        {

            string tipo = "informativo";


            ViewBag.Voltar = Url.Content("~/comunicacao/informativos");
            #region TIPO DE PUBLICAÇÃO 

            IRepository<TipoPublicacao> _rep = new RepositoryTipoPublicacao();
            var objTpRepositorio = _rep.Query().FirstOrDefault(f => f.Nome_Tipo.ToLower().Contains(tipo.ToLower()));
            if (objTpRepositorio == null) return new HttpStatusCodeResult(404);
            ViewBag.imgheader = ConteudoInstitucionalHelper.GetImage("INFORMATIVO_IMG_HEADER");
            ViewBag.Tipo = objTpRepositorio.Nome_Tipo.Split(',')[0];


            #endregion


            IRepository<Publicacao> _repPublicacao = new RepositoryPublicacao();


            //Exibir um item 
            if (!string.IsNullOrEmpty(item))
            {
                //carrega a publicação pelo ID 
                var publicacao = _repPublicacao.Query().First(f => f.URL.ToLower() == item.ToLower() || f.id_publicacao.ToString() == item);


                if (publicacao != null)
                {
                    publicacao.Conteudos = new List<ConteudoPublicacao> { publicacao.GetConteudo("pt_BR") };
                    var mdl = AutoMapper.Mapper.Map<Publicacao, PublicacaoViewmodel>(publicacao);
                    return View("Publicacao", mdl);
                }

            }

            var publicacoes = _repPublicacao.QueryFast().Where(f => f.DataPublicacao <= DateTime.Now && f.id_tipopublicacao == objTpRepositorio.id_tipoPublicacao).OrderByDescending(o => o.DataPublicacao).ToList();

            var arrAnos = (from f in _repPublicacao.QueryFast()
                           where f.DataPublicacao <= DateTime.Now && f.id_tipopublicacao == objTpRepositorio.id_tipoPublicacao
                           select f.DataPublicacao.Year).Distinct().OrderBy(x => x).ToArray();

            ViewBag.Anos = arrAnos;
            ViewBag.Ano1 = arrAnos.LastOrDefault();

            return View("Informativo");


        }

        public ActionResult Artigos(string item)
        {

            string tipo = "artigo";


            ViewBag.Voltar = Url.Content("~/comunicacao/artigos");
            #region TIPO DE PUBLICAÇÃO 

            IRepository<TipoPublicacao> _rep = new RepositoryTipoPublicacao();
            var objTpRepositorio = _rep.Query().FirstOrDefault(f => f.Nome_Tipo.ToLower().Contains(tipo.ToLower()));
            if (objTpRepositorio == null) return new HttpStatusCodeResult(404);
            ViewBag.imgheader = ConteudoInstitucionalHelper.GetImage("ARTIGO_IMG_HEADER");
            ViewBag.Tipo = objTpRepositorio.Nome_Tipo.Split(',')[0];


            #endregion


            IRepository<Publicacao> _repPublicacao = new RepositoryPublicacao();


            //Exibir um item 
            if (!string.IsNullOrEmpty(item))
            {
                //carrega a publicação pelo ID 
                var publicacao = _repPublicacao.Query().First(f => f.URL.ToLower() == item.ToLower() || f.id_publicacao.ToString() == item);


                if (publicacao != null)
                {
                    publicacao.Conteudos = new List<ConteudoPublicacao> { publicacao.GetConteudo("pt_BR") };
                    var mdl = AutoMapper.Mapper.Map<Publicacao, PublicacaoViewmodel>(publicacao);
                    return View("Publicacao", mdl);
                }

            }

            var publicacoes = _repPublicacao.QueryFast().Where(f => f.DataPublicacao <= DateTime.Now && f.id_tipopublicacao == objTpRepositorio.id_tipoPublicacao).OrderByDescending(o => o.DataPublicacao).ToList();

            var arrAnos = (from f in _repPublicacao.QueryFast()
                           where f.DataPublicacao <= DateTime.Now && f.id_tipopublicacao == objTpRepositorio.id_tipoPublicacao
                           select f.DataPublicacao.Year).Distinct().OrderBy(x => x).ToArray();

            ViewBag.Anos = arrAnos;
            ViewBag.Ano1 = arrAnos.LastOrDefault();

            return View("Artigo");


        }

        public JsonResult2 PublicacoesAno(string tipo, int ano)
        {

            IRepository<Publicacao> _repPublicacao = new RepositoryPublicacao();


            var publicacoes = _repPublicacao.AllIncluding(x => x.Conteudos).Where(
                f => f.DataPublicacao <= DateTime.Now &&
                f.DataPublicacao.Year == ano &&
                f.TipoPublicacao.Nome_Tipo.ToLower().Contains(tipo.ToLower())
                ).OrderByDescending(o => o.DataPublicacao).ToList();


            JsonResult2 objRet = new JsonResult2();
            objRet.Data = AutoMapper.Mapper.Map<IEnumerable<Publicacao>, IEnumerable<PublicacaoViewmodel>>(publicacoes).ToList();

            return objRet;


        }

      
        public JsonResult Compartilhar(int id_publicacao, string de, string nome, string para)
        {

            var qtdEnvios = (int?)Session["qtd_envios"];
            if (qtdEnvios.HasValue)
            {
                qtdEnvios++;
                if (qtdEnvios > 5) return Json(new {error=true, Erro = "Você já enviou muitos e-mails hoje!" });
            }
            else
            {
                qtdEnvios = 1;
            }

            Session["qtd_envios"] = qtdEnvios;


            //carrega a publicacao 
            IRepository<Publicacao> _rep = new RepositoryPublicacao();
            var objPublicacao = _rep.Find(id_publicacao);
            if (objPublicacao == null) return Json(new {error=true, Erro = "A publicação não foi encontrada" });



            var strUrl = "";
            switch (objPublicacao.TipoPublicacao.Nome)
            {
                case "Notícia":
                    {
                        strUrl = Url.Action("Noticias", "Comunicacao", new { item= objPublicacao.URL }, protocol: Request.Url.Scheme);
                        break;
                    }
                case "Informativo":
                    {
                        strUrl = Url.Action("Informativos", "Comunicacao", new { item = objPublicacao.URL }, protocol: Request.Url.Scheme);
                        break;
                    }
                case "Artigo":
                    {
                        strUrl = Url.Action("Artigos", "Comunicacao", new { item = objPublicacao.URL }, protocol: Request.Url.Scheme);
                        break;
                    }

                default: break;
            }
            



            StringBuilder strCorpo = new StringBuilder();
            strCorpo.AppendLine("<html><body><p>");
            strCorpo.AppendFormat("Olá {0}:<br/>", para);
            strCorpo.AppendFormat("{0} ({1}) compartilhou o seguinte item com você: <br/>", nome, de);
            strCorpo.AppendFormat("<a href='{0}'>{1}</a>", strUrl, objPublicacao.Titulo);

            strCorpo.AppendLine("</p></body></html>");

            var m = new EmailSVC();
            m.SendAsync(
                para
                , "Site ", "Um item acaba de ser compartilhado com você!", strCorpo.ToString());
            //verifica se ele já enviou a quantidade máxima de items por sessão ( evitar DoS ) 


            return Json(new { error=false,mensagem = "O item foi compartilhado com sucesso! " });



        }

    }
}