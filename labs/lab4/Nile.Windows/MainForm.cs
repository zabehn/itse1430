/*
 * ITSE 1430
 * Lab 4
 * MainForm
 * Spring 2020
 * Zachary Behn
 * 
 * This file is the form that starts up when the application is started
 */
using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;
using Nile.Stores.Sql;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            var s = ConfigurationManager.ConnectionStrings["ProductDatabase"];
            _database = new SqlProductDatabase(s.ConnectionString);

            _gridProducts.AutoGenerateColumns = false;

            UpdateList();
        }

        #region Event Handlers
        
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            var child = new ProductDetailForm("Product Details");

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    //Save product
                    var product = _database.Add(child.Product);
                    UpdateList();
                    return;
                } catch (Exception ex)
                {
                    DisplayError(ex.Message);
                }
            } while (true);
            
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
            {
                MessageBox.Show("No products available.");
                return;
            };

            EditProduct(product);
        }        

        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            DeleteProduct(product);
        }        
                
        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }

        private void OnKeyDownGrid( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);
			
			//Don't continue with key
            e.SuppressKeyPress = true;
        }

        private void onAboutClick ( object sender, EventArgs e )
        {
            var child = new AboutBox();
            child.ShowDialog(this);
        }

        #endregion

        #region Private Members

        private void DeleteProduct ( Product product )
        {
            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                //Delete product
                _database.Remove(product.Id);
                UpdateList();
            }catch(Exception ex)
            {
                DisplayError(ex.Message);
            }
        }

        private void EditProduct ( Product product )
        {
            var child = new ProductDetailForm("Product Details");
            child.Product = product;
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                try
                {
                    //Save product
                    _database.Update(child.Product);
                    UpdateList();
                    return;
                }catch(Exception ex)
                {
                    DisplayError(ex.Message);
                }
               
            } while (true);
        }

        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private void UpdateList ()
        {
            var products = Enumerable.Empty<Product>();
            try
            {
                products = _database.GetAll();
            } catch(Exception e)
            {
                DisplayError($"Can't pull products from database: {e.Message}");
            }

            products = from product in products
                       orderby product.Name ascending
                       select product;

            _bsProducts.DataSource = products;
        }

        private void DisplayError ( string message )
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        private IProductDatabase _database;
        #endregion
    }
}
