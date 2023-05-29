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
    internal class sirketkayitdatabase
    {

        FirebaseClient firebaseclient = new FirebaseClient("YourFireBaseClient");

        public async Task<bool> Save(sirketkayıtgetset kayit1)
        {
            var data = await firebaseclient.Child(nameof(sirketkayıtgetset)).PostAsync(JsonConvert.SerializeObject(kayit1));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }
    }
}
