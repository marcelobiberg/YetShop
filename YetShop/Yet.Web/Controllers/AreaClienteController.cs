using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Yet.Web.Controllers
{
    public class AreaClienteController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
