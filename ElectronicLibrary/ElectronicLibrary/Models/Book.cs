using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicLibrary.Models
{
    public class Book
    {
        /// <summary>
        /// ID книги
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название книги
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Автор книги
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Цена книги
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Количество книг в библиотеке
        /// </summary>
        public int InLibrary { get; set; }
        /// <summary>
        /// Количество книг на руках
        /// </summary>
        public int OnHand { get; set; }
    }
}