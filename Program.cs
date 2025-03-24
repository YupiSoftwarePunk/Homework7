using static System.Formats.Asn1.AsnWriter;

namespace Homework7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Store<Product> store = new Store<Product>();

            store.Add(new Product(1, "PC", 1200, "IT", 10));
            store.Add(new Product(2, "Mouse", 200, "IT", 11));
            store.Add(new Product(3, "Orange", 10, "Fruits", 20));
            store.Add(new Product(4, "Apple", 15, "Fruits", 20));

            store.Remove(4);


            var a = store.GetProductById(1);
            Console.WriteLine(a);

            store.UpdateQuantity(1, 20);

            store.UpdatePrice(1, 2000);

            var b = store.GetProductsByCategory("IT");
            foreach (var item in b)
            {
                Console.WriteLine(item.Category);
            }

            var c = store.GroupByCategory();
            foreach (var item in c)
            {
                Console.WriteLine(item);
            }



        }
    }
}
