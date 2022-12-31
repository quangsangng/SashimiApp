using System;
using System.Collections.Generic;
using System.Text;

namespace SashimiApp.Models
{
    public class LibraryItem
    {
        /* 
            Một Library Item gồm có
            ID
            Content: Từ khóa (kanji, từ vựng)
            Explain: Giải thích nghĩa của từ đó
            Example: Ví dụ sử dụng từ đó
        */
        public string Content { get; set; }
        public string Explain { get; set; }
        public string Example_1 { get; set; }
        public string Example_2 { get; set; }
    }
}
