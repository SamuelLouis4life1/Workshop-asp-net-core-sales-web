using SalesWebMvc.Data;
using SalesWebMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc.Services
{
    public class SellerService
    {
        private readonly ApplicationDbContext _context;

        public SellerService (ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Sellers.ToList();
        }

        public void Insert(Seller seller)
        {
            //in case to use a default department
            //seller.Department = _context.Department.First();
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller  FindById(int id)
        {
            return _context.Sellers.FirstOrDefault(obj => obj.id == id);
        }

        public void Remove (int id)
        {
            var obj = _context.Sellers.Find(id);
            _context.Sellers.Remove(obj);
            _context.SaveChanges();
        }
    }
}
