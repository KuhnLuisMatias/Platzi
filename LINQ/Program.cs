using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinqQueries queries = new LinqQueries();

            Imprimir(queries.LibrosOrdenadosPorFecha());


            Console.ReadLine();
        }

        

        static void Imprimir(IEnumerable<Book> books)
        {
            var formato = "{0,-60} {1,15} {2,15}\n";
            Console.WriteLine( formato,"Titulo", "Nro. Paginas", "Fecha de publicación");
            foreach(var item in books)
            {
                Console.WriteLine(formato,item.Title,item.PageCount,item.PublishedDate.ToShortDateString());
            }
        }
    }
}
