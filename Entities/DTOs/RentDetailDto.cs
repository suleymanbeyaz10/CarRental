using Core.Entities;
using Microsoft.Identity.Client.AuthScheme.PoP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class RentDetailDto : IDto
    {
        public int RentalId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CarName { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
