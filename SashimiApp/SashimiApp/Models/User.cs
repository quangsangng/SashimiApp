using System;
using System.Collections.Generic;
using System.Text;

namespace SashimiApp.Models
{
    public class User
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

    }
}
