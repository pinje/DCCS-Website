using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SeasonBranch
{
    public enum SeasonType
    {
        [Display(Name = "DCCS Regular Season")]
        REGULAR,
        [Display(Name = "FACEIT Collegiate Qualifier")]
        QUALIFIER
    }
}
