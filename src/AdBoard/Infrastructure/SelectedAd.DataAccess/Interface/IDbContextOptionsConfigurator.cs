using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelectedAd.DataAccess.Interface
{
    /// <summary>
    /// Конфигуратор контекста.
    /// </summary>
    public interface IDbContextOptionsConfigurator<TContext> where TContext : DbContext
    {
        /// <summary>
        /// Выполняет конфигурацию контекста.
        /// </summary>
        /// <param name="opions">настройки</param>
        void Configure(DbContextOptionsBuilder<TContext> opions);
    }
}
 