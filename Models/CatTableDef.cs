using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class CatTableDef
    {
        public int IdObjectCategory { get; set; }
        public int IdParamDef { get; set; }
        public int ColumnOrder { get; set; }

        public virtual ObjectCategory IdObjectCategoryNavigation { get; set; } = null!;
        public virtual ParamDef IdParamDefNavigation { get; set; } = null!;
    }
}
