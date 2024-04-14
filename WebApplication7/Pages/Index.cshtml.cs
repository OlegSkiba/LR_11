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
            // �������� IP-������ �����������
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            // ���� IP-������ �� � �������� � �� ������, �������� �� � ����
            if (!string.IsNullOrEmpty(ipAddress))
            {
                // ����������, �� ���� IP-������ ��� ���� �������� � ����
                var existingIPs = System.IO.File.ReadAllLines("unique_users.txt");
                if (!existingIPs.Contains(ipAddress))
                {
                    // ���� �� ����� ����������, ������ ���� IP-������ �� �����
                    System.IO.File.AppendAllText("unique_users.txt", ipAddress + Environment.NewLine);
                }
            }

            // �������� ��'� ������ 䳿 �� ��� �������
            var actionName = "OnGet";
            var currentTime = DateTime.UtcNow;

            // �������� ���������� ��� ������ ������ � ���� log.txt
            var logMessage = $"Action '{actionName}' executed at {currentTime}";
            System.IO.File.AppendAllText("log.txt", logMessage + Environment.NewLine);
        }
    }
}
