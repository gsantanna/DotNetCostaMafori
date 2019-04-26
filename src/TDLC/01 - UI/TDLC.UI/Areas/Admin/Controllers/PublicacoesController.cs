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
using bie.mvc.datatables;

namespace TDLC.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class PublicacoesController : Controller
    {

        /* Repository<Publicacao>*/
        RepositoryPublicacao _Repo = new RepositoryPublicacao();
        Repository<TipoPublicacao> _RepoTp = new RepositoryTipoPublicacao();
        Repository<Linguagem> _RepoLng = new RepositoryLinguagem();

        public PublicacoesController()
        {

        }

        // GET: Admin/Publicacao
        public ActionResult Index()
        {
            return View();

        }

        #region CRIAR 

        [HttpGet]
        public ActionResult Criar(string tipo)
        {
            //cria o combo
            var _tipos = _RepoTp.QueryFast().ToArray();
            ViewBag.id_tipoPublicacao = new SelectList(_tipos, "id_tipoPublicacao", "Nome", tipo);

            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();

            //retorna a view
            return View();
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Criar(PublicacaoViewmodel model)
        {
            #region preparacao 
            //cria o combo
            var _tipos = _RepoTp.QueryFast().ToArray();
            ViewBag.id_tipoPublicacao = new SelectList(_tipos, "id_tipoPublicacao", "Nome");
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();

            var strCaminhobase = Server.MapPath("~/Content/Uploads");

            #endregion

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                //Faz upload dos arquivos
                //Para cada conteudopublicacao ( linguagem ) 
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

                            Type type = model.Conteudos[indice_conteudo].GetType();
                            PropertyInfo prop = type.GetProperty(campoDestino);
                            prop.SetValue(model.Conteudos[indice_conteudo], strArqDest, null);


                        }
                    }
                }

                //Mapeia o conteúdo principal
                Publicacao objEnt = Mapper.Map<PublicacaoViewmodel, Publicacao>(model);

                var mgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = mgr.FindById(User.Identity.GetUserId());



                //mapeia o arquivo PDF 
                if (model.ContemAnexo && model.ArquivoEnviado != null && model.ArquivoEnviado.ContentLength > 0)
                {
                    var guid = Guid.NewGuid().ToString();
                    var ext = model.ArquivoEnviado.FileName.Split('.').Last();
                    //TODO: Colocar aqui uma verificação de extensões permitidas.
                    var strArqDest = string.Format("{0}.{1}", guid, ext);
                    var strDest = string.Format("{0}\\{1}", strCaminhobase, strArqDest);
                    model.ArquivoEnviado.SaveAs(strDest);
                    objEnt.Arquivo = strArqDest;
                    objEnt.ContemAnexo = true;
                }
                else
                {
                    objEnt.Arquivo = null;
                    objEnt.ContemAnexo = false;
                }





                objEnt.ModificadoPor = currentUser.Nome;
                objEnt.Modificado = DateTime.Now;
                objEnt.CriadoPor = currentUser.Nome;
                objEnt.Criado = DateTime.Now;

                _Repo.Insert(objEnt);


                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("SALVAR", ex.Message);
                return View(model);
            }

        }


        #endregion

        #region Editar
        [HttpGet]
        public ActionResult Editar(int id)
        {
            //carrega o item a ser editado
            var ent = _Repo.Find(id);
            var model = Mapper.Map<Publicacao, PublicacaoViewmodel>(ent);

            #region preparacao

            //cria o combo
            var _tipos = _RepoTp.QueryFast().ToArray();
            ViewBag.tipos_publicacao = new SelectList(_tipos, "id_tipoPublicacao", "Nome", ent.id_tipopublicacao);
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            #endregion

            //retorna a view
            return View(model);
        }


        [HttpPost]
        public ActionResult Editar(PublicacaoViewmodel model)
        {

            #region PREPARACAO 
            var strCaminhobase = Server.MapPath("~/Content/Uploads");
            //cria o combo
            var _tipos = _RepoTp.QueryFast().ToArray();
            ViewBag.tipos_publicacao = new SelectList(_tipos, "id_tipoPublicacao", "Nome", model.id_tipopublicacao);
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            #endregion

            #region UPLOAD ARQUIVOS

            //Faz upload dos arquivos
            //Para cada conteudopublicacao ( linguagem ) 
            for (int indice_conteudo = 0; indice_conteudo < model.Conteudos.Count; indice_conteudo++)
            {
                for (int i = 1; i < 10; i++)
                {
                    //verifica se o arquivo foi submetido 
                    if (Request.Files.AllKeys.Contains("conteudos[" + indice_conteudo + "].Arquivo" + i.ToString())) //arquivo existe
                    {
                        var campoDestino = "Imagem" + i.ToString();
                        var atual = Convert.ToString(Util.GetPropValue(model.Conteudos[indice_conteudo], campoDestino));
                        var arquivo = Request.Files["conteudos[" + indice_conteudo + "].Arquivo" + i.ToString()];


                        if (arquivo.ContentLength <= 0) continue;

                        var guid = Guid.NewGuid().ToString();

                        var ext = arquivo.FileName.Split('.').Last();
                        if (string.IsNullOrWhiteSpace(ext)) ext = ".jpeg";

                        //TODO: Colocar aqui uma verificação de extensões permitidas.
                        var strArqDest = string.Format("{0}.{1}", guid, ext);
                        var strDest = string.Format("{0}\\{1}", strCaminhobase, strArqDest);

                        arquivo.SaveAs(strDest);

                        //caso haja arquivo já selecionado apaga o anterior (para não deixar orfãos)
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
            var entidade = _Repo.Find(model.id_publicacao);

            //recupera o login do usuario atual
            var mgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var currentUser = mgr.FindById(User.Identity.GetUserId());

            entidade.ModificadoPor = currentUser.Nome;
            entidade.Modificado = DateTime.Now;

            entidade.Destaque = model.Destaque;
            entidade.DestaqueTopo = model.DestaqueTopo;

            entidade.DataPublicacao = model.DataPublicacao;

            entidade.id_tipopublicacao = model.id_tipopublicacao;

            entidade.URL = model.URL;


            //TODO: Verificar porque o Automapper não está mapeando direito e remover esse mapeamento manual

            //Para cada conteúdo postado.
            foreach (ConteudoPublicacaoViewmodel conteudovm in model.Conteudos)
            {
                //encontra o conteudo na entidade 
                ConteudoPublicacao cont = entidade.Conteudos.First(f => f.id_conteudopublicacao == conteudovm.id_conteudopublicacao);
                cont.Titulo = conteudovm.Titulo;

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
                cont.Destaque_Titulo_Home_Corpo = conteudovm.Destaque_Titulo_Home_Corpo;
                cont.Destaque_Titulo_Home_Topo = conteudovm.Destaque_Titulo_Home_Topo;


            }






            //Caso o arquivo tenha sido modificado.
            //A string com o arquivo está preenchida e um arquivo foi subido

            //mapeia o arquivo PDF 
            if (model.ContemAnexo && model.ArquivoEnviado != null && model.ArquivoEnviado.ContentLength > 0)
            {
                var guid = Guid.NewGuid().ToString();
                var ext = model.ArquivoEnviado.FileName.Split('.').Last();
                //TODO: Colocar aqui uma verificação de extensões permitidas.
                var strArqDest = string.Format("{0}.{1}", guid, ext);
                var strDest = string.Format("{0}\\{1}", strCaminhobase, strArqDest);
                model.ArquivoEnviado.SaveAs(strDest);
                entidade.Arquivo = strArqDest;
                entidade.ContemAnexo = true;
            }
            else if (!model.ContemAnexo && !string.IsNullOrWhiteSpace(model.Arquivo)) //o usuário desmarcou a opção do anexo. Excluir o arquivo
            {
                var arqPDF = string.Format("{0}\\{1}", strCaminhobase, entidade.Arquivo);
                if (System.IO.File.Exists(arqPDF)) System.IO.File.Delete(arqPDF);

                entidade.ContemAnexo = false;
                entidade.Arquivo = null;
            } 

            _Repo.Edit(entidade);
            _Repo.Save();

            return RedirectToAction("Index");

        }


        #endregion

        #region DELETAR 
        public JsonResult Deletar(int id)
        {
            //carrega a publicação do repositório
            var strCaminhobase = Server.MapPath("~/Content/Uploads");
            var objPublicacao = _Repo.Find(id);
            if (objPublicacao == null) throw new HttpException(404, "Publicação não encontrada");


            #region deletar_imagens 

            foreach (var cont in objPublicacao.Conteudos)
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

            if (objPublicacao.ContemAnexo)
            {
                var arqPDF = string.Format("{0}\\{1}", strCaminhobase, objPublicacao.Arquivo);
                if (System.IO.File.Exists(arqPDF)) System.IO.File.Delete(arqPDF);
            }


            #endregion

            //deleta as publicacoes

            _Repo.DeleteExp(objPublicacao);


            _Repo.Save();

            //deleta o arquivo da publicação




            return Json("Comando executado com sucesso. Publicação ID: " + id.ToString() + " deletada! ", JsonRequestBehavior.AllowGet);

        }

        #endregion



        public JsonResult DataTable(bie.mvc.datatables.DTParameters param)
        {

            //  try
            // {


            List<String> columnSearch = new List<string>();

            foreach (var col in param.Columns)
            {
                columnSearch.Add(col.Search.Value);
            }

            // List<Customer> data = new ResultSet().GetResult(param.Search.Value, param.SortOrder, param.Start, param.Length, dtsource, columnSearch);
            //int count = new ResultSet().Count(param.Search.Value, dtsource, columnSearch);


            List<PublicacaoViewmodel> Dados = new List<PublicacaoViewmodel>();
            var _mdl = _Repo.Query(x => x.Conteudos).Where(x => x.Conteudos.Any(y => x.Titulo.Contains(param.Search.Value))).Skip(param.Start).Take(param.Length).ToList();
            Dados = Mapper.Map<IEnumerable<Publicacao>, IEnumerable<PublicacaoViewmodel>>(_mdl).ToList();





            DTResult<PublicacaoViewmodel> result = new DTResult<PublicacaoViewmodel>
            {
                draw = param.Draw,
                data = Dados,
                recordsFiltered = Dados.Count,
                recordsTotal = 999
            };
            return Json(result, JsonRequestBehavior.AllowGet);
            //}
            // catch (Exception ex)
            // {
            //    return Json(new { error = ex.Message }, JsonRequestBehavior.AllowGet);
            // }

        }



    }//controller
}//namespace