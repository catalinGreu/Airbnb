﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Proyecto_AirBnb.Models;
using System.IO;

namespace Proyecto_AirBnb.Controllers
{
    public class AccountController : Controller
    {
        UsuarioController controlUsu = new UsuarioController();
        // GET: Account
        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(RegistroViewModel model)
        {
            if (ModelState.IsValid)
            {
                int currentYear = DateTime.Now.Year;
                int nacimiento = model.Nacimiento.Year;
                int diferencia = currentYear - nacimiento;

                if (diferencia >= 18)
                {
                    string salt = null;
                    while (salt == null) // si me da null, lo llamo de nuevo
                    {
                        salt = controlUsu.GeneraID();
                    }
                    string hash = controlUsu.Hashea(salt, model.Password);

                    //Construyo Usuario
                    Usuario u = new Usuario { Id = salt, Nombre = model.Nombre, Apellido = model.Apellido, Correo = model.Correo, Hash = hash, Anfitrion = false, Nacimiento = model.Nacimiento };

                    controlUsu.GrabaUser(u);
                    Session["usuario"] = u;
                    return RedirectToAction("CompletaRegistro", "Account");
                }
                else
                {
                    ViewBag.Menor = "Lo sentimos, no puedes registrarte siendo menor de edad";
                }
            }


            return View(model);
        }
        public ActionResult CompletaRegistro()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model)
        {

            if (ModelState.IsValid)
            {

                string elID = controlUsu.GetIdByCorreo(model.Email);
                if (elID == null) //---> No existe ese correo
                {
                    ViewBag.ErrorUsuario = "El usuario no existe";
                    return View(model);
                }
                string hash = controlUsu.Hashea(elID, model.Password);

                if (controlUsu.ExisteUsuario(hash, model.Email))
                {
                    Usuario u = controlUsu.GetUserById(elID);
                    Session["usuario"] = u;
                    if ( CompruebaBirthday(u) ) ViewBag.Birthday = "IsBirthday";
                    return RedirectToAction("Index", "Inicio", new { usuario = u });
                }
            }
            return View(model);
        }
        public bool CompruebaBirthday(Usuario u)// creo que no chuta
        {
            int day = DateTime.Now.Day, day2 = u.Nacimiento.Value.Day;
            int mes = DateTime.Now.Month, mes2 = u.Nacimiento.Value.Month;
            if ( day == day2 && mes == mes2 )
            {
                return true;
            }
            return false;
        }

        public ActionResult Desconectar()
        {
            Session["usuario"] = null;
            return RedirectToAction("Index", "Inicio");
        }

        public ActionResult Webcam() //--> subo from webcam
        {
            string idUser = ((Usuario)Session["usuario"]).Id;
            var stream = Request.InputStream;
            string dump;

            using (var reader = new StreamReader(stream))
                dump = reader.ReadToEnd();

            var path = Server.MapPath("/Content/Imagenes/Perfil/"+idUser+".jpg");//--> Nombre foto = ID user
            System.IO.File.WriteAllBytes(path, String_To_Bytes2(dump));

            controlUsu.SetNombreFoto(idUser, idUser+".jpg");
            return RedirectToAction("Index", "Inicio");
        }
        public ActionResult FileUpload(HttpPostedFileBase file) // ---> subo Upload
        {
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine( Server.MapPath("~/Content/Imagenes/Perfil"), pic);
                // file is uploaded
                file.SaveAs(path);
                string queID = ((Usuario)Session["usuario"]).Id;
                controlUsu.SetNombreFoto(queID, pic);
            }
            return RedirectToAction("Index", "Inicio");
        }

        private byte[] String_To_Bytes2(string strInput)
        {
            int numBytes = (strInput.Length) / 2;
            byte[] bytes = new byte[numBytes];

            for (int x = 0; x < numBytes; ++x)
            {
                bytes[x] = Convert.ToByte(strInput.Substring(x * 2, 2), 16);
            }

            return bytes;
        }
    }
}