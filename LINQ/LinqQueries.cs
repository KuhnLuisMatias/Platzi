using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LINQ
{
    public class LinqQueries
    {
        private List<Book> books = new List<Book>();

        public LinqQueries()
        {
            using (StreamReader reader = new StreamReader("books.json"))
            {
                string json = reader.ReadToEnd();
                this.books = JsonSerializer.Deserialize<List<Book>>(json,new JsonSerializerOptions() { PropertyNameCaseInsensitive = true});

            }
        }

        public IEnumerable<Book> ObtenerColeccion()
        {
            return this.books;
        }

        public IEnumerable<Book> LibrosOrdenadosPorFecha()
        {
            return books.OrderByDescending(p=>p.PublishedDate).Take(3);
        }

        public IEnumerable<Book> TercerCuatoLibroConMasDeCuatrocientasPaginas()
        {
            return books.Where(p=>p.PageCount >400 ).Take(4).ski;
        }
    }
}
