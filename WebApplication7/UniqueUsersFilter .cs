using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;
using System.Linq;

namespace WebApplication7
{
    public class UniqueUsersFilter : IActionFilter
    {
        private readonly string _logFilePath;

        public UniqueUsersFilter(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Отримуємо IP-адресу користувача
            var ipAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString();

            // Зчитуємо з файлу всі IP-адреси, які вже раніше здійснювали запити
            var existingIPs = File.ReadAllLines(_logFilePath);

            // Перевіряємо, чи ця IP-адреса є унікальною
            if (!existingIPs.Contains(ipAddress))
            {
                // Якщо так, додаємо її до файлу
                File.AppendAllText(_logFilePath, ipAddress + Environment.NewLine);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Тут можна виконати якісь дії після виконання дії, якщо потрібно
        }
    }
}
