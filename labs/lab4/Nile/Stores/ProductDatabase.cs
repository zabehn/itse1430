/*
 * ITSE 1430
 * Lab 4
 * ProductDatabase
 * Spring 2020
 * Zachary Behn
 * 
 * This file is an abstract implementation of the ProductDatabase interface
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            if (product==null)
                throw new ArgumentNullException(nameof(product),"Product is null");

            if (NameExists(product.Name,product.Id))
                throw new InvalidOperationException("Product name must be unique");

            var errors = ObjectValidator.Validate(product);
            if (errors.Any())
                return null;

            //Emulate database by storing copy
            return AddCore(product);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            if (id<=0)
                throw new ArgumentOutOfRangeException(nameof(id),"id must be greater than 0");

            return GetCore(id);
        }
        
        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            return GetAllCore();
        }
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            if (id<=0)
                throw new ArgumentOutOfRangeException(nameof(id), "id must be greater than 0");

            RemoveCore(id);
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public Product Update ( Product product )
        {
            if (product==null)
                throw new ArgumentNullException(nameof(product),"product can't be null");

            if (NameExists(product.Name, product.Id))
                throw new InvalidOperationException("Product name must be unique");

            var errors = ObjectValidator.Validate(product);
            if (errors.Any())
                return null;

            //Get existing product
            var existing = GetCore(product.Id);

            return UpdateCore(existing, product);
        }

        #region Protected Members

        protected abstract bool NameExists ( string name, int id );

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract Product UpdateCore( Product existing, Product newItem );

        protected abstract Product AddCore( Product product );
        #endregion
    }
}
