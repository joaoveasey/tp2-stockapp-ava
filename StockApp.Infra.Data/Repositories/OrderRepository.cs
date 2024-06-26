﻿using Microsoft.EntityFrameworkCore;
using StockApp.Domain.Entities;
using StockApp.Domain.Interfaces;
using StockApp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Infra.Data.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _context.Orders.Include(o=> o.Products).ToList();
        }

        public async Task<IEnumerable<Order>> GetByProductAsync(int productId)
        {
            return await _context.Orders.Include(o => o.Products).Where(o => o.ProductId == productId).ToListAsync();
        }

        public async Task<IEnumerable<Order>> GetByUserIdAsync(string userId)
        {
            return await _context.Orders
                  .Include(o => o.Products)
                .Where(o => o.UserId == userId)
                .ToListAsync();

        }

        public async Task<int> GetCount()
        {
            return await _context.Orders.CountAsync();
        }

        public async Task<int> GetSales()
        {            
            return await _context.Orders.SumAsync(o=> o.Products.Count);
        }
    }
}
