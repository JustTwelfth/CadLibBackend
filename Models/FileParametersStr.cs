using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class FileParametersStr
    {
        public int IdParamDef { get; set; }
        public int IdFile { get; set; }
        public string? Value { get; set; }
        public string? Comment { get; set; }

        public virtual File IdFileNavigation { get; set; } = null!;
        public virtual ParamDef IdParamDefNavigation { get; set; } = null!;
    }
}
