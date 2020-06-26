using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Users.Controllers
{
    public class UsersController : Controller
    {

        //[Route("/Users/Alejandrock")] 

        public IActionResult Index(double data) 
        {
            //ViewData["id"] = id; 
            var url = Url.RouteUrl("Alejandro", new { age = 30, name = "Alejandro" });
            return Redirect(url);
        }

        [HttpGet("[controller]/[action]", Name = "Alejandro")]

        public IActionResult Metodo(int code){

            var data = $"Codigo de estado {code} ";
            return View("Index", data);
        }


    }
}
