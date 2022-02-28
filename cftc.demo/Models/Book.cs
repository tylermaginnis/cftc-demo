using cftc.demo.DAL.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace cftc.demo.Models
{
    public class Book
    {
        [DataNames("Publisher")]
        public string Publisher { get; set; }
        [DataNames("Title")]
        public string Title { get; set; }
        [DataNames("AuthorLastName")]
        public string AuthorLastName { get; set; }
        [DataNames("AuthorFirstName")]
        public string AuthorFirstName { get; set; }
        [DataNames("Price")]
        public decimal Price { get; set; }
        [DataNames("PublicationYear")]
        public int PublicationDate { get; set; }
        [DataNames("PageCitationStart")]
        public int PageCitationStart { get; set; }
        [DataNames("PageCitationEnd")]
        public int PageCitationEnd { get; set; }
        [DataNames("Volume")]
        public int Volume { get; set; }
        [DataNames("URL")]
        public string URL { get; set; }


        // Modern Language Association
        public string citationMla => (AuthorLastName + ", " + AuthorFirstName + "." + "\"" + Title + "\"" + "<i>" + Publisher + "</i>, " + "vol. " + Volume.ToString() + ", " + PublicationDate.ToString() + ", " + "pp. " + PageCitationStart.ToString() + "-" + PageCitationEnd.ToString());
        // Chicago Manual of Style
        public string citationCms => (AuthorLastName + ", " + AuthorFirstName + ". " + PublicationDate.ToString() + ". \"" + Title + "\" <i>" + Publisher + "</i>, " + "no. " + Volume.ToString() + PublicationDate.ToString() + ": " + PageCitationStart.ToString() + "-" + PageCitationEnd.ToString() +". " + URL + ".");


    }

    public static class BookHelper 
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                tb.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }
    }

}
