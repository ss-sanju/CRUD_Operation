﻿using CRUD.Data;
using CRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace CRUD.Generic;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    //public async Task AddAsync(T entity)
    //{
    //    await _dbSet.AddAsync(entity);
    //}
    //public async Task UpdateAsync(T entity)
    //{
    //    _dbSet.Update(entity);
    //}
    //public async Task DeleteAsync(Guid id)
    //{
    //    var entity = await _dbSet.FindAsync(id);
    //    if (entity != null)
    //    {
    //        _dbSet.Remove(entity);
    //    }
    //}
    public async Task AddAsync(T entity)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    public async Task UpdateAsync(T entity)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    public async Task DetailsAsync(Guid id)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var employee = await _dbSet.FindAsync(id);

            if (employee == null)
            {
                throw new Exception("Employee not found.");
            }

            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
    public async Task DeleteAsync(Guid id)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
            }
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }



}