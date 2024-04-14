using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace WebApplication7
{
    public class LogActionFilter : IActionFilter
    {
        private readonly string _logFilePath;

        public LogActionFilter(string logFilePath)
        {
            _logFilePath = logFilePath;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Отримуємо ім'я методу дії та час початку виконання дії
            var actionName = context.ActionDescriptor.DisplayName;
            var currentTime = DateTime.UtcNow;

            // Записуємо інформацію у файл
            var logMessage = $"Action '{actionName}' executed at {currentTime}";
            File.AppendAllText(_logFilePath, logMessage + Environment.NewLine);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Тут можна виконати якісь дії після виконання методу дії, якщо потрібно
        }
    }
}
