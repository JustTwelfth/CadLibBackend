using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class ParametersDefault
    {
        public int IdObjectCategory { get; set; }
        public int IdParamDef { get; set; }
        public string? Value { get; set; }
        public string? Comment { get; set; }

        public virtual ObjectCategory IdObjectCategoryNavigation { get; set; } = null!;
        public virtual ParamDef IdParamDefNavigation { get; set; } = null!;
    }
}
