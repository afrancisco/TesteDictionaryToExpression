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
                //faça um filtro 
                {"Name", "João"},
                {"DateOfBirth", "14/08/2000"}
            };
          

            var dataSource = GetDataSource();

            // essa é a função que vc tem que fazer
            var searchExpression = GetFilterExpression<Contact>(searchTerms);

            // searchResult só pode conter contatos cujo o nome seja "João" e o telefone seja "3234-2343"
            var searchResult = dataSource.Where(searchExpression.Compile()).ToList();
            Console.WriteLine(searchResult.FirstOrDefault().Name);

        }

        private static List<Contact> GetDataSource()
        {
            ///popular o array
            List<Contact> contatos = new List<Contact>
            {
                new Contact() { Name = "João", DateOfBirth = new DateTime(2000, 01, 15) },
                new Contact() { Name = "João", DateOfBirth = new DateTime(2000, 01, 15) },
                new Contact() { Name = "João", DateOfBirth = new DateTime(2000, 08, 14) }
            };
            return contatos;
        }


        static public Expression<Func<T, bool>> GetFilterExpression<T>(Dictionary<string, string> searchTerms)
        {
            Expression finalExpression = null;
            var parameter = Expression.Parameter(typeof(T), "x");
            foreach (var statement in searchTerms)
            {

                var member = Expression.Property(parameter, statement.Key);
                var constant = Expression.Constant(Convert.ChangeType(statement.Value, typeof(Contact).GetProperty(statement.Key).PropertyType));
                Expression expression = null;
                expression = Expression.Equal(member, constant);
                if (finalExpression == null)
                { finalExpression = expression; }
                else
                { finalExpression = Expression.AndAlso(finalExpression, expression); }

            }
            return Expression.Lambda<Func<T, bool>>(finalExpression,parameter);
            
        }

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


