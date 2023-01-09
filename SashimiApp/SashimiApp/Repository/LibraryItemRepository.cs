using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using System.Threading.Tasks;
using SashimiApp.Models;
using System.Linq;
using Newtonsoft.Json;
using Xamarin.Essentials;


namespace SashimiApp.Repository
{
    class LibraryItemRepository
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://sashimi-project-default-rtdb.asia-southeast1.firebasedatabase.app/");
        

        public async Task<bool> SaveItem(LibraryItem item)
        {
            string email = Preferences.Get("email", "").Replace(".", "_");
            try
            {
                await firebaseClient.Child(email + "/Library/" + item.Content).PutAsync(JsonConvert.SerializeObject(item));
                return true;
            }
            catch
            {
                return false;

            }            
        }

        public async Task<bool> DeleteItem(string id)
        {
            string email = Preferences.Get("email", "").Replace(".", "_");
            try
            {
                await firebaseClient.Child(email + "/Library/" + id).DeleteAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<LibraryItem>> GetLibraryItems()
        {
            string email = Preferences.Get("email", "").Replace(".", "_"); 
            return (await firebaseClient.Child(email + "/Library").OnceAsync<LibraryItem>()).Select(item => new LibraryItem
            {
                Content = item.Object.Content,
                Explain = item.Object.Explain,
                Example_1 = item.Object.Example_1,
                Example_2 = item.Object.Example_2,
                Status = item.Object.Status

            }).ToList();
        }

        //public async Task<LibraryItem> GetById(string id)
        //{
        //    string email = Preferences.Get("email", "").Replace(".", "_");
        //    return (await firebaseClient.Child(nameof(LibraryItem) + "/" + id).OnceSingleAsync<LibraryItem>());
        //}

    }
}
