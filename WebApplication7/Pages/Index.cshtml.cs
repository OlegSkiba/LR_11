using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace WebApplication7.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Отримуємо IP-адресу користувача
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            // Якщо IP-адреса не є нульовою і не пустою, записуємо її в файл
            if (!string.IsNullOrEmpty(ipAddress))
            {
                // Перевіряємо, чи така IP-адреса вже була записана у файл
                var existingIPs = System.IO.File.ReadAllLines("unique_users.txt");
                if (!existingIPs.Contains(ipAddress))
                {
                    // Якщо це новий користувач, додаємо його IP-адресу до файлу
                    System.IO.File.AppendAllText("unique_users.txt", ipAddress + Environment.NewLine);
                }
            }

            // Отримуємо ім'я методу дії та час виклику
            var actionName = "OnGet";
            var currentTime = DateTime.UtcNow;

            // Записуємо інформацію про виклик методу у файл log.txt
            var logMessage = $"Action '{actionName}' executed at {currentTime}";
            System.IO.File.AppendAllText("log.txt", logMessage + Environment.NewLine);
        }
    }
}
