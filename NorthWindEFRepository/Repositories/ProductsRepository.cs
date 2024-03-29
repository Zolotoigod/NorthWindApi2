﻿using Microsoft.EntityFrameworkCore;
using NorthWindEFRepository.Entities;

namespace NorthWindEFRepository.Repositories
{
    public class ProductsRepository : IProductRepository
    {
        private readonly NorthWindContext context;

        public ProductsRepository(NorthWindContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public async Task<int> Add(Product product)
        {
            await context.Products!.AddAsync(product);
            context.SaveChanges();
            return product.Id;
        }

        /// <inheritdoc/>
        public async Task<Product> GetById(int productId)
        {
            return await context.Products!.FindAsync(productId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Product,
                    productId));
        }

        /// <inheritdoc/>
        public async IAsyncEnumerable<Product> GetCollection(int offset, int limit)
        {
            var query = context.Products!.Skip(offset).Take(limit).AsAsyncEnumerable();
            await foreach (var product in query)
            {
                yield return product;
            }
        }

        /// <inheritdoc/>
        public async Task<int> GetCount() => await context.Products!.CountAsync();

        public async IAsyncEnumerable<Product> LookupProductsByName(IList<string> names)
        {
            var query = context.Products!.Where(p => names.Contains(p.Name)).AsAsyncEnumerable();
            await foreach (var product in query)
            {
                yield return product;
            }
        }

        /// <inheritdoc/>
        public async Task Remove(int productId)
        {
            var product = await context.Products!.FindAsync(productId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Product,
                    productId));
            context.Products.Remove(product);

            await context.SaveChangesAsync();
        }

        public async IAsyncEnumerable<Product> ShowProductsForCategory(int categoryId)
        {
            var query = context.Products!.Where(p => p.CategoryId == categoryId).AsAsyncEnumerable();
            await foreach (var product in query)
            {
                yield return product;
            }
        }

        /// <inheritdoc/>
        public async Task Update(int productId, Product newProduct)
        {
            var product = await context.Products!.FindAsync(productId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Product,
                    productId));

            UpdateDate(product, newProduct);

            await context.SaveChangesAsync();
        }

        private  void UpdateDate(Product oldP, Product newP)
        {
            oldP.Name = newP.Name ?? oldP.Name;
            oldP.CategoryId = newP.CategoryId ?? oldP.CategoryId;
            oldP.UnitPrice = newP.UnitPrice ?? oldP.UnitPrice;
            oldP.UnitsOnOrder = newP.UnitsOnOrder ?? oldP.UnitsOnOrder;
            oldP.UnitsInStock = newP.UnitsInStock ?? oldP.UnitsInStock;
            oldP.QuantityPerUnit = newP.QuantityPerUnit ?? oldP.QuantityPerUnit;
            oldP.Discontinued = newP.Discontinued; // discontinued required 
            oldP.SupplierId = newP.SupplierId ?? oldP.SupplierId;
            oldP.ReorderLevel = newP.ReorderLevel ?? oldP.ReorderLevel;
        }
    }
}
