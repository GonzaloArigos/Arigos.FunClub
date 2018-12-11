using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;


namespace FunClub.Controllers
{
    public class WhatsappController : Controller
    {
        private FunClubEntities db = new FunClubEntities();
        [HttpPost]
        public void EnviarMensaje(string mensajewsp)
        {

            string yourId = "IB5axXPSa0m2C8d1tbmOMmdvbnphbG9hcmlnb3NfYXRfZ21haWxfZG90X2NvbQ==";
            string yourMobile = "+5491164077830";
            string yourMessage = mensajewsp;

            try
            {
                string url = "https://NiceApi.net/API";
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                request.Headers.Add("X-APIId", yourId);
                request.Headers.Add("X-APIMobile", yourMobile);
                using (StreamWriter streamOut = new StreamWriter(request.GetRequestStream()))
                {
                    streamOut.Write(yourMessage);
                }
                using (StreamReader streamIn = new StreamReader(request.GetResponse().GetResponseStream()))
                {
                    Console.WriteLine(streamIn.ReadToEnd());
                }

                db.Bitacoras.Add(new Bitacora()
                {
                    Descripcion = "Se  realizo un envío de WhatsApp",
                    FechaHora = DateTime.Now,
                    Modulo = "WhatappService",
                    UserId = User.Identity.Name
                }
      );

                db.SaveChanges();
            }
            catch (SystemException se)
            {
                Console.WriteLine(se.Message);
            }

        }

    }
}