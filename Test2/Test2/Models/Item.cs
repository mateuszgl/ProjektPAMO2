using SQLite;
using System;

namespace Test2.Models
{
    public class Item
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
    }
}