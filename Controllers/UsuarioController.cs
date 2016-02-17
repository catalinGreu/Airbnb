using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Proyecto_AirBnb.Models;
namespace Proyecto_AirBnb.Controllers
{
    public class UsuarioController : Controller
    {

        public string GeneraID(int length)
        {

            const string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789";
            var randNum = new Random();
            var chars = new char[length];
            var allowedCharCount = allowedChars.Length;
            try
            {
                for (var i = 0; i <= length - 1; i++)
                {
                    chars[i] = allowedChars[Convert.ToInt32((allowedCharCount) * randNum.NextDouble() - 1)];
                }

            }
            catch (IndexOutOfRangeException) //si salta excepcion devuelvo null y lo vuelvo a intentar
            {

                return null;
            }

            return new string(chars);
        }
        public string Hashea(string salt, string pass) //---> EL SALT ES EL ID
        {
            byte[] bytes = Encoding.Unicode.GetBytes(pass);
            byte[] src = Encoding.Unicode.GetBytes(salt);
            byte[] dst = new byte[src.Length + bytes.Length];
            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);
            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);

            return EncodePasswordMd5(Convert.ToBase64String(inArray));
        }
        public static string EncodePasswordMd5(string pass) //Encrypt using MD5    
        {
            Byte[] originalBytes;
            Byte[] encodedBytes;
            MD5 md5;
            //Instantiate MD5CryptoServiceProvider, get bytes for original password and compute hash (encoded password)    
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);

            //Convert encoded bytes back to a 'readable' string    
            return BitConverter.ToString(encodedBytes);
        }

        public void UpdateUser(Usuario actual)
        {
            OperacionesBDController.UpdateUser(actual);
        }

        #region "acceso a datos"
        public void MensajeBienvenida(Usuario u)
        {
            OperacionesBDController.MandarMensaje(u);
        }

        public void SetAnfitrion(string idUser)
        {
            OperacionesBDController.SetAnfitrion(idUser);

        }


        public void GrabaUser(Usuario u)
        {
            OperacionesBDController.GrabaUser(u);
        }

        public string GetIdByCorreo(string email)
        {

            return OperacionesBDController.GetIdByCorreo(email);

        }

        public int GetMensajes(string elID)
        {
            return OperacionesBDController.GetMensajes(elID);
        }

        public bool ExisteUsuario(string hash, string email)
        {
            return OperacionesBDController.ExisteUsuario(hash, email);

        }
        public Usuario GetUserById(string elID)
        {
            return OperacionesBDController.GetUserById(elID);
        }
        public Usuario SetNombreFoto(string id, string ruta)
        {
            return OperacionesBDController.SetNombreFoto(id, ruta);

        }
        public void UpdateHash(string id, string hash)
        {
            OperacionesBDController.UpdateHash(id, hash);

        }
        #endregion
    }
}