using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Users.Areas.User.Controllers
{
    [Area("User")] 
    public class UserController : Controller
    {
        public IActionResult User() 
        { 
            return View();
        }
    }
}
