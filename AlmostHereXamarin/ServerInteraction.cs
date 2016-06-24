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

        public static int getSessionId()
        {
            var postData = "{}";

            var res = HttpHelper.makePostRequest(Settings.API + Settings.getNewSessionPath, postData);
            Dictionary<string, string> values = JsonConvert.DeserializeObject<Dictionary<string, string>>(res);
            
            Console.WriteLine("DB id " + values["_id"]);
            // 2

 

            return 0;

        }

        internal static void updateRemoteLocation(double longitude, double latitude, double speed)
        {
        }


    }
         
    
}
