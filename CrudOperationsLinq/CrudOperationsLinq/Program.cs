using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CrudOperationsLinq
{
    public class Program
    {
        public static Product createProduct()
        {
            Console.WriteLine("enter product_id:");
            int id = int.Parse(Console.ReadLine());

            List<Category> tmpCategory=Category.createCategoryList();
            Product pr = new Product(id, tmpCategory);
            return pr;
        }
        static void Main(string[] args)
        {
            string userInput;
            do
            {
                Console.WriteLine("======Menu=====");
                Console.WriteLine("1.Insert one product:");
                Console.WriteLine("2.Find product details by Id");
                Console.WriteLine("3.Get all products:");
                Console.WriteLine("4.Get product type by location: ");
                Console.WriteLine("5.Updating product with PID:");
                Console.WriteLine("6.Deleting document with PID:");

                int input = Convert.ToInt32(Console.ReadLine());

                FunctionMethod myfun = new FunctionMethod();
                myfun.Menu(input);

                Console.WriteLine("want to continue? press y/Y..");
                userInput = Console.ReadLine();

            } while (userInput == "y" || userInput == "Y");
        }
    }
}
