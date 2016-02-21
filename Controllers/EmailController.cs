using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using Proyecto_AirBnb.Models;

namespace Proyecto_AirBnb.Controllers
{
    public class EmailController : Controller
    {
        private static string __from = "mercadonashop@outlook.es";
        private static string __host = "smtp-mail.outlook.com";
        private static SmtpClient __cliente;
        public static void Prepara()
        {

            __cliente = new SmtpClient();
            __cliente.DeliveryMethod = SmtpDeliveryMethod.Network;
            __cliente.UseDefaultCredentials = false;
            __cliente.Host = __host;
            __cliente.Port = 587;
            __cliente.Credentials = new NetworkCredential(__from, "mercadona_shopPr0yect");//passwd
            __cliente.EnableSsl = true;


        }

        public static void MandarPass(string to, string texto, string asunto)
        {
            Prepara();
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(__from);
                correo.To.Add(to);
                correo.Subject = asunto;
                correo.Body = texto;

                __cliente.Send(correo);
            }
            catch (Exception e)
            {
                e.ToString();
                return;
            }
        }
        public static void ConfirmaReserva(Usuario u, string asunto, string texto )
        {
            Prepara();
            try
            {
                MailMessage correo = new MailMessage();
                correo.From = new MailAddress(__from);
                correo.To.Add(u.Correo);
                correo.Subject = asunto;
                correo.Body = texto;
                correo.IsBodyHtml = true;

                __cliente.Send(correo);
            }
            catch (Exception e)
            {
                e.ToString();
                return;
            }

        }
    }

}