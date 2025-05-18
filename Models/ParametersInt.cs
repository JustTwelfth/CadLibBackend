using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class ParametersInt
    {
        public int IdParamDef { get; set; }
        public int IdObject { get; set; }
        public int? Value { get; set; }
        public string? Comment { get; set; }

        public virtual ObjectsShadow IdObjectNavigation { get; set; } = null!;
        public virtual ParamDef IdParamDefNavigation { get; set; } = null!;
    }
}
