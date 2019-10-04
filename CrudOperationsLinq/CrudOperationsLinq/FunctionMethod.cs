using System;
using System.Collections.Generic;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Text;
using System.Linq;

namespace CrudOperationsLinq
{
    public class FunctionMethod
    {
        public static MongoClient client = new MongoClient("mongodb://localhost:27017");
        public static IMongoDatabase db = client.GetDatabase("ProductDb");

        public void Menu(int userInput)
        {

            switch (userInput)
            {
                case 1:
                    List<Product> newProduct = Product.createProductList();         //Inserting documents
                    var obj = db.GetCollection<Product>("product");
                    obj.InsertMany(newProduct);
                    
                    break;
                case 2:Console.WriteLine("Enter the product id:");                  //retrieving specific document
                    int pid = int.Parse(Console.ReadLine());
                    var obj2 = db.GetCollection<Product>("product");
                    var prods=obj2.Find<Product>(new BsonDocument() { { "product_id",pid } }).ToList();
                    foreach(var pr in prods)
                    {
                        Console.WriteLine(pr.product_id);
                        foreach (var cat in pr.categoryList)
                        {
                            Console.WriteLine(cat.product_type);
                            foreach (var sit in cat.siteList)
                            {
                                Console.WriteLine(sit.location + " " + sit.pin);
                            }

                        }
                    }
                    Console.WriteLine();

                    break;
                case 3:
                    var collLIst = db.GetCollection<Product>("product");                //retrieving all the documents
                    var all = collLIst.Find(new BsonDocument());
                    foreach(var p in all.ToEnumerable())
                    {
                        Console.WriteLine(p.product_id);
                        foreach(var c in p.categoryList)
                        {
                            Console.WriteLine(c.product_type);
                            foreach(var s in c.siteList )
                            {
                                Console.WriteLine(s.pin + " " + s.location);
                            }
                        }
                    }
                    break;
                case 4:
                    Console.WriteLine("Enter location:");
                    string loc = Console.ReadLine();
                    var prodList = db.GetCollection<Product>("product");
                    var pidList = prodList.Find(new BsonDocument()).ToList();
                    var res = from p in pidList
                              from cate in p.categoryList
                              from site1 in cate.siteList                                   //retrieving specific document
                              where site1.location == loc
                              select p;
                    foreach (var r in res)
                    {
                        Console.WriteLine(r.product_id);
                        foreach(var p in r.categoryList)
                        {
                            Console.WriteLine(r.product_id + " " + p.product_type);
                        }
                    }
                    break;
                case 5:
                    
                    var updatedlist = db.GetCollection<Product>("product");
                    var productlist = Program.createProduct();
                    updatedlist.FindOneAndUpdate(Builders<Product>.Filter.Eq("product_id", productlist.product_id), 
                                                    Builders<Product>.Update.Set("categoryList", productlist.categoryList));
                    break;
                case 6:Console.WriteLine("enter the pid of product to be deleted:");
                    int delpid = int.Parse(Console.ReadLine());
                    var delList = db.GetCollection<Product>("product");
                    delList.DeleteOne(s=>s.product_id==delpid );

                    break;
             default:
                    Console.WriteLine("invalid input");
                    break;

            }
        }
    }
}
