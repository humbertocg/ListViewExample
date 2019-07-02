using System;
using System.Collections.Generic;
using Core.ServiceConsumer.Models;

namespace Core.ServiceConsumer
{
    public interface IServiceConsumer
    {
        IEnumerable<ItemModel> GetItems();
    }
}
