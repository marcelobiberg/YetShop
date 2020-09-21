using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Yet.Web.Controllers
{
    public class CestaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
