using System;
using System.Collections.Generic;
using Firebase.Database;
using System.Text;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Projedeneme1
{
    public class kisiselkayitoldatabase
    {
        FirebaseClient firebaseclient = new FirebaseClient("YourFireBaseClient");

        public async Task< bool> Save(kisiselkayıtolgetset kayit)
        {
          var data =   await firebaseclient.Child(nameof(kisiselkayıtolgetset)).PostAsync(JsonConvert.SerializeObject(kayit));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }
        
    }
}
