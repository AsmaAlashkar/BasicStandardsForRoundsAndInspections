using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.AuthenticationDTO
{
    public record ResetPasswordDTO(
        string UserName, 
        string OldPassword, 
        string NewPassword, 
        string ConfirmPassword);
 
}
