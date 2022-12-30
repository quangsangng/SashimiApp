using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Firebase.Auth;
using Firebase.Database;
using Newtonsoft.Json;
using SashimiApp.Models;
using Xamarin.Essentials;

namespace SashimiApp.Repository
{
    public class UserRepository
    {
        string webAPIkey = "AIzaSyAjsceV2dnjizMuLw8254HNotpH0Y9a2ho";
        FirebaseAuthProvider authProvider;
        FirebaseClient firebaseClient = new FirebaseClient("https://sashimi-project-default-rtdb.asia-southeast1.firebasedatabase.app/");


        public UserRepository()
        {
            authProvider = new FirebaseAuthProvider(new FirebaseConfig(webAPIkey));
        }


        public async Task<bool> SaveUserInfor(SashimiUser user)
        {
            string clean_email = user.Email.Replace('.', '_'); // sang@gmail.com -> sang@gmail_com
            var data = await firebaseClient.Child(clean_email + "/UserInfo").PostAsync(JsonConvert.SerializeObject(user));
            if (!String.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void DisplayAlert(string v1, string v2, string v3)
        {
            throw new NotImplementedException();
        }

        public async Task<bool>Register(string email, string name, string birth, string password)
        {
            SashimiUser user = new SashimiUser();
            user.Email = email;
            user.Name = name;
            user.Birth = birth;

            var token = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password, name);
            if (!String.IsNullOrEmpty(token.FirebaseToken))
            {
                await SaveUserInfor(user);
                return true;
            }
            return false;
        }

        public async Task<string>Login(string email, string password)
        {
            var token = await authProvider.SignInWithEmailAndPasswordAsync(email, password);
            if (!String.IsNullOrEmpty(token.FirebaseToken))
            {
                Preferences.Set("email", email);
                return token.FirebaseToken;
                
            }
            return "";
        }

    }
}
