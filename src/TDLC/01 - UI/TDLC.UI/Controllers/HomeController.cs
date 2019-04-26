using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TDLC.Infra.Entities;
using TDLC.Infra.Repository;
using TDLC.UI.Areas.Admin.Models.ViewModels;
using TDLC.UI.Models;
using TDLC.UI.Utility;

namespace TDLC.UI.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {

        public ActionResult SetCulture(string c, string a, string co)
        {
            HttpContext.Session["cultura"] = c;
            return RedirectToAction(a, co, new { cultura = c });

        }


        Repository<Publicacao> _RepoPublicacao = new RepositoryPublicacao();
        Repository<Equipe> _RepoEquipe = new RepositoryEquipe();
        Repository<AreaAtuacao> _RepoAreaAtuacao = new RepositoryAreaAtuacao();


        #region HOME 

        public ActionResult Index(string cultura)
        {
            #region localization 
            //se a cultura veio preenchida atualiza a sessão para a cultura atual          
            if (cultura == "en_US" || cultura == "pt_BR")
            {
                HttpContext.Session["cultura"] = cultura;

            }
            else if (string.IsNullOrWhiteSpace(cultura) && string.IsNullOrWhiteSpace(Convert.ToString(Session["cultura"]))) //cultura não veio, carrega a cultura da sessão
            {
                HttpContext.Session["cultura"] = "pt_BR";
                cultura = "pt_BR";
            }
            else
            {
                cultura = Convert.ToString(Session["cultura"]);
            }
            #endregion

            ////carrega as publicações que serão exibidas na home  
            //HomeViewmodel vm = new HomeViewmodel();



            ////Pega 2 destaques superiores
            //var ent_destaquestop = _RepoPublicacao.AllIncluding(x => x.Conteudos).Where(f => f.DataPublicacao <= DateTime.Now && f.DestaqueTopo).OrderByDescending(f => f.DataPublicacao).Take(2).ToList();
            //List<ConteudoPublicacao> conteudos = new List<ConteudoPublicacao>();


            ////ent_destaquestop.ForEach(f => conteudos.AddRange(f.Conteudos.Where(g => g.Linguagem.Cultura == cultura)));
            //ent_destaquestop.ForEach(f => conteudos.Add(f.GetConteudo(cultura)));
            //vm.Destaques_topo = Mapper.Map<IEnumerable<ConteudoPublicacao>, IEnumerable<ConteudoPublicacaoViewmodel>>(conteudos).OrderByDescending(f => f.DataPublicacao).ToList();


            ////pega 3 destaques home 
            //var ent_destaqueshome = _RepoPublicacao.AllIncluding(x => x.Conteudos).Where(f => f.DataPublicacao <= DateTime.Now && f.Destaque).OrderByDescending(f => f.DataPublicacao).Take(3).ToList();

            //List<ConteudoPublicacao> conteudos_destaque = new List<ConteudoPublicacao>();

            //ent_destaqueshome.ForEach(f => conteudos_destaque.Add(f.GetConteudo(cultura)));



            //vm.Destaques_home = Mapper.Map<IEnumerable<ConteudoPublicacao>, IEnumerable<ConteudoPublicacaoViewmodel>>(conteudos_destaque).OrderByDescending(f => f.DataPublicacao).ToList();


            return View();
        }

        #endregion


        #region  Quem Somos
        public ActionResult QuemSomos(string cultura)
        {
            #region localization 
            //se a cultura veio preenchida atualiza a sessão para a cultura atual          
            if (cultura == "en_US" || cultura == "pt_BR")
            {
                HttpContext.Session["cultura"] = cultura;

            }
            else if (string.IsNullOrWhiteSpace(cultura) && string.IsNullOrWhiteSpace(Convert.ToString(Session["cultura"]))) //cultura não veio, carrega a cultura da sessão
            {
                HttpContext.Session["cultura"] = "pt_BR";
                cultura = "pt_BR";
            }
            else
            {
                cultura = Convert.ToString(Session["cultura"]);
            }
            #endregion

            return View();
        }
        #endregion


        public ActionResult ResponsabilidadeSocial(string cultura)
        {
            #region localization 
            //se a cultura veio preenchida atualiza a sessão para a cultura atual          
            if (cultura == "en_US" || cultura == "pt_BR")
            {
                HttpContext.Session["cultura"] = cultura;

            }
            else if (string.IsNullOrWhiteSpace(cultura) && string.IsNullOrWhiteSpace(Convert.ToString(Session["cultura"]))) //cultura não veio, carrega a cultura da sessão
            {
                HttpContext.Session["cultura"] = "pt_BR";
                cultura = "pt_BR";
            }
            else
            {
                cultura = Convert.ToString(Session["cultura"]);
            }
            #endregion

            return View();
        }

