using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    public class Store<T> : IStore<T> where T : IProduct
    {
        private List<T> store = new List<T>();

        public void Add(T product)
        {
            bool storeContains = store.Any(i => i.Id == product.Id);
            if (!storeContains)
            {
                store.Add(product);
            }
            else
            {
                throw new Exception("Товар с таким Id уже существует!!");
            }
        }

        public void Remove(int id)
        {
            var storeRemove = store.FirstOrDefault(i => i.Id == id);
            if (storeRemove != null)
            {
                store.Remove(storeRemove);
            }
            else
            {
                throw new InvalidOperationException("Товара с таким Id не существует!!");
            }
        }

        public T GetProductById(int id)
        {
            var item = store.FirstOrDefault(i => i.Id == id);
            if (item != null)
            { 
                return item;
            }
            else
            {
                throw new Exception("Товара с таким Id не существует!!");
            }
        }

        public void UpdatePrice(int id, decimal newPrice)
        {
            var item = store.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.Price = newPrice;
            }
            else
            {
                throw new ArgumentException("Товара с таким Id не существует!!");
            }
        }

        public void UpdateQuantity(int id, int newQuantity)
        {
            var item = store.FirstOrDefault(i => i.Id == id);
            if (item != null)
            {
                item.Quantity = newQuantity;
            }
            else
            {
                throw new ArgumentException("Товара с таким Id не существует!!");
            }
        }

        public List<T> GetProductsByCategory(string category)
        {
            return store.OrderBy(i => i.Category == category).ToList();
        }

        public Dictionary<string, List<T>> GroupByCategory()
        {
            Dictionary<string, List<T>> groups = new Dictionary<string, List<T>>();
            var result = store.GroupBy(i => i.Category);

            foreach (var i in result)
            {
                groups[i.Key] = i.ToList();
            }

            return groups;
        }
    }
}
