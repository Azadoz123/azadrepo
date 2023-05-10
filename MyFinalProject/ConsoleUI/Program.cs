// See https://aka.ms/new-console-template for more information
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

Console.WriteLine("Hello, World!");
Console.WriteLine();

ProductTest();
//CategoryTest();

static void ProductTest()
{
    ProductManager productManager = new ProductManager(new EfProductDal(), new CategoryManager(new EFCategoryDal()));

    var result = productManager.GetProductDetails();
    if (result.Success)
    {
        foreach (var product in result.Data)
        {
            Console.WriteLine(product.ProductName + "/" + product.CategoryName);
        }
    }
    else
    {
        Console.WriteLine(result.Message);
    }
    
}

static void CategoryTest()
{
    CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());

    foreach (var category in categoryManager.GetAll().Data)
    {
        Console.WriteLine(category.CategoryName);
    }
}

//InMemoryProductDal InMemoryProductDal = new InMemoryProductDal();
//ProductManager productManager = new ProductManager(new InMemoryProductDal());

//foreach(var product in InMemoryProductDal.GetAll())
//{
//    Console.WriteLine(product.ProductName);
//}

//Console.WriteLine();
//Product product1= InMemoryProductDal.GetAll().FirstOrDefault( p => p.ProductId == 1);
//InMemoryProductDal.Delete(product1);
//foreach (var product in InMemoryProductDal.GetAll())
//{
//    Console.WriteLine(product.ProductName);
//}
