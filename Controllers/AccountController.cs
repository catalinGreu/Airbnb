using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Proyecto_AirBnb.Models;

using System.IO;
using System.Threading;

namespace Proyecto_AirBnb.Controllers
{
    public class AccountController : Controller
    {
        UsuarioController controlUsu = new UsuarioController();

        // GET: Account

        public ActionResult Registro(bool? id)
        {
            if (id == null) ViewBag.Anfitrion = false;
            else ViewBag.Anfitrion = id;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registro(RegistroViewModel model, bool? id) //el id me dice si será o no anfitrion
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
                        salt = controlUsu.GeneraID(20);
                    }
                    string hash = controlUsu.Hashea(salt, model.Password);

                    if (!controlUsu.ExisteEmail(model.Correo))//si no se repite Correo
                    {

                        //Construyo Usuario
                        if (id == null) { id = false; };
                        Usuario u = new Usuario { Id = salt, Nombre = model.Nombre, Apellido = model.Apellido, Correo = model.Correo, Hash = hash, Anfitrion = id, Nacimiento = model.Nacimiento };
                        controlUsu.MensajeBienvenida(u);
                        controlUsu.GrabaUser(u);
                        Session["usuario"] = u;
                        Session["mensajes"] = controlUsu.GetMensajes(u.Id);

                        //lo meto en la sesion para no mantenerlo a través de vistas y controladores.
                        Session["VistaAnuncios"] = id;

                        return RedirectToAction("CompletaRegistro", "Account");
                    }
                    else
                    {
                        ViewBag.Error = "Lo sentimos, ya existe un usuario con ese correo";
                    }
                }
                else
                {
                    ViewBag.Menor = "Lo sentimos, no puedes registrarte siendo menor de edad";
                }
            }
            return View(model);
        }
        public ActionResult CompletaRegistro()//el tempdata persiste entre controladores...
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
        public ActionResult Login(LoginViewModel model, bool? id)
        {
            if (id == null) { id = false; }
            if (ModelState.IsValid)
            {

                string elID = OperacionesBDController.GetIdByCorreo(model.Email);
                if (elID == null) //---> No existe ese correo
                {
                    ViewBag.ErrorUsuario = "El usuario no existe";
                    return View(model);
                }
                string hash = controlUsu.Hashea(elID, model.Password);


                if (controlUsu.ExisteUsuario(hash, model.Email))
                {
                    Usuario u = controlUsu.GetUserById(elID);
                    Session["mensajes"] = controlUsu.GetMensajes(elID);
                    Session["usuario"] = u;

                    if ((bool)id)
                    {
                        return RedirectToAction("NuevoAnuncio", "Anuncios");
                    }
                    return RedirectToAction("Index", "Inicio", new { usuario = u });
                }
                else
                {
                    ViewBag.ErrorUsuario = "Contraseña erronea";
                    return View(model);
                }
            }
            return View(model);
        }
        public ActionResult ForgotPass()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPass(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                string id = controlUsu.GetIdByCorreo(model.Email);
                if (id != null)
                {
                    string newPass = null;
                    while (newPass == null)
                    {
                        newPass = controlUsu.GeneraID(10);
                    }
                    string newHash = controlUsu.Hashea(id, newPass);
                    //update del hash
                    controlUsu.UpdateHash(id, newHash);

                    //mando correo con pass...
                    string asunto = "Recuperación de contraseña";
                    string texto = "Tu nueva contraseña es: " + newPass
                                   + ".\nAhora puedes entrar a tu perfil."
                                   + " Le recomendamos cambiarla para una mayor seguridad."
                                   + " \nPincha en el enlace para iniciar sesión."
                                   + "\n http://localhost:17204/Account/Login";
                    EmailController.MandarPass(model.Email, texto, asunto);

                    ViewBag.Mensaje = "Te hemos enviado un e-mail a tu correo con tu nueva contraseña.";
                    return View();

                }
                else
                {
                    ViewBag.ErrorMessage = "El usuario no existe";
                    return View(model);
                }

            }
            return View(model);
        }

        public ActionResult Desconectar()
        {
            Session["usuario"] = null;
            return RedirectToAction("Index", "Inicio");
        }

        public ActionResult Webcam() //--> subo from webcam
        {
            Usuario u = (Usuario)Session["usuario"];
            var stream = Request.InputStream;
            string dump;

            using (var reader = new StreamReader(stream))
                dump = reader.ReadToEnd();

            var path = Server.MapPath("/Content/Imagenes/Perfil/" + u.Id + ".jpg");//--> Nombre foto = ID user
            System.IO.File.WriteAllBytes(path, String_To_Bytes2(dump));

            Thread.Sleep(2000);//----> Para que le de tiempo a guardarla antes de redirigir

            Session["usuario"] = null;
            Usuario conFoto = controlUsu.SetNombreFoto(u.Id, u.Id + ".jpg"); //---> escribo en sesion Objeto actualizado
            Session["usuario"] = conFoto;

            if ((bool)Session["VistaAnuncios"] == true) //--> el BeginForm de Completa Anuncio apunta a Index...no chuta
            {
                return RedirectToAction("NuevoAnuncio", "Anuncios");
            }
            return RedirectToAction("Index", "Inicio", new { usuario = conFoto });
        }
        public ActionResult FileUpload(HttpPostedFileBase file) // ---> subo Upload
        {
            Usuario u = (Usuario)Session["usuario"];
            if (file != null)
            {
                string pic = System.IO.Path.GetFileName(file.FileName);
                string path = System.IO.Path.Combine(Server.MapPath("~/Content/Imagenes/Perfil"), pic);
                // file is uploaded ----> Aqui no llamo a la foto con el ID del User
                file.SaveAs(path);
                string queID = ((Usuario)Session["usuario"]).Id;
                Session["usuario"] = null;
                u = controlUsu.SetNombreFoto(queID, pic);
                Session["usuario"] = u;
            }

            if ((bool)Session["VistaAnuncios"] == true)
            {
                return RedirectToAction("NuevoAnuncio", "Anuncios");
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