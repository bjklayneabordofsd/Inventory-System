using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace IT_Inventory
{
    public class InventoryPresenter
    {
        private IIventoryView view;
        private IInventoryRepository repository;
        private BindingSource inventoryBindingSource;
        private IEnumerable<InventoryModel> itemList;

        public InventoryPresenter(IIventoryView view, IInventoryRepository repository)
        {
            this.inventoryBindingSource = new BindingSource();
            this.view = view;
            this.repository = repository;

            this.view.SearchEvent += SearchItems;
            this.view.AddItemEvent += AddItem;
            this.view.EditEvent += LoadSelectedItemToEdit;
            this.view.DisposeEvent += DisposeSelectedItem;
            this.view.SaveEvent += SaveItem;
            this.view.CancelEvent += CancelAction;

            this.view.SetInventoryBindingSource(inventoryBindingSource);

            LoadAllItems();

            this.view.Show();
        }

        private void LoadAllItems()
        {
            itemList = repository.GetAll();
            inventoryBindingSource.DataSource = itemList;
        }

        private void CancelAction(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void SaveItem(object sender, EventArgs e)
        {
            var model = new InventoryModel();
            model.ItemName = view.ItemName;
            model.Brand = view.Brand;
            model.Model = view.Model;
            model.SerialNumber = view.SerialNumber;
            model.Supplier = view.Supplier;
            model.PurchaseDate = view.PurchaseDate;
            model.DateReceived = view.DateReceived;
            model.DateInstalled = view.DateInstalled;
            model.Status = view.Status;
            model.Remarks = view.Remarks;
            model.User = view.User;
            model.Department = view.Department;
            model.Position  = view.Position;
            model.Location = view.ItemLocation;
            model.DateLastEdited = view.DateLastEdited;
            model.LastEditedBy = view.EditedBy;
            try { 
                new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit)
                {
                    repository.Edit(model);
                    view.Message = "Item Edited successfully";
                }
                else 
                {
                    repository.Add(model);
                    view.Message = "Item Added successfully";
                }
                view.IsSuccessful = true;
                LoadAllItems();
                ClearFields();
            } 
            catch (Exception ex) { 
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void ClearFields()
        {
            view.ItemName = "";
            view.Brand = "";
            view.Model = "";
            view.SerialNumber = "";
            view.Supplier = "";
            view.PurchaseDate = DateTime.Now;
            view.DateReceived = DateTime.Now;
            view.DateInstalled = DateTime.Now;
            view.Status = "";
            view.Remarks = "";
            view.User = "";
            view.Department = "";
            view.Position = "";
            view.ItemLocation = "";
            view.DateLastEdited = DateTime.Now;
        }

        private void DisposeSelectedItem(object sender, EventArgs e)
        {
            try
            {
                var item = (InventoryModel)inventoryBindingSource.Current;
                repository.Dipose(item.SerialNumber);
                view.IsSuccessful = true;
                view.Message = "Item is Disposed successfully";
                LoadAllItems();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "An Error ocurred, could not dipose item";
            }
        }

        private void LoadSelectedItemToEdit(object sender, EventArgs e)
        {
            var item = (InventoryModel)inventoryBindingSource.Current;
            view.ItemName = item.ItemName;
            view.Brand = item.Brand;
            view.Model = item.Model;
            view.SerialNumber = item.SerialNumber;
            view.Supplier = item.Supplier;
            view.PurchaseDate = item.PurchaseDate;
            view.DateReceived = item.DateReceived;
            view.DateInstalled = item.DateInstalled;
            view.Status = item.Status;
            view.Remarks = item.Remarks;
            view.User = item.User;
            view.Department = item.Department;
            view.Position = item.Position;
            view.ItemLocation = item.Location;
            view.DateLastEdited = item.DateLastEdited;
            view.EditedBy = item.LastEditedBy;
            view.IsEdit = true;
        }

        private void AddItem(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void SearchItems(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
                itemList = repository.GetByValue(this.view.SearchValue);
            else itemList = repository.GetAll();
            inventoryBindingSource.DataSource = itemList;
        }
    }
}
