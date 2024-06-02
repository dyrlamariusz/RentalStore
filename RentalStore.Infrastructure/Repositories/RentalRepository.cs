﻿using RentalStore.Domain.Interfaces;
using RentalStore.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.Infrastructure.Repositories
{
    public class RentalRepository : Repository<Rental>, IRentalRepository
    {
        private readonly RentalStoreDbContext _rentalStoreDbContext;

        public RentalRepository(RentalStoreDbContext context)
            : base(context)
        {
            _rentalStoreDbContext = context;
        }

        public Rental Get(int id)
        {
            return _rentalStoreDbContext.Rentals.Find(id);
        }

        public IList<Rental> GetAll()
        {
            return _rentalStoreDbContext.Rentals.ToList();
        }

        public void Insert(Rental entity)
        {
            _rentalStoreDbContext.Rentals.Add(entity);
            _rentalStoreDbContext.SaveChanges();
        }

        public void Delete(Rental entity)
        {
            _rentalStoreDbContext.Rentals.Remove(entity);
            _rentalStoreDbContext.SaveChanges();
        }

        public IList<Rental> Find(Expression<Func<Rental, bool>> expression)
        {
            return _rentalStoreDbContext.Rentals.Where(expression).ToList();
        }

        public int GetMaxId()
        {
            return _rentalStoreDbContext.Rentals.Max(x => x.RentalId);
        }

        public IList<Rental> GetActiveRentals()
        {
            return _context.Set<Rental>()
                .Where(r => r.Status == "Active")
                .ToList();
        }

        public IList<Rental> GetRentalsByAgreementId(int agreementId)
        {
            return _context.Set<Rental>()
                .Where(r => r.AgreementId == agreementId)
                .ToList();
        }

    }
}