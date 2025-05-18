using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class ParamTable
    {
        public ParamTable()
        {
            ParamDefs = new HashSet<ParamDef>();
        }

        public int IdParamTable { get; set; }
        public string TableName { get; set; } = null!;
        public string TableDescription { get; set; } = null!;

        public virtual ICollection<ParamDef> ParamDefs { get; set; }
    }
}
