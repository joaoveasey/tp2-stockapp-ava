﻿using StockApp.Domain;
using StockApp.Domain.Interfaces;
using StockApp.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace StockApp.Infra.Data.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private ApplicationDbContext _Suppliercontext;

        public SupplierRepository(ApplicationDbContext context)
        {
            _Suppliercontext = context;
        }

        public async Task<Supplier> GetByIdAsync(int id)
        {
            return await _Suppliercontext.Suppliers.FindAsync(id);
        }

        public async Task<IEnumerable<Supplier>> GettAllAsync()
        {
            return await _Suppliercontext.Suppliers.ToListAsync();
        }

        public async Task AddAsync(Supplier supplier)
        {
            _Suppliercontext.Suppliers.Add(supplier);
            await _Suppliercontext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Supplier supplier)
        {
            _Suppliercontext.Suppliers.Update(supplier);
            await _Suppliercontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var supplier = await _Suppliercontext.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                _Suppliercontext.Suppliers.Remove(supplier);
                await _Suppliercontext.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<Supplier>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Supplier>> SearchAsync(string name, string contactEmail)
        {
            var query = _Suppliercontext.Suppliers.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(contactEmail))
            {
                query = query.Where(s => s.ContactEmail.Contains(contactEmail));
            }

            return await query.ToListAsync();
        }
    }
}
