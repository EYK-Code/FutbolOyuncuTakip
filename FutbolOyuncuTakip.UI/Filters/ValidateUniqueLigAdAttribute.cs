using FutbolOyuncuTakip.UI.Context;
using FutbolOyuncuTakip.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FutbolOyuncuTakip.UI.Filters
{
    public class ValidateUniqueLigAdAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var db = (MyDbContext)context.HttpContext.RequestServices.GetService(typeof(MyDbContext));
            var lig = context.ActionArguments["lig"] as Lig;

            if (lig != null)
            {
                bool ayniAdVarMi = db.Lig.Any(l => l.Ad.ToLower() == lig.Ad.ToLower());

                if (ayniAdVarMi)
                {
                    var controller = context.Controller as Controller;

                    controller.ModelState.AddModelError("Ad", "Bu lig zaten mevcut");

                    context.Result = new ViewResult
                    {
                        ViewName = "Create",
                        ViewData = controller.ViewData
                    };
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
