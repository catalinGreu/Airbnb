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

        public string GeneraID()
        {
            const int length = 20;
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

        public void SetAnfitrion(string idUser)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                db.SetAnfitrion(idUser);
            }

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

        public void GrabaUser(Usuario u)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                db.GrabaUser(u);
            }
        }

        public string GetIdByCorreo(string email)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                return db.GetIdByCorreo(email);
            }

        }


        public bool ExisteUsuario(string hash, string email)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                return db.ExisteUsuario(hash, email);
            }

        }
        public Usuario GetUserById(string elID)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                return db.GetUserById(elID);
            }
        }
        public Usuario SetNombreFoto(string id, string ruta)
        {
            using (OperacionesBDController db = new OperacionesBDController())
            {
                return db.SetNombreFoto(id, ruta);
            }

        }
    }
}