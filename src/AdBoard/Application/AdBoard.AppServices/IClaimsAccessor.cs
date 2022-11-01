using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AdBoard.AppServices
{
    public interface IClaimsAccessor
    {
        Task<IEnumerable<Claim>> GetClaims(CancellationToken cancellation);
    }
}
