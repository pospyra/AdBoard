using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.DataAccess 
{
    public class SelectedAdContext : DbContext
    {
        ///<summary>
        ///Инициализирует экземпляр <see cref="NsiDbContext"/>.
        ///</summary>
        protected SelectedAdContext(DbContextOptions options)
            : base(options)
        { 
        }

    }
}
 