using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStandardsForRoundsAndInspectionsAPI.ViewModels.ViewModels.AuthenticationDTO
{
    public record ResetPasswordDTO(
        string Email, 
        string Token, 
        string NewPassword, 
        string ConfirmPassword
    );
}
