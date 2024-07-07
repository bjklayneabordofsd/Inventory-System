using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Model;

namespace Repository
{
    public class InventoryRepository : BaseRepository, IInventoryRepository
    {
        public InventoryRepository(string connectionString) 
        {
            this.connectionString = connectionString;
        }
        public void Add(InventoryModel inventoryModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            { 
                connection.Open();
                command.Connection = connection;
                command.CommandText = "insert into equipment values (@Item_Name, @Item_Brand, @Item_Model, @Serial_Number, " +
                    "@Item_Supplier, @Purchase_Date, @Date_Received, @Date_Installed," +
                    "@Item_Status, @Remarks, @Item_User, @Department," +
                    "@Item_Position, @Item_Location, @Date_Last_Edited, @Edited_By)";
                command.Parameters.Add("@Item_Name", SqlDbType.NVarChar).Value = inventoryModel.ItemName;
                command.Parameters.Add("@Item_Brand", SqlDbType.NVarChar).Value = inventoryModel.Brand;
                command.Parameters.Add("@Item_Model", SqlDbType.NVarChar).Value = inventoryModel.Model;
                command.Parameters.Add("@Serial_Number", SqlDbType.NVarChar).Value = inventoryModel.SerialNumber;
                command.Parameters.Add("@Item_Supplier", SqlDbType.NVarChar).Value = inventoryModel.Supplier;
                command.Parameters.Add("@Purchase_Date", SqlDbType.Date).Value = inventoryModel.PurchaseDate;
                command.Parameters.Add("@Date_Received", SqlDbType.Date).Value = inventoryModel.DateReceived;
                command.Parameters.Add("@Date_Installed", SqlDbType.Date).Value = inventoryModel.DateInstalled;
                command.Parameters.Add("@Item_Status", SqlDbType.NVarChar).Value = inventoryModel.Status;
                command.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = inventoryModel.Remarks;
                command.Parameters.Add("@Item_User", SqlDbType.NVarChar).Value = inventoryModel.User;
                command.Parameters.Add("@Department", SqlDbType.NVarChar).Value = inventoryModel.Department;
                command.Parameters.Add("@Item_Position", SqlDbType.NVarChar).Value = inventoryModel.Position;
                command.Parameters.Add("@Item_Location", SqlDbType.NVarChar).Value = inventoryModel.Location;
                command.Parameters.Add("@Date_Last_Edited", SqlDbType.Date).Value = inventoryModel.DateLastEdited;
                command.Parameters.Add("@Edited_By", SqlDbType.NVarChar).Value = inventoryModel.LastEditedBy;
                command.ExecuteNonQuery();
            }
        }

