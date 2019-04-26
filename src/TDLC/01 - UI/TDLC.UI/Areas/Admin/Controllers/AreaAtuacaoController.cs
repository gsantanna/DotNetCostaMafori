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
    public class AreaAtuacaoController : Controller
    {

        RepositoryAreaAtuacao _Repo = new RepositoryAreaAtuacao();
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
            var PossiveisPais = _Repo.Query().Where(f => f.Pai == null).ToList();
            ViewBag.id_pai = new SelectList(PossiveisPais, "id_areatuacao", "Nome");
            #endregion

            return View();

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Criar(AreaAtuacaoViewmodel model)
        {
            #region preparacao 
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            var strCaminhobase = Server.MapPath("~/Content/Uploads");

            //carrega os itens que podem ser pai (Todos os que não tem pai definido. TOPO)
            var PossiveisPais = _Repo.Query().Where(f => f.Pai == null).ToList();
            ViewBag.id_pai = new SelectList(PossiveisPais, "id_areatuacao", "Nome");
            #endregion


            //faz upload dos arquivos 
            if (model.ArqImagem != null && model.ArqImagem.ContentLength > 0)
            {
                var guid = Guid.NewGuid().ToString();
                var ext = model.ArqImagem.FileName.Split('.').Last();
                if (string.IsNullOrWhiteSpace(ext)) ext = ".jpeg";
                //TODO: Colocar aqui uma verificação de extensões permitidas.
                var strArqDest = string.Format("{0}.{1}", guid, ext);
                var strDest = string.Format("{0}\\{1}", strCaminhobase, strArqDest);
                model.ArqImagem.SaveAs(strDest);
                model.Imagem = strArqDest;
            }

            var entidade = AutoMapper.Mapper.Map<AreaAtuacaoViewmodel, AreaAtuacao>(model);
            _Repo.Insert(entidade);
            return RedirectToAction("Index");


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
            var PossiveisPais = _Repo.Query().Where(f => f.Pai == null && f.id_areatuacao != id).ToList(); //impede ele de por ele mesmo como pai e gerar um loop infinito na bagaça
            ViewBag.PossiveisPais = new SelectList(PossiveisPais, "id_areatuacao", "Nome");
            #endregion



            //carrrega o modelo 
            var entidade = _Repo.Find(id);
            var model = AutoMapper.Mapper.Map<AreaAtuacao, AreaAtuacaoViewmodel>(entidade);
            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Editar( AreaAtuacaoViewmodel model)
        {
            #region preparacao 
            //dominio linguagens
            ViewBag.langs = _RepoLng.QueryFast().OrderByDescending(f => f.padrao).ToList();
            var strCaminhobase = Server.MapPath("~/Content/Uploads");
            //carrega os itens que podem ser pai (Todos os que não tem pai definido. TOPO)
            var PossiveisPais = _Repo.Query().Where(f => f.Pai == null && f.id_areatuacao != model.id_areatuacao).ToList(); //impede ele de por ele mesmo como pai e gerar um loop infinito na bagaça
            ViewBag.PossiveisPais = new SelectList(PossiveisPais, "id_areatuacao", "Nome");
            #endregion





            //faz upload dos arquivos 
            if (model.ArqImagem != null && model.ArqImagem.ContentLength > 0)
            {
                //caso a foto já exista ele deleta a foto existnete para não manter lixo na base 
                if (System.IO.File.Exists(string.Format("{0}\\{1}", strCaminhobase, model.Imagem )))
                {
                    System.IO.File.Delete(string.Format("{{0}}", strCaminhobase, model.Imagem));
                }

                var guid = Guid.NewGuid().ToString();
                var ext = model.ArqImagem.FileName.Split('.').Last();
                if (string.IsNullOrWhiteSpace(ext)) ext = ".jpeg";
                //TODO: Colocar aqui uma verificação de extensões permitidas.
                var strArqDest = string.Format("{0}.{1}", guid, ext);
                var strDest = string.Format("{0}\\{1}", strCaminhobase, strArqDest);
                model.ArqImagem.SaveAs(strDest);
                model.Imagem = strArqDest;
            }          


            //carrega a entidade
            var entidade = _Repo.Find(model.id_areatuacao);

            //atualiza as propriedades do modelo 
            entidade.Destaque = model.Destaque;
            entidade.Ordem = model.Ordem;
            entidade.Imagem = model.Imagem;
            entidade.id_pai = model.id_pai;
            
            foreach (var conteudo in model.Conteudos)
            {
                var conteudo_ent = entidade.Conteudos.First(f => f.id_conteudoareatuacao == conteudo.id_conteudoareatuacao);
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
            var objAreaAtuacao = _Repo.Find(id);
            if (objAreaAtuacao == null) throw new HttpException(404, "Area não encontrado");


            #region deletar_imagens 

            if (string.IsNullOrEmpty(objAreaAtuacao.Imagem) && System.IO.File.Exists(string.Format("{0}//{1}", strCaminhobase, objAreaAtuacao.Imagem)))
            {
                System.IO.File.Delete(string.Format("{0}//{1}", strCaminhobase, objAreaAtuacao.Imagem));
            }
            if (string.IsNullOrEmpty(objAreaAtuacao.Imagem) && System.IO.File.Exists(string.Format("{0}//{1}", strCaminhobase, objAreaAtuacao.Imagem)))
            {
                System.IO.File.Delete(string.Format("{0}//{1}", strCaminhobase, objAreaAtuacao.Imagem));
            }

            #endregion

            //deleta as publicacoes

            _Repo.DeleteExp(objAreaAtuacao);
            _Repo.Save();


            return Json("Comando executado com sucesso. AreaAtuacao ID: " + id.ToString() + " deletada! ", JsonRequestBehavior.AllowGet);

        }

        #endregion














    }
}