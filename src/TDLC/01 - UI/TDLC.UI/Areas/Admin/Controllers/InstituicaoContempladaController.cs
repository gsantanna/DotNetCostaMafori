using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TDLC.UI.Areas.Admin.Controllers
{
    [Authorize]
    public class InstituicaoContempladaController : Controller
    {
        // GET: Admin/InstituicaoContemplada
        public ActionResult Index()
        {
            return View();
        }
    }
}