        public void Dipose(string serialNumber)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from equipment where serialNumber=@Serial_Number";
                command.Parameters.Add("@Serial_Number", SqlDbType.NVarChar).Value = serialNumber;
                command.ExecuteNonQuery();
            }
        }

        public void Edit(InventoryModel inventoryModel)
        {
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"update equipment set item = @Item_Name,
                                        brand = @Item_Brand, model = @Item_Model,
                                        supplier = @Item_Supplier, purchaseDate = @Purchase_Date,
                                        dateReceived = @Date_Received, dateInstalled = @Date_Installed,
                                        itemStatus = @Item_Status,remarks = @Remarks,
                                        itemUser = @Item_User, department = @Department,
                                        position = @Item_Position, itemLocation = @Item_Location,
                                        dateLastEdited = @Date_Last_Edited, editedBy = @Edited_By
                                        where serialNumber = @Serial_Number ";
                command.Parameters.Add("@Item_Name", SqlDbType.NVarChar).Value = inventoryModel.ItemName;
                command.Parameters.Add("@Item_Brand", SqlDbType.NVarChar).Value = inventoryModel.Brand;
                command.Parameters.Add("@Item_Model", SqlDbType.NVarChar).Value = inventoryModel.Model;
                command.Parameters.Add("@Serial_Number", SqlDbType.NVarChar).Value = inventoryModel.SerialNumber;
                command.Parameters.Add("@Item_Supplier", SqlDbType.NVarChar).Value = inventoryModel.Supplier;
                command.Parameters.Add("@Purchase_Date", SqlDbType.Date).Value = inventoryModel.PurchaseDate;
                command.Parameters.Add("@Date_Received", SqlDbType.Date).Value = inventoryModel.DateReceived;
                command.Parameters.Add("@Date_Installed", SqlDbType.Date).Value = inventoryModel.DateInstalled;
                command.Parameters.Add("@Item_Status", SqlDbType.NVarChar).Value = inventoryModel.Status;
                command.Parameters.Add("@Remarks", SqlDbType.NVarChar).Value = inventoryModel.Remarks;
                command.Parameters.Add("@Item_User", SqlDbType.NVarChar).Value = inventoryModel.User;
                command.Parameters.Add("@Department", SqlDbType.NVarChar).Value = inventoryModel.Department;
                command.Parameters.Add("@Item_Position", SqlDbType.NVarChar).Value = inventoryModel.Position;
                command.Parameters.Add("@Item_Location", SqlDbType.NVarChar).Value = inventoryModel.Location;
                command.Parameters.Add("@Date_Last_Edited", SqlDbType.Date).Value = inventoryModel.DateLastEdited;
                command.Parameters.Add("@Edited_By", SqlDbType.NVarChar).Value = inventoryModel.LastEditedBy;
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<InventoryModel> GetAll()
        {
            var itemList = new List<InventoryModel>();
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            { 
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select * from equipment order by serialNumber desc";
                using (var reader = command.ExecuteReader()) 
                {
                    while (reader.Read()) 
                    {
                        var inventoryModel = new InventoryModel();
                        inventoryModel.ItemName= reader[0].ToString();
                        inventoryModel.Brand= reader[1].ToString();
                        inventoryModel.Model= reader[2].ToString();
                        inventoryModel.SerialNumber = reader[3].ToString();
                        inventoryModel.Supplier = reader[4].ToString();
                        inventoryModel.PurchaseDate = (DateTime)reader[5];
                        inventoryModel.DateReceived = (DateTime)reader[6];
                        inventoryModel.DateInstalled = (DateTime)reader[7];
                        inventoryModel.Status = reader[8].ToString();
                        inventoryModel.Remarks = reader[9].ToString();
                        inventoryModel.User = reader[10].ToString();
                        inventoryModel.Department = reader[11].ToString();
                        inventoryModel.Position = reader[12].ToString();
                        inventoryModel.Location = reader[13].ToString();
                        inventoryModel.DateLastEdited = (DateTime)reader[14];
                        inventoryModel.LastEditedBy = reader[15].ToString();
                        itemList.Add(inventoryModel);
                    }
                }
            }
            return itemList;
        }

        public IEnumerable<InventoryModel> GetByValue(string value)
        {
            var itemList = new List<InventoryModel>();
            string serialNumber = value;
            string itemName = value;
            using (var connection = new SqlConnection(connectionString))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"Select * from equipment
                                        where serialNumber=@Serial_Number or item like @Item_Name+'%'
                                        order by serialNumber desc";
                command.Parameters.Add("@Serial_Number", SqlDbType.NVarChar).Value = serialNumber;
                command.Parameters.Add("@Item_Name", SqlDbType.NVarChar).Value = itemName;
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var inventoryModel = new InventoryModel();
                        inventoryModel.ItemName = reader[0].ToString();
                        inventoryModel.Brand = reader[1].ToString();
                        inventoryModel.Model= reader[2].ToString();
                        inventoryModel.SerialNumber = reader[3].ToString();
                        inventoryModel.Supplier = reader[4].ToString();
                        inventoryModel.PurchaseDate = (DateTime)reader[5];
                        inventoryModel.DateReceived = (DateTime)reader[6];
                        inventoryModel.DateInstalled = (DateTime)reader[7];
                        inventoryModel.Status = reader[8].ToString();
                        inventoryModel.Remarks = reader[9].ToString();
                        inventoryModel.User = reader[10].ToString();
                        inventoryModel.Department = reader[11].ToString();
                        inventoryModel.Position = reader[12].ToString();
                        inventoryModel.Location = reader[13].ToString();
                        inventoryModel.DateLastEdited = (DateTime)reader[14];
                        inventoryModel.LastEditedBy = reader[15].ToString();
                        itemList.Add(inventoryModel);
                    }
                }
            }
            return itemList;
        }
    }
}
