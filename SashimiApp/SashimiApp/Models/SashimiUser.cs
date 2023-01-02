using System;
using System.Collections.Generic;
using System.Text;

namespace SashimiApp.Models
{
    public class SashimiUser
    {
        /* 
        Một User gồm có
        Name: Từ khóa (kanji, từ vựng)
        Email: Giải thích nghĩa của từ đó
        Birth: Ví dụ sử dụng từ đó
        */
        public string Name { get; set; }
        public string Email { get; set; }
        public string Birth { get; set; }

        // Task 1 là phần nghĩa của từ
        public int Task1_correct { get; set; }
        public int Task1_total { get; set; }

        // Task 2 là phần điền vào chỗ trống
        public int Task2_correct { get; set; }
        public int Task2_total { get; set; }
    }
}
