using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using RakietaLogikaBiznesowa.Models;

namespace RakietaLogikaBiznesowa.Controllers
{
    public class Rsa
    {

        //// //ONLY FOR DEBUG.
        //private void RsaInitializer()
        //{
        //    RSACryptoServiceProvider rsaInitializer = new RSACryptoServiceProvider(2048);

        //    var rsaModel = new rsa()
        //    {
        //        publicKey = rsaInitializer.ToXmlString(false),
        //        privateKey = rsaInitializer.ToXmlString(true)
        //    };

        //    db.Rsa.Add(rsaModel);
        //    db.SaveChanges();
        //}
        //////ONLY FOR DEBUG
        

        public static byte[] RsaEncrypt(string message, Model1 db)
        {
            var rsaServiceProvider = new RSACryptoServiceProvider(2048);
            var rsaFromDb = db.Rsa.FirstOrDefault(e => e.Id == 3);

            rsaServiceProvider.FromXmlString(rsaFromDb.publicKey);


            var buffer = System.Text.Encoding.UTF8.GetBytes(message);

            var cryptedBytes = rsaServiceProvider.Encrypt(buffer, false);


            return cryptedBytes;
        }


        public static string RsaDecrypt(byte[] message, Model1 db)
        {
            var rsaServiceProvider = new RSACryptoServiceProvider(2048);
            var rsaFromDb = db.Rsa.FirstOrDefault(e => e.Id == 3);

            rsaServiceProvider.FromXmlString(rsaFromDb.privateKey);

            var decryptedBytes = rsaServiceProvider.Decrypt(message, false);

            var decryptedString = System.Text.Encoding.UTF8.GetString(decryptedBytes);

            return decryptedString;

        }

    }
}