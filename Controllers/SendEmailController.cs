using SendEmail.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Http;

namespace SendEmail.Controllers
{
    public class SendEmailController : ApiController
    {
        // POST api/example
        [HttpPost]
        public async Task<IHttpActionResult> Post(Email email)
        {
            try
            {
                // Configuración del cliente SMTP
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587, // Cambia el puerto según tu servidor SMTP
                    Credentials = new NetworkCredential("contactofreelanceryr@gmail.com", "zvlh dfhg lnvc lywi"),
                    EnableSsl = true
                };

                // Configuración del mensaje de correo
                var mailMessage = new MailMessage
                {
                    From = new MailAddress("yourEmail@example.com"),
                    Subject = email.Subject,
                    Body = email.Body,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(email.To);

                // Envío del correo
                await smtpClient.SendMailAsync(mailMessage);

                return Ok(email);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
