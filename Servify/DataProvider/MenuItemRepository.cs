using Dapper;
using Servify.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Servify.DataProvider
{
    public class MenuItemRepository
    {

        private string connectionString;
        public MenuItemRepository()
        {
            connectionString = @"Server=LAPTOP-QFL4HAMQ;Database=Servify;Trusted_Connection=true;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(MenuItem menuItem)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "INSERT INTO menu_item (Name, Description, Price, Category, SubCategory, MenuId)"
                                + " VALUES(@Name, @Description, @Price, @Category, @SubCategory, @MenuId)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, menuItem);
            }
        }

        public IEnumerable<MenuItem> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                dbConnection.Open();
                return dbConnection.Query<MenuItem>("SELECT * FROM menu_item");
            }
        }

        public MenuItem GetByID(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT * FROM MenuItem"
                               + " WHERE ID = @Id";
                dbConnection.Open();
                return dbConnection.Query<MenuItem>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "DELETE FROM MenuItem"
                             + " WHERE ID = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(MenuItem menuItem)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "UPDATE MenuItem SET Name = @Name,"
                               + " Description = @Description, Price = @Price, Category = @Category, SubCategory = @SubCategory, MenuId = @MenuId"
                               + " WHERE MenuId = @MenuId";
                dbConnection.Open();
                dbConnection.Query(sQuery, menuItem);
            }
        }
    }
}
