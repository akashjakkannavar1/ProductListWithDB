using System;
using System.Collections.Generic;
using System.Text;

namespace CrudOperationsLinq
{
    public class Site
    {
        public int pin { get; set; }
        public string location { get; set; }
        public Site(int pin, string location)
        {
            this.pin = pin;
            this.location = location;
        }

        public static List<Site> createSiteList()
        {
            List<Site> sites = new List<Site>();
            char userInput;
            do
            {
                Console.WriteLine("enter pin:");
                int pin = int.Parse(Console.ReadLine());

                Console.WriteLine("enter location:");
                string loc = Console.ReadLine();

                sites.Add(new Site(pin, loc));

                Console.WriteLine("To add another location press y/Y..");
                userInput = Convert.ToChar(Console.ReadLine());

            } while (userInput == 'y' || userInput == 'Y');
            return sites;
        }
    }
}
