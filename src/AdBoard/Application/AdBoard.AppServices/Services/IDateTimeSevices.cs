using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.AppServices.Services
{
    public interface IDateTimeSevices
    {
        DateTime GetDateTime();

        DateTime GetUtcDataTime();
    }
}
