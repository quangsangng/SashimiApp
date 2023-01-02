using System;
using System.Collections.Generic;
using System.Text;

using SashimiApp.Models;
using SashimiApp.Repository;
using Firebase.Database;
using Xamarin.Essentials;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SashimiApp.Repository
{
    class QuizRepository
    {
        FirebaseClient firebaseClient = new FirebaseClient("https://sashimi-project-default-rtdb.asia-southeast1.firebasedatabase.app/");
        UserRepository userRepository = new UserRepository();


        public async Task<bool> TrueAnswers(string type)
        {
            // Hàm này sẽ tăng các biến tính điểm nếu chọn đáp án đúng
            string email = Preferences.Get("email", "").Replace(".", "_");
            List<SashimiUser> Users = await userRepository.GetAllUserInfo();
            if (type == "Nghĩa của từ")
            {
                Users[0].Task1_total = Users[0].Task1_total + 1;
                Users[0].Task1_correct = Users[0].Task1_correct + 1;
            }
            else if (type == "Điền vào chỗ trống")
            {
                Users[0].Task2_total = Users[0].Task2_total + 1;
                Users[0].Task2_correct = Users[0].Task2_correct + 1;
            }

            try
            {
                await firebaseClient.Child(email + "/UserInfo/data").PutAsync(JsonConvert.SerializeObject(Users[0]));
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> FalseAnswers(string type)
        {
            // Hàm này sẽ giảm các biến tính điểm nếu chọn đáp án sai
            string email = Preferences.Get("email", "").Replace(".", "_");
            List<SashimiUser> Users = await userRepository.GetAllUserInfo();
            if (type == "Nghĩa của từ")
            {
                Users[0].Task1_total = Users[0].Task1_total + 1;
                Users[0].Task1_correct = Users[0].Task1_correct - 1;
            }
            else if (type == "Điền vào chỗ trống")
            {
                Users[0].Task2_total = Users[0].Task2_total + 1;
                Users[0].Task2_correct = Users[0].Task2_correct - 1;
            }

            try
            {
                await firebaseClient.Child(email + "/UserInfo/data").PutAsync(JsonConvert.SerializeObject(Users[0]));
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
