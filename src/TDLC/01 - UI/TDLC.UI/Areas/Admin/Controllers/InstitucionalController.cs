using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TDLC.Infra.Entities;
using TDLC.Infra.Repository;
using TDLC.UI.Areas.Admin.Models.ViewModels;

namespace TDLC.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class InstitucionalController : Controller
    {

        RepositoryInstitucional _Repo = new RepositoryInstitucional();
        Repository<Linguagem> _RepoLng = new RepositoryLinguagem();




        // GET: Admin/AreaAtuacao
        public ActionResult Index()
        {
            return View();
        }



        #region CRIAR 

        [HttpGet]
        public ActionResult Criar()
        {
            #region preparacao 
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            var strCaminhobase = Server.MapPath("~/Content/Uploads");

            //carrega os itens que podem ser pai (Todos os que não tem pai definido. TOPO)
            #endregion

            return View();

        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Criar(InstitucionalViewmodel model)
        {
            //ajusta o viewmodel 
            var cont0 = model.Conteudos[0].Conteudo;
            if (string.IsNullOrEmpty(cont0)) cont0 = "Sem conteúdo";

            //preenche o conteúdo em ingles 
            foreach( var c in model.Conteudos)
            {
                if( string.IsNullOrEmpty(c.Conteudo)) c.Conteudo = "Sem conteúdo";
            }

            


            #region preparacao 
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            var strCaminhobase = Server.MapPath("~/Content/Uploads");
            #endregion


            try
            {

                //faz upload dos arquivos 
                if (model.ArquivoEnviado != null && model.ArquivoEnviado.ContentLength > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var ext = model.ArquivoEnviado.FileName.Split('.').Last();
                    if (string.IsNullOrWhiteSpace(ext)) ext = ".jpeg";
                    //TODO: Colocar aqui uma verificação de extensões permitidas.
                    var strArqDest = string.Format("{0}.{1}", guid, ext);
                    var strDest = string.Format("{0}\\{1}", strCaminhobase, strArqDest);
                    model.ArquivoEnviado.SaveAs(strDest);
                    model.Arquivo = strArqDest;
                }

                var entidade = Mapper.Map<InstitucionalViewmodel, Institucional>(model);
                _Repo.Insert(entidade);
                return RedirectToAction("Index");

            } catch
            {
                return View(model);
            }
            

        }

        #endregion
        

        #region EDITAR

        [HttpGet]
        public ActionResult Editar(int id)
        {
            #region preparacao 
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            var strCaminhobase = Server.MapPath("~/Content/Uploads");
            //carrega os itens que podem ser pai (Todos os que não tem pai definido. TOPO)
            #endregion
            



            //carrrega o modelo 
            var entidade = _Repo.Find(id);
            var model = AutoMapper.Mapper.Map<Institucional, InstitucionalViewmodel>(entidade);
            return View(model);

        }





        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar( InstitucionalViewmodel model)
        {
            #region preparacao 
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            var strCaminhobase = Server.MapPath("~/Content/Uploads");
            #endregion




            //faz upload dos arquivos 
            if (model.ArquivoEnviado != null && model.ArquivoEnviado.ContentLength > 0)
            {
                //caso a foto já exista ele deleta a foto existnete para não manter lixo na base 
                if (System.IO.File.Exists(string.Format("{0}\\{1}", strCaminhobase, model.Arquivo  )))
                {
                    System.IO.File.Delete(string.Format("{0}\\{1}", strCaminhobase, model.Arquivo));
                }

                var guid = Guid.NewGuid().ToString();
                var ext = model.ArquivoEnviado.FileName.Split('.').Last();
                if (string.IsNullOrWhiteSpace(ext)) ext = ".jpeg";
                //TODO: Colocar aqui uma verificação de extensões permitidas.
                var strArqDest = string.Format("{0}.{1}", guid, ext);
                var strDest = string.Format("{0}\\{1}", strCaminhobase, strArqDest);
                model.ArquivoEnviado.SaveAs(strDest);
                model.Arquivo = strArqDest;
            }          


            //carrega a entidade
            var entidade = _Repo.Find(model.id_institucional);

            //atualiza as propriedades do modelo 
            entidade.Nome = model.Nome;
            entidade.Descricao = model.Descricao;
            entidade.Area = model.Area;
            entidade.Arquivo = model.Arquivo;
  
            
            foreach (var conteudo in model.Conteudos)
            {
                var conteudo_ent = entidade.Conteudos.First(f => f.id_conteudoinstitucional == conteudo.id_conteudoinstitucional);
                Mapper.Map(conteudo, conteudo_ent);
            }

            _Repo.Edit(entidade);
            return RedirectToAction("Index");
            
        }

        #endregion
   
          
        #region DELETAR 
        public JsonResult Deletar(int id)
        {
            //carrega a publicação do repositório
            var strCaminhobase = Server.MapPath("~/Content/Uploads");
            var entidade = _Repo.Find(id);
            if (entidade == null) throw new HttpException(404, "Area não encontrado");


            #region deletar_imagens 

            if (string.IsNullOrEmpty(entidade.Arquivo) && System.IO.File.Exists(string.Format("{0}//{1}", strCaminhobase, entidade.Arquivo)))
            {
                System.IO.File.Delete(string.Format("{0}//{1}", strCaminhobase, entidade.Arquivo));
            }

            #endregion

            //deleta as publicacoes

            _Repo.DeleteExp(entidade);
            _Repo.Save();
            return Json("Comando executado com sucesso. ID: " + id.ToString() + " deletada! ", JsonRequestBehavior.AllowGet);

        }
        #endregion
        
    





    }
}