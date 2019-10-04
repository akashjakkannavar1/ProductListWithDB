using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
namespace CrudOperationsLinq
{
    public class Product
    {
        public ObjectId id;
        public int product_id { get; set; }
        public List<Category> categoryList;

        public Product(int pid, List<Category> cat)
        {
            product_id = pid;
            categoryList = cat;
        }

        public static List<Product> createProductList()
        {
            char userInput;
            List<Product> products = new List<Product>();
            do
            {
                Console.WriteLine("enter product id:");
                int pid = int.Parse(Console.ReadLine());

                List<Category> tmpCate = Category.createCategoryList();

                products.Add(new Product(pid, tmpCate));

                Console.WriteLine("To add another product press y/Y..");
                userInput = Convert.ToChar(Console.ReadLine());

            } while (userInput == 'y' || userInput == 'Y');
            return products;
        }
    }
}
