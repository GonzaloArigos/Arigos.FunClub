using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FunClub.Controllers
{
    public class WhatsappController : Controller
    {
        [HttpPost]
        public void EnviarMensaje(string mensajewsp)
        {
#if !DEBUG
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
            }
            catch (SystemException se)
            {
                Console.WriteLine(se.Message);
            }
#endif
        }

    }
}