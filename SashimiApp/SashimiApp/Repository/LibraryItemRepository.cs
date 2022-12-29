using System;
using System.Collections.Generic;
using System.Text;
using Firebase.Database;
using System.Threading.Tasks;
using SashimiApp.Models;
using System.Linq;
using Newtonsoft.Json;

namespace SashimiApp.Repository
{
    class LibraryItemRepository
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://sashimi-project-default-rtdb.asia-southeast1.firebasedatabase.app/");
        

        public async Task<bool> SaveItem(LibraryItem item)
        {
            var data = await firebaseClient.Child("sang@gmail/Library").PostAsync(JsonConvert.SerializeObject(item));
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
            return (await firebaseClient.Child("sang@gmail.com").OnceAsync<LibraryItem>()).Select(item => new LibraryItem
            {
                Content = item.Object.Content,
                Explain = item.Object.Explain,
                Example_1 = item.Object.Example_1,
                Example_2 = item.Object.Example_2

            }).ToList();
        }
    }
}
