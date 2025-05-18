using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class ParamCategory
    {
        public int IdParamCategory { get; set; }
        public int IdParamDef { get; set; }
        public int ParamOrder { get; set; }

        public virtual ParamCategory1 IdParamCategoryNavigation { get; set; } = null!;
        public virtual ParamDef IdParamDefNavigation { get; set; } = null!;
    }
}
