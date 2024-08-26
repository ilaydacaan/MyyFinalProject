using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntitiyFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();
            //List<Product> _products = new List<Product>;
            //var result = _products.Find(p => p.ProductId == 1);
            //Console.WriteLine(result);
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal(),
                                            new CategoryManager(new EfCategoryDal()));
            //IProductDal productDal = new InMemoryProductDal();
            var result = productManager.GetProuctDetails();
            if(result.Success==true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName+ "/" + product.CategoryName );
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }           
        }
    }
}
