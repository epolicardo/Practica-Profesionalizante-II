using OrderNow.Common.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderNow.Common.Data.DTOs
{
    public class BusinessDTO
    {
        public Business Business { get; set; }
        public Address Address { get; set; }

        public BusinessDTO()
        {
            Business = new Business();
            Address = new Address();
        }
    }
}