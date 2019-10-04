using System;
using System.Collections.Generic;
using System.Text;

namespace CrudOperationsLinq
{
    public class Category
    {
        public string product_type { get; set; }
        public List<Site> siteList;
        public Category(string product_type, List<Site> sit)
        {
            this.product_type = product_type;
            this.siteList = sit;
        }

        public static List<Category> createCategoryList()
        {
            char userInput;
            List<Category> categories = new List<Category>();
            do
            {
                Console.WriteLine("enter product type:");
                string ptype = Console.ReadLine();

                List<Site> tmpSite = Site.createSiteList();

                categories.Add(new Category(ptype, tmpSite));

                Console.WriteLine("To add another category press y/Y..");
                userInput = Convert.ToChar(Console.ReadLine());

            } while (userInput == 'y' || userInput == 'Y');
            return categories;
        }
    }
}
