using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ElectronicLibrary.Models
{
    public class User
    {
        /// <summary>
        /// ID пользователя, первичный ключ
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// Имя пользователя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия пользователя
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Адрес пользователя
        /// </summary>
        public string Adress { get; set; }
        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Книга, которую пользователь купил
        /// </summary>
        public Book Book { get; set; }
        /// <summary>
        /// Дата покупки
        /// </summary>
        public DateTime Date { get; set; }
        /// <summary>
        /// Дата посещения
        /// </summary>
        public DateTime VisitDate { get; set; }
        /// <summary>
        /// Количество оставшихся зеленых
        /// </summary>
        public int Balance { get; set; }

        public int? BookId { get; set; }
    }
}