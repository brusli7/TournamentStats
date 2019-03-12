using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TournamentStatas.DataAccess;
using TournamentStatas.Models;

namespace TournamentStatas.Controllers
{
    public class SuperAdminController : Controller
    {

        // GET: Admin
        public ActionResult Index(bool? fromRegistry)
        {
            var model = new IsUsers();
            
            if (fromRegistry.HasValue)
            {
                model.FromRegister = fromRegistry.Value ;
            }
            else
            {
                model.FromRegister = false;
            }

            return View(model);
        }
      
    }
}