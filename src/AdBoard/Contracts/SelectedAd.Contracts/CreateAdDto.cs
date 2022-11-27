using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Contracts
{
    public class CreateAdDto
    {
        public string AdName { get; set; }

        public  string Description { get; set; }

        public string Region { get; set; }

        public Guid CategoryId { get; set; }


        public byte[]? LinkPhoto { get; set; }

        public decimal Price { get; set; }

        public bool PossibleDelivery { get; set; }

        public Guid? UserId { get; set; }
    }
}
