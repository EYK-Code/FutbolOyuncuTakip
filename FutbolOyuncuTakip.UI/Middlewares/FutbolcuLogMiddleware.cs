using FutbolOyuncuTakip.UI.Models;
using System.Text;

namespace FutbolOyuncuTakip.UI.Middlewares
{
    public class FutbolcuLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _logFolder;
        private readonly string _logFilePath;

        public FutbolcuLogMiddleware(RequestDelegate next)
        {
            _next = next;
            var root = Directory.GetCurrentDirectory();

            _logFolder = Path.Combine(root, "wwwroot", "logs");
            _logFilePath = Path.Combine(_logFolder, "futbolcu-middleware-log.txt");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);

            if (context.Items.ContainsKey("yeniFutbolcu") && context.Items["yeniFutbolcu"] is Futbolcu futbolcu)
            {
                if (!Directory.Exists(_logFolder))
                {
                    Directory.CreateDirectory(_logFolder);
                }

                var log = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {futbolcu.AdSoyad} ({futbolcu.Mevki}) → middleware ile loglandı.";
                await File.AppendAllTextAsync(_logFilePath, log + Environment.NewLine, Encoding.UTF8);
            }
        }
    }
}
