using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //propriedades e valores que devem ser filtrados
            var searchTerms = new Dictionary<string, string>
            {
                {"Name", "João"},
                {"DateOfBirth", "14/08/2000"}
            };


            var dataSource = GetDataSource();

            foreach (var item in searchTerms)
            {
                Console.WriteLine(item.Key);
            }

            // essa é a função que vc tem que fazer
            //         var searchExpression = GetFilterExpression(searchTerms);

            // searchResult só pode conter contatos cujo o nome seja "João" e o telefone seja "3234-2343"
            //var searchResult = dataSource.Where(searchExpression).ToList();

        }

        private static object GetDataSource()
        {
            ///popular o array
            List<Contact> contatos = new List<Contact>();
            contatos.Add(new Contact() { Name = "João", DateOfBirth = new DateTime(2000, 01, 15) });
            contatos.Add(new Contact() { Name = "João", DateOfBirth = new DateTime(2000, 01, 15) });
            contatos.Add(new Contact() { Name = "João", DateOfBirth = new DateTime(2000, 01, 15) });
            return contatos;
        }

 //Expression<Func<T, bool>>

 //       GetFilterExpression<T>(Dictionary<string, string> searchTerms)
 //   {
 //       foreach (var item in searchTerms)
 //       {
 //         Console.WriteLine(  item.Key);
 //       }
 //       // the magic goes here.
 //   }
    }
    // essa é a função que vc tem que fazer

   
    public class Contact
    {

        public string Name { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Phone Phone { get; set; }


    }

    public class Phone
    {

        public string Number { get; set; }

    }
}


