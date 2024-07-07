using System;
using System.Linq;
using System.Windows.Forms;
using Model;
using Repository;
using View;
using System.Configuration;

namespace IT_Inventory
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            IIventoryView view = new Inventory_cs();
            IInventoryRepository repository = new InventoryRepository(sqlConnectionString);
            new InventoryPresenter(view, repository);
            Application.Run((Form)view);
        }
    }
}