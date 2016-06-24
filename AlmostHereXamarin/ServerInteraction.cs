using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace AlmostHereXamarin
{
    class ServerInteraction
    {

        public static string getSessionId()
        {
            var postData = "{}";

            var res = HttpHelper.makePostRequest(Settings.API + Settings.getNewSessionPath, postData);
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(res);

            return values["_id"];

        }

        internal static void updateRemoteLocation(double longitude, double latitude, double speed, String SessionID)
        {

            Dictionary<string, string> location =
                new Dictionary<string, String>();

            location.Add("longitude", longitude.ToString());
            location.Add("latitude", latitude.ToString());
            location.Add("speed", speed.ToString());
            location.Add("_id", SessionID);

            string json = JsonConvert.SerializeObject(location);

            Console.WriteLine(json);

            HttpHelper.makePutRequest(Settings.API + Settings.getUpdatePath + SessionID, json);

        }


    }
         
    
}
