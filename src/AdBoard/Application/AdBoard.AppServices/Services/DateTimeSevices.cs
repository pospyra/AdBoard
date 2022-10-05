using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.AppServices.Services
{
    public class DateTimeSevices : IDateTimeSevices
    {
        public DateTime GetDateTime()
        {
            return DateTime.Now;
        }

        public DateTime GetUtcDataTime()
        {
            return DateTime.UtcNow;
        }
    }
}
