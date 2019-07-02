using System;
using System.Collections.Generic;
using Core.ServiceConsumer.Models;

namespace Core.ServiceConsumer
{
    public class ServiceConsumer : IServiceConsumer
    {
        public IEnumerable<ItemModel> GetItems()
        {
            var items = new List<ItemModel>();
            for (int index = 1; index <= 10; index++)
            {
                var item = new ItemModel();
                item.Title = $"Title {index}";
                item.Description = $"Description {index}";
                items.Add(item);
            }
            return items;
        }
    }
}
