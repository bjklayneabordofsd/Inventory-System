using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Model
{
    public class InventoryModel
    {
        //Fields
        private string itemName;
        private string brand;
        private string model;
        private string serialNumber;
        private string supplier;
        private DateTime purchaseDate;
        private DateTime dateReceived;
        private DateTime dateInstalled;
        private string status;
        private string remarks;
        private string user;
        private string department;
        private string position;
        private string location;
        private DateTime dateLastEdited;
        private string lastEditedBy;

        //Properties
        [DisplayName("Item")]
        [Required(ErrorMessage = "Item Name is required")]
        public string ItemName { get => itemName; set => itemName = value; }
        [DisplayName("Brand")]
        public string Brand { get => brand; set => brand = value; }
        [DisplayName("Model")]
        public string Model { get => model; set => model = value; }
        [DisplayName("Serial Number")]
        [Required(ErrorMessage = "Serial Number is required")]
        public string SerialNumber { get => serialNumber; set => serialNumber = value; }
        [DisplayName("Supplier")]
        public string Supplier { get => supplier; set => supplier = value; }
        [DisplayName("Purchase Date")]
        public DateTime PurchaseDate { get => purchaseDate; set => purchaseDate = value; }
        [DisplayName("Date Received")]
        public DateTime DateReceived { get => dateReceived; set => dateReceived = value; }
        [DisplayName("Date Installed")]
        public DateTime DateInstalled { get => dateInstalled; set => dateInstalled = value; }
        [DisplayName("Status")]
        [RegularExpression("Active|Inactive", ErrorMessage = "Choose Between Active or Inactive")]
        [Required(ErrorMessage = "Status Required")]
        public string Status { get => status; set => status = value; }
        [DisplayName("Remarks")]
        public string Remarks { get => remarks; set => remarks = value; }
        [DisplayName("User")]
        public string User { get => user; set => user = value; }
        [DisplayName("Department")]
        public string Department { get => department; set => department = value; }
        [DisplayName("Position")]
        public string Position { get => position; set => position = value; }
        [DisplayName("Location")]
        public string Location { get => location; set => location = value; }
        [DisplayName("Date Last Edited")]
        public DateTime DateLastEdited { get => dateLastEdited; set => dateLastEdited = value; }
        [DisplayName("Last Edited By")]
        public string LastEditedBy { get => lastEditedBy; set => lastEditedBy = value; }
    }
}
