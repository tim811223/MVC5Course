using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class BaseController : Controller
    {
        protected ProductRepository repo = RepositoryHelper.GetProductRepository();

        protected override void HandleUnknownAction(string actionName)
        {
            this.Redirect("/").ExecuteResult(this.ControllerContext);
            // base.HandleUnknownAction(actionName);
        }
    }
}