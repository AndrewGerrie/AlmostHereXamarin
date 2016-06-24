using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace AlmostHereXamarin
{
    class HttpHelper
    {
        public static String makePostRequest(String Url,String postData)
        {
            var request = (HttpWebRequest)WebRequest.Create(Settings.API + Settings.getNewSessionPath);

            var data = Encoding.ASCII.GetBytes(postData);

            request.Method = "POST";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;

        }

        public static String makePutRequest(String Url, String putData)
        {
            Console.WriteLine("path" + Url);
            var request = (HttpWebRequest)WebRequest.Create(Url);

            var data = Encoding.ASCII.GetBytes(putData);

            request.Method = "PUT";
            request.ContentType = "application/json";
            request.ContentLength = data.Length;

            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            return responseString;

        }

    }
}
