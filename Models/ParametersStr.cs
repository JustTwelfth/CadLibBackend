using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class ParametersStr
    {
        public int IdParamDef { get; set; }
        public int IdObject { get; set; }
        public string? Value { get; set; }
        public string? Comment { get; set; }

        public virtual ObjectsShadow IdObjectNavigation { get; set; } = null!;
        public virtual ParamDef IdParamDefNavigation { get; set; } = null!;
    }
}
