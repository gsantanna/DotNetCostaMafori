using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TDLC.UI.Areas.Admin.Controllers
{
    public class UtilityController : Controller
    {

        public JsonResult Upload()
        {

            if (Request.Files.Count != 1) throw new HttpException(500, "Arquivo não enviado ou enviado mais arquivos que o esperado");



            //salva o arquivo 

            //retorna a localização dele.
            var strCaminhobase = Server.MapPath("~/Content/Uploads/Custom");




            var guid = Guid.NewGuid().ToString();
            var ext = Request.Files[0].FileName.Split('.').Last();
            if (string.IsNullOrWhiteSpace(ext)) ext = ".jpeg";



            var strArqDest = string.Format("{0}.{1}", guid, ext);
            var strDest = string.Format("{0}\\{1}", strCaminhobase, strArqDest);
            Request.Files[0].SaveAs(strDest);

            //location
            return Json(new { location = string.Format("{0}/{1}",  Url.Content("~/Content/Uploads/Custom") , strArqDest) }, JsonRequestBehavior.AllowGet);

        }
    }
}