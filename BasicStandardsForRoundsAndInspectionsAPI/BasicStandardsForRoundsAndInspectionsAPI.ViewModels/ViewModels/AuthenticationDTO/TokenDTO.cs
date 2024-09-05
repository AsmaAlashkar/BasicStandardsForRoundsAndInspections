using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.AuthenticationDTO
{
    public record TokenDTO(string Token , DateTime Expiry, string Role);
    
    
}