        public ActionResult Equipe(string cultura)
        {

            #region localization 
            //se a cultura veio preenchida atualiza a sessão para a cultura atual          
            if (cultura == "en_US" || cultura == "pt_BR")
            {
                HttpContext.Session["cultura"] = cultura;

            }
            else if (string.IsNullOrWhiteSpace(cultura) && string.IsNullOrWhiteSpace(Convert.ToString(Session["cultura"]))) //cultura não veio, carrega a cultura da sessão
            {
                HttpContext.Session["cultura"] = "pt_BR";
                cultura = "pt_BR";
            }
            else
            {
                cultura = Convert.ToString(Session["cultura"]);
            }
            #endregion



            var objEnt = _RepoEquipe.QueryFast().ToList();

            EquipeSiteViewmodel model = new EquipeSiteViewmodel
            {
                Advogados = Mapper.Map<IEnumerable<Equipe>, IEnumerable<EquipeViewmodel>>(objEnt.Where(x => x.Tipo == Tipo_Equipe.ADVOGADO)).OrderBy(x => x.Ordem).ThenBy(x => x.Nome).ToList(),
                Socios = Mapper.Map<IEnumerable<Equipe>, IEnumerable<EquipeViewmodel>>(objEnt.Where(x => x.Tipo == Tipo_Equipe.SOCIO)).ToList()
            };






            return View(model);


        }


        public ActionResult Atuacao(string cultura)
        {
            #region localization 
            //se a cultura veio preenchida atualiza a sessão para a cultura atual          
            if (cultura == "en_US" || cultura == "pt_BR")
            {
                HttpContext.Session["cultura"] = cultura;

            }
            else if (string.IsNullOrWhiteSpace(cultura) && string.IsNullOrWhiteSpace(Convert.ToString(Session["cultura"]))) //cultura não veio, carrega a cultura da sessão
            {
                HttpContext.Session["cultura"] = "pt_BR";
                cultura = "pt_BR";
            }
            else
            {
                cultura = Convert.ToString(Session["cultura"]);
            }
            #endregion



            var ent = _RepoAreaAtuacao.QueryFast().ToList();

            var model = new AreaAtuacaoSiteViewmodel
            {
                Areas = Mapper.Map<IEnumerable<AreaAtuacao>, IEnumerable<AreaAtuacaoViewmodel>>(ent).ToList()
            };

            return View(model);
        }

        public ActionResult AreaAtuacao(int id, string cultura)
        {
            #region localization 
            //se a cultura veio preenchida atualiza a sessão para a cultura atual          
            if (cultura == "en_US" || cultura == "pt_BR")
            {
                HttpContext.Session["cultura"] = cultura;

            }
            else if (string.IsNullOrWhiteSpace(cultura) && string.IsNullOrWhiteSpace(Convert.ToString(Session["cultura"]))) //cultura não veio, carrega a cultura da sessão
            {
                HttpContext.Session["cultura"] = "pt_BR";
                cultura = "pt_BR";
            }
            else
            {
                cultura = Convert.ToString(Session["cultura"]);
            }
            #endregion

            
            //carrega as areas de atuação com o pai igual o parametro 
            var ent = _RepoAreaAtuacao.FindAll(x => x.id_pai == id).ToList();

            var model = new AreaAtuacaoSiteViewmodel
            {
                Areas = Mapper.Map<IEnumerable<AreaAtuacao>, IEnumerable<AreaAtuacaoViewmodel>>(ent).ToList()
            };

            return View(model);            

        }




