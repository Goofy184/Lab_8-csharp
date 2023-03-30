using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8_csharp
{
    class Book : IComparable<Book>
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public int Year { get; set; }
        public int Pages { get; set; }
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("Price cannot be negative.");
                price = value;
            }
        }
        public Book() { }
        public Book(string title, string publisher, int year, int pages, decimal price)
        {
            Title = title;
            Publisher = publisher;
            Year = year;
            Pages = pages;
            Price = price;
        }
        public int CompareTo(Book other)
        {
            if (other == null) return 1;
            return Publisher.CompareTo(other.Publisher);
        }

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   Title == book.Title &&
                   Publisher == book.Publisher &&
                   Year == book.Year &&
                   Pages == book.Pages &&
                   Price == book.Price;
        }

        public override string ToString()
        {
            return ($"{Title}, {Publisher}, {Year}, {Pages}, {Price},\n");
        }

        public override int GetHashCode()
        {
            int hashCode = -560543539;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Publisher);
            hashCode = hashCode * -1521134295 + Year.GetHashCode();
            hashCode = hashCode * -1521134295 + Pages.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            return hashCode;
        }
    }
}