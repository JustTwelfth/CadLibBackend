using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class ParamValue
    {
        public int IdParamValue { get; set; }
        public int IdParamDef { get; set; }
        public string Value { get; set; } = null!;
        public string Comment { get; set; } = null!;

        public virtual ParamDef IdParamDefNavigation { get; set; } = null!;
    }
}
