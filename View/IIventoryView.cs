using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public interface IIventoryView
    {
        string ItemName { get; set; }
        string Brand { get; set; }
        string Model { get; set; }
        string SerialNumber { get; set; }
        string Supplier { get; set; }
        DateTime PurchaseDate { get; set; }
        DateTime DateReceived { get; set; }
        DateTime DateInstalled { get; set; }
        string Status { get; set; }
        string Remarks { get; set; }
        string User { get; set; }
        string Department { get; set; }
        string Position { get; set; }
        string ItemLocation { get; set; }
        DateTime DateLastEdited { get; set; }
        string EditedBy { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        event EventHandler SearchEvent;
        event EventHandler AddItemEvent;
        event EventHandler EditEvent;
        event EventHandler DisposeEvent;
        event EventHandler SaveEvent;
        event EventHandler CancelEvent;

        void SetInventoryBindingSource(BindingSource itemList);
        void Show();
    }
}
