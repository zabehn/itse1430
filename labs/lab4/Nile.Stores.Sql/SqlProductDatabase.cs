/*
 * ITSE 1430
 * Lab 4
 * SqlProductDatabase
 * Spring 2020
 * Zachary Behn
 * 
 * This file is a Sql Database implementation of ProductDatabase
 */

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Stores.Sql
{
    public class SqlProductDatabase : ProductDatabase
    {
        /// <summary>Initializes Database by providing the connection string.</summary>
        /// <param name="connectionString">Connection string to the database.</param>
        /// <returns>An object to perform database operations on.</returns>
        public SqlProductDatabase ( string connectionString )
        {
             _sqlDatabaseString = connectionString;
        }

        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        protected override Product AddCore ( Product product )
        {
            using ( var connection = OpenConnection() )
            {
                var command = new SqlCommand("AddProduct", connection) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Name",product.Name);
                command.Parameters.AddWithValue("@Description", product.Description);
                command.Parameters.AddWithValue("@Price", product.Price);
                command.Parameters.AddWithValue("@IsDiscontinued", product.IsDiscontinued);

                var result = command.ExecuteScalar();

                var id = Convert.ToInt32(result);
                product.Id = id;

                return product;
            };
        }

        /// <summary>Creates and returns the list of all products in the database.</summary>
        /// <returns>A list of all products in the database.</returns>
        protected override IEnumerable<Product> GetAllCore ()
        {
            var items = new List<Product>();

            var dataSet = new DataSet();

            using (var connection = OpenConnection())
            {
                var command = connection.CreateCommand();
                command.CommandText = "GetAllProducts";
                command.CommandType = System.Data.CommandType.StoredProcedure;

                var adapter = new SqlDataAdapter {
                    SelectCommand = command
                };
                adapter.Fill(dataSet);
            };

            var table = dataSet.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    var product = new Product() {
                        Id = row.Field<int>(0),
                        Name = row.Field<string>(1),
                        Price = row.Field<decimal>(2),
                        Description = row.Field<string>(3),
                        IsDiscontinued = row.Field<bool>(4)
                    };

                    items.Add(product);
                };
            };

            return items;
        }

        /// <summary>Queiries a product with id.</summary>
        /// <param name="id">The id of the product queried.</param>
        /// <returns>The Queried product.</returns>
        protected override Product GetCore ( int id )
        {
            using (var connection = OpenConnection())
            {
                var command = new SqlCommand("GetProduct", connection) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product() {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Price = reader.GetDecimal(2),
                            Description = reader.GetString(3),
                            IsDiscontinued = reader.GetBoolean(4)
                        };

                        return product;
                    };
                };
            };

            return null;
        }

        /// <summary>checks to see if a name exists in the database.</summary>
        /// <param name="name">name being tested.</param>
        /// <param name="id">The id of the current product to ignore that name.</param>
        /// <returns>if the name exists.</returns>
        protected override bool NameExists ( string name, int id )
        {
            var ds = new DataSet();

            using (var connection = OpenConnection())
            {
                var command = new SqlCommand("GetAllProducts", connection) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                _=new SqlDataAdapter(command).Fill(ds);
            };

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault();
            if (table != null)
            {
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    
                    if ( String.Compare(name,row.Field<string>(1), true) == 0 && row.Field<int>(0) != id )
                    {
                        return true;
                    };
                };
            };

            return false;
        }

        /// <summary>Removes a Product.</summary>
        /// <param name="id">The id of the product.</param>
        protected override void RemoveCore ( int id )
        {
            using ( var connection = OpenConnection() )
            {
                var command = new SqlCommand("RemoveProduct", connection) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                command.Parameters.AddWithValue("@Id", id);
                command.ExecuteNonQuery();
            };
        }

        /// <summary>Updates an existing product with new values.</summary>
        /// <param name="existing">The current product.</param>
        /// /// <param name="newItem">The new values.</param>
        /// <returns>The updated product.</returns>
        protected override Product UpdateCore ( Product existing, Product newItem )
        {
            using (var connection = OpenConnection())
            {
                var command = new SqlCommand("UpdateProduct", connection) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@Id", existing.Id);

                command.Parameters.AddWithValue("@Name", newItem.Name);
                command.Parameters.AddWithValue("@Description", newItem.Description);
                command.Parameters.AddWithValue("@Price", newItem.Price);
                command.Parameters.AddWithValue("@IsDiscontinued", newItem.IsDiscontinued);

                command.ExecuteNonQuery();

                return newItem;
            };
        }

        #region PrivateMembers

        /// <summary>Opens a connection to the database.</summary>
        /// <returns>The connection.</returns>
        private SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(_sqlDatabaseString);
            connection.Open();

            return connection;
        }

        private readonly string _sqlDatabaseString;

        #endregion
    }
}
