using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WGwebapp.Models;

namespace WGwebapp.BusinessLogic
{
    public class WatchGuardMarsRover
    {
        public async Task<List<PhotoViewModel>> GetPhotos(DateTime date) 
        {
            List<PhotoViewModel> photoViewModels = new List<PhotoViewModel>();

            string sDate = date.ToString("yyyy-MM-dd");
            var jsonString = await GetJsonData("https://watchguardmarsrover.azurewebsites.net/api/photos/" + sDate);

            foreach (var item in jsonString)
            {
                var a = JsonConvert.DeserializeObject<PhotoViewModel>(item.ToString());
                photoViewModels.Add(a);
            }

            return photoViewModels;
        }
        private async Task<List<JObject>> GetJsonData(string url)
        {
            var message = "";

            var webReq = (HttpWebRequest)WebRequest.Create(url);
            using (WebResponse response = await webReq.GetResponseAsync())
            {
                Stream responseStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(responseStream, Encoding.UTF8);
                message = readStream.ReadToEnd();
            }

            JArray jsonArray = JArray.Parse(message);

            List<JObject> jObjects = new List<JObject>();

            foreach (var item in jsonArray)
            {
                var jsonData = JObject.Parse(item.ToString());
                jObjects.Add(jsonData);
            }
            

            return jObjects;
        }
    }

    
}
