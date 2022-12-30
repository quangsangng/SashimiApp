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
            var data = await firebaseClient.Child(email + "/Library").PostAsync(JsonConvert.SerializeObject(item));
            if (! String.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<LibraryItem>> GetLibraryItems()
        {
            string email = Preferences.Get("email", "").Replace(".", "_"); ;
            return (await firebaseClient.Child(email + "/Library").OnceAsync<LibraryItem>()).Select(item => new LibraryItem
            {
                Content = item.Object.Content,
                Explain = item.Object.Explain,
                Example_1 = item.Object.Example_1,
                Example_2 = item.Object.Example_2

            }).ToList();
        }
    }
}
