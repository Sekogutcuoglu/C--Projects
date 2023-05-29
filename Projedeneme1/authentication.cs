using System;
using System.Collections.Generic;
using Firebase.Auth;
using System.Text;
using System.Threading.Tasks;

namespace Projedeneme1
{

    public class authentication
    {
        static string webAPIkey = "YourWebAPIkey";

        FirebaseAuthProvider authProvider;
        public authentication()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIkey));
        }
        public async Task<bool> Register(string email, string password, string username)
        {
            var token = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password, username);
            if (!string.IsNullOrEmpty(token.FirebaseToken))
            {
                return true;
            }
            return false;
        }

        public async Task<string>Login(string email,string password)
        {
            var token =  await authProvider.SignInWithEmailAndPasswordAsync(email.ToLower(), password);
            if (!string.IsNullOrEmpty( token.FirebaseToken))
            {
                return token.FirebaseToken;
            }
            return "";
        }
    }
}
