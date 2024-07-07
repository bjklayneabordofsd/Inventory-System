using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IInventoryRepository
    {
        void Add(InventoryModel inventoryModel);
        void Edit(InventoryModel inventoryModel);
        void Dipose(string serialNumber);
        IEnumerable<InventoryModel> GetAll();
        IEnumerable<InventoryModel> GetByValue(string value);
    }
}
