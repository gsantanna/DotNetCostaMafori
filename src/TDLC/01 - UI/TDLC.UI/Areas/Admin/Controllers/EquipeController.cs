using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TDLC.Infra.Entities;
using TDLC.Infra.Repository;
using TDLC.UI.Areas.Admin.Models.ViewModels;
using System.IO;
using TDLC.UI.Areas.Admin.Models.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TDLC.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class EquipeController : Controller
    {

        RepositoryEquipe _Repo = new RepositoryEquipe();
        Repository<Linguagem> _RepoLng = new RepositoryLinguagem();


        // GET: Admin/Equipe
        public ActionResult Index()
        {
            return View();

        }


        [HttpGet]
        public ActionResult Criar()
        {
            #region preparacao 
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            var strCaminhobase = Server.MapPath("~/Content/Uploads");
            #endregion
            return View();

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Criar(EquipeViewmodel model)
        {
            #region preparacao 
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            var strCaminhobase = Server.MapPath("~/Content/Uploads");
            #endregion


            //faz upload dos arquivos 
            if (model.ArqFotoDestaque != null &&   model.ArqFotoDestaque.ContentLength > 0)
            {
                var guid = Guid.NewGuid().ToString();
                var ext = model.ArqFotoDestaque.FileName.Split('.').Last();
                if (string.IsNullOrWhiteSpace(ext)) ext = ".jpeg";
                //TODO: Colocar aqui uma verificação de extensões permitidas.
                var strArqDest = string.Format("{0}.{1}", guid, ext);
                var strDest = string.Format("{0}\\{1}", strCaminhobase, strArqDest);
                model.ArqFotoDestaque.SaveAs(strDest);
                model.FotoDestaque = strArqDest;
            }

            if (model.ArqFotoPopup != null &&   model.ArqFotoPopup.ContentLength > 0)
            {
                var guid = Guid.NewGuid().ToString();
                var ext = model.ArqFotoPopup.FileName.Split('.').Last();
                if (string.IsNullOrWhiteSpace(ext)) ext = ".jpeg";
                //TODO: Colocar aqui uma verificação de extensões permitidas.
                var strArqDest = string.Format("{0}.{1}", guid, ext);
                var strDest = string.Format("{0}\\{1}", strCaminhobase, strArqDest);
                model.ArqFotoPopup.SaveAs(strDest);
                model.FotoPopup = strArqDest;
            }



            var entidade = Mapper.Map<EquipeViewmodel, Equipe>(model);
            _Repo.Insert(entidade);

            return RedirectToAction("Index");


        }





        [HttpGet]
        public ActionResult Editar(int id)
        {
            #region preparacao 
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            var strCaminhobase = Server.MapPath("~/Content/Uploads");
            #endregion

            //carrega o modelo
            var mdl = Mapper.Map<Equipe, EquipeViewmodel>(_Repo.Find(id));
            return View(mdl);

        }



        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Editar(EquipeViewmodel model)
        {
            #region preparacao 
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            var strCaminhobase = Server.MapPath("~/Content/Uploads");
            #endregion

            //faz upload dos arquivos 
            if (model.ArqFotoDestaque != null && model.ArqFotoDestaque.ContentLength > 0)
            {
                //caso a foto já exista ele deleta a foto existnete para não manter lixo na base 
                if (System.IO.File.Exists(string.Format("{0}\\{1}", strCaminhobase, model.FotoDestaque)))
                {
                    System.IO.File.Delete(string.Format("{0}\\{1}", strCaminhobase, model.FotoDestaque));
                }


                var guid = Guid.NewGuid().ToString();
                var ext = model.ArqFotoDestaque.FileName.Split('.').Last();
                if (string.IsNullOrWhiteSpace(ext)) ext = ".jpeg";
                //TODO: Colocar aqui uma verificação de extensões permitidas.
                var strArqDest = string.Format("{0}.{1}", guid, ext);
                var strDest = string.Format("{0}\\{1}", strCaminhobase, strArqDest);
                model.ArqFotoDestaque.SaveAs(strDest);
                model.FotoDestaque = strArqDest;
                
            }

            if (model.ArqFotoPopup != null && model.ArqFotoPopup.ContentLength > 0)
            {
                //caso a foto já exista ele deleta a foto existnete para não manter lixo na base 
                if (System.IO.File.Exists(string.Format("{0}\\{1}", strCaminhobase, model.FotoPopup)))
                {
                    System.IO.File.Delete(string.Format("{0}\\{1}", strCaminhobase, model.FotoPopup));
                }

                var guid = Guid.NewGuid().ToString();
                var ext = model.ArqFotoPopup.FileName.Split('.').Last();
                if (string.IsNullOrWhiteSpace(ext)) ext = ".jpeg";
                //TODO: Colocar aqui uma verificação de extensões permitidas.
                var strArqDest = string.Format("{0}.{1}", guid, ext);
                var strDest = string.Format("{0}\\{1}", strCaminhobase, strArqDest);
                model.ArqFotoPopup.SaveAs(strDest);
                model.FotoPopup = strArqDest;
            }


            //carrega a entidade
            var entidade = _Repo.Find(model.id_equipe);

            //atualiza as propriedades do modelo 

            entidade.Nome = model.Nome;
            entidade.Tipo = model.Tipo;
            entidade.FotoDestaque = model.FotoDestaque;
            entidade.FotoPopup = model.FotoPopup;
            entidade.Ordem = model.Ordem;
            entidade.Email = model.Email;

            foreach (var conteudo in model.Conteudos)
            {
                var conteudo_ent = entidade.Conteudos.First(f => f.id_conteudoequipe == conteudo.id_conteudoequipe);
                Mapper.Map(conteudo, conteudo_ent);
            }

            _Repo.Edit(entidade);


            return RedirectToAction("Index");


        }




        #region DELETAR 
        public JsonResult Deletar(int id)
        {
            //carrega a publicação do repositório
            var strCaminhobase = Server.MapPath("~/Content/Uploads");
            var objEquipe = _Repo.Find(id);
            if (objEquipe == null) throw new HttpException(404, "Funcionário não encontrado");


            #region deletar_imagens 

            if (string.IsNullOrEmpty(objEquipe.FotoDestaque) && System.IO.File.Exists(string.Format("{0}//{1}", strCaminhobase, objEquipe.FotoDestaque)))
            {
                System.IO.File.Delete(string.Format("{0}//{1}", strCaminhobase, objEquipe.FotoDestaque));
            }
            if (string.IsNullOrEmpty(objEquipe.FotoPopup) && System.IO.File.Exists(string.Format("{0}//{1}", strCaminhobase, objEquipe.FotoPopup)))
            {
                System.IO.File.Delete(string.Format("{0}//{1}", strCaminhobase, objEquipe.FotoPopup));
            }

            #endregion

            //deleta as publicacoes

            _Repo.DeleteExp(objEquipe);
            _Repo.Save();


            return Json("Comando executado com sucesso. Equipe ID: " + id.ToString() + " deletada! ", JsonRequestBehavior.AllowGet);

        }

        #endregion










        /*

        #region Criar 

              

        

       


        [HttpPost]
        public ActionResult Editar(EquipeViewmodel model)
        {

            #region PREPARACAO 
            var strCaminhobase = Server.MapPath("~/Content/Uploads");
            //cria o combo
            var _tipos = _RepoTp.QueryFast().ToArray();
            ViewBag.tipos_Equipe = new SelectList(_tipos, "id_tipoEquipe", "Nome", model.id_tipoEquipe);
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            #endregion

            #region UPLOAD ARQUIVOS

            //Faz upload dos arquivos
            //Para cada conteudoEquipe ( linguagem ) 
            for (int indice_conteudo = 0; indice_conteudo < model.Conteudos.Count; indice_conteudo++)
            {
                for (int i = 1; i < 10; i++)
                {
                    //verifica se o arquivo foi submetido 
                    if (Request.Files.AllKeys.Contains("conteudos[" + indice_conteudo + "].Arquivo" + i.ToString())) //arquivo existe
                    {

                        var arquivo = Request.Files["conteudos[" + indice_conteudo + "].Arquivo" + i.ToString()];

                        if (arquivo.ContentLength <= 0) continue;

                        var guid = Guid.NewGuid().ToString();

                        var ext = arquivo.FileName.Split('.').Last();
                        if (string.IsNullOrWhiteSpace(ext)) ext = ".jpeg";

                        //TODO: Colocar aqui uma verificação de extensões permitidas.
                        var strArqDest = string.Format("{0}.{1}", guid, ext);
                        var strDest = string.Format("{0}\\{1}", strCaminhobase, strArqDest);

                        arquivo.SaveAs(strDest);
                        var campoDestino = "Imagem" + i.ToString();

                        //caso haja arquivo já selecionado apaga o anterior (para não deixar orfãos)
                        var atual = Convert.ToString(Util.GetPropValue(model.Conteudos[indice_conteudo], campoDestino));
                        if (atual != null && !string.IsNullOrWhiteSpace(atual))
                        {
                            var arq = string.Format("{0}\\{1}", strCaminhobase, atual);
                            //deleta os arquivos 
                            if (System.IO.File.Exists(arq)) System.IO.File.Delete(arq);

                        }

                        Type type = model.Conteudos[indice_conteudo].GetType();
                        PropertyInfo prop = type.GetProperty(campoDestino);
                        prop.SetValue(model.Conteudos[indice_conteudo], strArqDest, null);


                    }
                }
            }


            #endregion
            
            //Atualiza a publicação
            var entidade = _Repo.Find(model.id_Equipe);

           //recupera o login do usuario atual
            var mgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = mgr.FindById(User.Identity.GetUserId());

            entidade.ModificadoPor = currentUser.Nome;
            entidade.Modificado = DateTime.Now;

            //Para cada conteúdo postado.
            foreach( ConteudoEquipeViewmodel conteudovm in model.Conteudos)
            {
                //encontra o conteudo na entidade 
                 ConteudoEquipe cont =  entidade.Conteudos.First(f => f.id_conteudoEquipe == conteudovm.id_conteudoEquipe);
                cont.Titulo = conteudovm.Titulo;
                cont.Subtitulo = conteudovm.Subtitulo;
                cont.Conteudo = conteudovm.Conteudo;
                cont.Imagem1 = conteudovm.Imagem1;
                cont.Imagem2 = conteudovm.Imagem2;
                cont.Imagem3 = conteudovm.Imagem3;
                cont.Imagem4 = conteudovm.Imagem4;
                cont.Imagem5 = conteudovm.Imagem5;
                cont.Imagem6 = conteudovm.Imagem6;
                cont.Imagem7 = conteudovm.Imagem7;
                cont.Imagem8 = conteudovm.Imagem8;
                cont.Imagem9 = conteudovm.Imagem9;
                cont.Imagem10 = conteudovm.Imagem10;
                cont.Destaque_Categoria = conteudovm.Destaque_Categoria;
                cont.Destaque_Texto = conteudovm.Destaque_Texto;
                cont.Destaque_Titulo = conteudovm.Destaque_Titulo;
            }
                        
            _Repo.Edit(entidade);
            _Repo.Save();

            return RedirectToAction("Index");

        }


        #endregion

        */

        /*

        #region DELETAR 
        public JsonResult Deletar(int id)
        {
            //carrega a publicação do repositório
            var strCaminhobase = Server.MapPath("~/Content/Uploads");
            var objEquipe = _Repo.Find(id);
            if (objEquipe == null) throw new HttpException(404, "Equipe não encontrada");


            #region deletar_imagens 

            foreach (var cont in objEquipe.Conteudos)
            {
                for (int i = 1; i < 10; i++)
                {
                    var arq = Convert.ToString(Util.GetPropValue(cont, "Imagem" + i.ToString()));

                    if (arq != null && !string.IsNullOrWhiteSpace(arq))
                    {
                        arq = string.Format("{0}\\{1}", strCaminhobase, arq);
                        //deleta os arquivos 
                        if (System.IO.File.Exists(arq)) System.IO.File.Delete(arq);
                    }
                }
            }
            #endregion

            //deleta as publicacoes

            _Repo.DeleteExp(objEquipe);
            _Repo.Save();


            return Json("Comando executado com sucesso. Publicação ID: " + id.ToString() + " deletada! ", JsonRequestBehavior.AllowGet);

        }

        #endregion
    */



    }//controller
}//namespace