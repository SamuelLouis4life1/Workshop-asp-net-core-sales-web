﻿using System;
using System.Linq;
using System.Collections.Generic;

namespace SalesWebMvc.Models
{
    public class Seller
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            this.id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord salesRecord)
        {
            SalesRecords.Add(salesRecord);
        }

        public void RemoveSales (SalesRecord salesRecord)
        {
            SalesRecords.Remove(salesRecord);
        }

         public double TotalSales(DateTime initial, DateTime final)
        {
            return SalesRecords.Where(salerecord => salerecord.Date >= initial && salerecord.Date <= final).Sum(salerecord => salerecord.Amount);
        }
    }
}
