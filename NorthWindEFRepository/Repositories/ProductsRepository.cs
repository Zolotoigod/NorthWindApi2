using Microsoft.EntityFrameworkCore;
using NorthWindEFRepository.Contexts;
using NorthWindEFRepository.Entities;
using System;
using System.Collections.Generic;

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
            var category = await context.Products!.FindAsync(productId)
                ?? throw new KeyNotFoundException(string.Format(
                    Defines.ErrorMesage.ItemNotFoundTemplate,
                    Defines.EntityNames.Category,
                    productId));
            context.Remove(category);

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
                    Defines.EntityNames.Category,
                    productId));

            product.Name = newProduct.Name;
            product.CategoryId = newProduct.CategoryId;
            product.UnitPrice = newProduct.UnitPrice;
            product.UnitsOnOrder = newProduct.UnitsOnOrder;
            product.UnitsInStock = newProduct.UnitsInStock;
            product.QuantityPerUnit = newProduct.QuantityPerUnit;
            product.Discontinued = newProduct.Discontinued;
            product.SupplierId = newProduct.SupplierId;
            product.ReorderLevel = newProduct.ReorderLevel;

            await context.SaveChangesAsync();
        }
    }
}
