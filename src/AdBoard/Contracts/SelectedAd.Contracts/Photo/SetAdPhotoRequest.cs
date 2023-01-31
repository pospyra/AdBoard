using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Contracts.Photo
{
    public class SetAdPhotoRequest
    {
        public Guid Id { get; set; }
        public Guid AdId { get; set; }
    }
}
