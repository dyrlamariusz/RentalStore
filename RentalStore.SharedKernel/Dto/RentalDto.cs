﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalStore.SharedKernel.Dto
{
    public enum RentalStatusDto
    {
        Active,
        Completed,
        Canceled,
        Overdue
    }
    public class RentalDto
    {
        public int RentalId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public RentalStatusDto Status { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public decimal Total { get; set; }
        public List<RentalDetailDto> Details { get; set; } = new List<RentalDetailDto>();
    }
}
