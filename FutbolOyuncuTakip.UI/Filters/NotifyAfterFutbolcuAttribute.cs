using FutbolOyuncuTakip.UI.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FutbolOyuncuTakip.UI.Filters
{
    public class NotifyAfterFutbolcuAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var futbolcu = context.HttpContext.Items["yeniFutbolcu"] as Futbolcu;

            if (futbolcu != null)
            {
                string logPath = "futbolcu_log.txt";
                string logMesaj = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {futbolcu.AdSoyad} ({futbolcu.Mevki}) futbolcu eklendi.";

                File.AppendAllText(logPath, logMesaj + Environment.NewLine);
            }

            base.OnActionExecuted(context);
        }
    }
}
