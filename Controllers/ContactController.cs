using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MailKit.Net.Smtp;
using MimeKit;
using PolatPortfolio.Models;
using System.Threading.Tasks;

namespace PolatPortfolio.Controllers
{
    public class ContactController : Controller
    {
        private readonly SmtpSettings _smtp;
        public ContactController(IOptions<SmtpSettings> smtpOptions)
        {
            _smtp = smtpOptions.Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactForm model)
        {
            if (!ModelState.IsValid) return View(model);

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(model.Name, model.Email));
            message.To.Add(new MailboxAddress("Polat", _smtp.Username));
            message.Subject = "Web Sitesi Mesajı: " + model.Name;
            message.Body = new TextPart("plain") { Text = $"Gönderen: {model.Name}\nE-posta: {model.Email}\n\n{model.Message}" };

            using var client = new SmtpClient();
            await client.ConnectAsync(_smtp.Host, _smtp.Port, _smtp.UseSsl);
            // If the SMTP server requires authentication:
            if (!string.IsNullOrEmpty(_smtp.Username))
            {
                await client.AuthenticateAsync(_smtp.Username, _smtp.Password);
            }
            await client.SendAsync(message);
            await client.DisconnectAsync(true);

            ViewBag.Message = "Mesajınız gönderildi. Teşekkürler!";
            return View();
        }
    }
}
