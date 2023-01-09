using System;
using System.Collections.Generic;
using System.Linq;
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
            string email = user.Email.Replace(".", "_");
            try
            {
                await firebaseClient.Child(email + "/UserInfo/data").PutAsync(JsonConvert.SerializeObject(user));
                return true;
            }
            catch
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
            user.Avatar = "user_png";
            

            // Reset những chỉ số của task 1 và task 2 khi vừa đăng kí tài khoản
            user.Task1_correct = 0;
            user.Task1_total = 0;
            user.Task2_correct = 0;
            user.Task2_total = 0;



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

        public string CleanImageUrl(string url)
        {
            url = url.Replace('.', '_').Replace("/", "<88>").Replace("#", "<99>");
            return url;
        }

        public string NormalizeImageUrl(string url)
        {
            url = url.Replace('_', '.').Replace("<88>", "/").Replace("<99>", "#");
            return url;
        }

        public async Task<List<SashimiUser>> GetAllUserInfo()
        {
            string email = Preferences.Get("email", "").Replace(".", "_");
            return (await firebaseClient.Child(email + "/UserInfo").OnceAsync<SashimiUser>()).Select(item => new SashimiUser
            {
                    Name = item.Object.Name,
                    Birth = item.Object.Birth,
                    Email = item.Object.Email,
                    Avatar = item.Object.Avatar,
                    Task1_correct = item.Object.Task1_correct,
                    Task2_correct = item.Object.Task2_correct,
                    Task1_total = item.Object.Task1_total,
                    Task2_total = item.Object.Task2_total
                }).ToList();
        }

    }
}
