using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.Contracts
{
    public class PagingFilter
    {
        public int CurrentPage { get; set; }
        public int Size { get; set; }
    }
}
