using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using View;

namespace IT_Inventory
{
    public partial class Inventory_cs : Telerik.WinControls.UI.RadForm, IIventoryView
    {
        private bool isEdit;
        private bool isSuccessful;
        private string message;
        private DateTime dateLastEdited = DateTime.Now.Date;

        public Inventory_cs()
        {
            InitializeComponent();
            AssociateAndRaiseEvents();
            dgvInventory.Refresh();
        }

        private void AssociateAndRaiseEvents()
        {
            tbSearch.TextChanged += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            btnAdd.Click += delegate 
            { 
                AddItemEvent?.Invoke(this, EventArgs.Empty);
                gbInventory.Enabled = true;
                gbSaveCancel.Enabled = true;
                gbAddEdit.Enabled = false;
            };
            btnEdit.Click += delegate 
            {
                EditEvent?.Invoke(this, EventArgs.Empty);
                gbInventory.Enabled = true;
                gbSaveCancel.Enabled = true;
                gbAddEdit.Enabled = false;
            };
            btnDispose.Click += delegate 
            { 
                var result = MessageBox.Show("Are you sure you want to dispose the selected item?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes) 
                {
                    DisposeEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
                
            };
            btnSave.Click += delegate 
            { 
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if (isSuccessful)
                {
                    gbInventory.Enabled = false;
                    gbSaveCancel.Enabled = false;
                    gbAddEdit.Enabled = true;
                }
                MessageBox.Show(Message);

            };
            btnCancel.Click += delegate 
            { 
                CancelEvent?.Invoke(this, EventArgs.Empty);
                gbInventory.Enabled = false;
                gbSaveCancel.Enabled = false;
                gbAddEdit.Enabled = true;
            };
        }

        public string ItemName { get => tbItem.Text; set => tbItem.Text = value; }
        public string Brand { get => tbBrand.Text; set => tbBrand.Text = value; }
        public string Model { get => tbModel.Text; set => tbModel.Text = value; }
        public string SerialNumber { get => tbSerialNumber.Text; set => tbSerialNumber.Text = value; }
        public string Supplier { get => tbSupplier.Text; set => tbSupplier.Text = value; }
        public DateTime PurchaseDate { get => tbPurchaseDate.Value.Date; set => tbPurchaseDate.Value = value; }
        public DateTime DateReceived { get => tbDateReceived.Value.Date; set => tbDateReceived.Value = value; }
        public DateTime DateInstalled { get => tbDateInstalled.Value.Date; set => tbDateInstalled.Value = value; }
        public string Status { get => tbStatus.Text; set => tbStatus.Text = value; }
        public string Remarks { get => tbRemarks.Text; set => tbRemarks.Text = value; }
        public string User { get => tbUser.Text; set => tbUser.Text = value; }
        public string Department { get => tbDepartment.Text; set => tbDepartment.Text = value; }
        public string Position { get => tbPosition.Text; set => tbPosition.Text = value; }
        public string ItemLocation { get => tbLocation.Text; set => tbLocation.Text = value; }
        public DateTime DateLastEdited { get => dateLastEdited.Date; set => dateLastEdited = value; }
        public string EditedBy { get => tbEditedBy.Text; set => tbEditedBy.Text = value; }
        public string SearchValue { get => tbSearch.Text; set => tbSearch.Text = value; }
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public bool IsSuccessful { get => isSuccessful; set => isSuccessful = value; }
        public string Message { get => message; set => message = value; }


        public event EventHandler SearchEvent;
        public event EventHandler AddItemEvent;
        public event EventHandler EditEvent;
        public event EventHandler DisposeEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetInventoryBindingSource(BindingSource itemList)
        {
            dgvInventory.DataSource = itemList;
        }
    }
}