        #region Contato 
        [HttpGet]
        public ActionResult Contato()
        {
            return View();
        }
        #endregion

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Contato(ContatoFormViewmodel model)
        {
            ViewBag.Origem = "C";
            if (ModelState.IsValid)
            {

                var qtdEnvios = (int?)Session["qtd_envios"];
                if (qtdEnvios.HasValue)
                {
                    qtdEnvios++;

                    if (qtdEnvios > 5) throw new HttpException(403, "Você já enviou muitos emails hoje");
                }
                else
                {
                    qtdEnvios = 1;
                }

                Session["qtd_envios"] = qtdEnvios;

                StringBuilder strCorpo = new StringBuilder();
                strCorpo.AppendLine("<html><body>");
                strCorpo.AppendLine("<h3>Detalhes da mensagem</h3>");
                strCorpo.AppendLine("<hr><table border='1'>");
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Nome", model.Nome);
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Email", model.Email);
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Telefone", model.Telefone);
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Assunto", model.Assunto);
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Mensagem", model.Mensagem);
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1} ({2:dd/MM/yyyy HH:mm})</td></tr>", "IP", model.IP, model.DataHora);
                strCorpo.AppendLine("</table>");
                strCorpo.AppendLine("</body></html>");

                var m = new EmailSVC();
                m.SendAsync(
                    System.Configuration.ConfigurationManager.AppSettings["FALE_CONOSCO_DESTINO"]
                    , "Site", "Mensagem enviada através do fale conosco", strCorpo.ToString());
                //verifica se ele já enviou a quantidade máxima de items por sessão ( evitar DoS ) 


                ViewBag.status = "OK";
                
            }
            else
            {
                ViewBag.status = "FALHA";
                ViewBag.Mensagem = "Erro ao enviar a mensagem, tente novamente mais tarde";                
            }
            return View();

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult TrabalheConosco(TrabalheConoscoVidemodel model)
        {
            ViewBag.Origem = "T";

            if (ModelState.IsValid)
            {

                var qtdEnvios = (int?)Session["qtd_envios"];
                if (qtdEnvios.HasValue)
                {
                    qtdEnvios++;

                    if (qtdEnvios > 5) throw new HttpException(403, "Você já enviou muitos emails hoje");
                }
                else
                {
                    qtdEnvios = 1;
                }
                Session["qtd_envios"] = qtdEnvios;



                //verifica se veio algum anexo
                if (model.arquivo == null || model.arquivo.ContentLength > ((1024*1024)*10)  )
                {
                    ViewBag.status = "FALHA";
                    ViewBag.mensagem = "Arquivo com o currículo inválido ou muito grande. Tente anexar um arquivo de no máximo 1MB";
                    return View("contato");
                }

                //verifica se o arquivo tem um ext válida 
                var ext = model.arquivo.FileName.Split('.').Last();


                var arrExtPermitida = new[] { "rtf","doc", "docx","pdf" };
                if(!arrExtPermitida.Contains(ext))
                {
                    ViewBag.status = "FALHA";
                    ViewBag.mensagem = "Arquivo com o formato inválido. Os formatos válidos são: RTF, DOC/DOCX ou PDF";
                    return View("contato");
                }


                //salva o arquivo 
                var guid = Guid.NewGuid().ToString();     
                var strArqDest = string.Format("{0}.{1}", guid, ext);
                var strCaminhobase = Server.MapPath("~/Content/Uploads/curriculo");
                var strDest = string.Format("{0}\\{1}", strCaminhobase, strArqDest);
                model.arquivo.SaveAs(strDest);






                Session["qtd_envios"] = qtdEnvios;

                StringBuilder strCorpo = new StringBuilder();
                strCorpo.AppendLine("<html><body>");
                strCorpo.AppendLine("<h3>Detalhes da mensagem</h3>");
                strCorpo.AppendLine("<hr><table border='1'>");
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Nome", model.Nome);
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1}</td></tr>", "Email", model.Email);                           
                strCorpo.AppendFormat("<tr><td><strong>{0}</strong></td><td>{1} ({2:dd/MM/yyyy HH:mm})</td></tr>", "IP", model.IP, model.DataHora);
                strCorpo.AppendLine("</table>");

                strCorpo.AppendFormat("<a href='http://costamarfori.azurewebsites.net/content/uploads/curriculo/{0}'>Clique aqui para baixar o arquivo </a> <br/> caso não consiga acessar o link, copie e cole o link abaixo: <br/> http://costamarfori.azurewebsites.net/content/uploads/curriculo/{0} ", strArqDest);

                strCorpo.AppendLine("</body></html>");


                var m = new EmailSVC();
                m.SendAsync(
                    System.Configuration.ConfigurationManager.AppSettings["CURRICULO_DESTINO"]
                    , "Site", "Currículo enviado através do site", strCorpo.ToString());
                //verifica se ele já enviou a quantidade máxima de items por sessão ( evitar DoS ) 



                ViewBag.status = "OK";
            }
            else
            {
                ViewBag.status = "FALHA";
            }
            return View("contato");

        }





    }
}