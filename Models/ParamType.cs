using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class ParamType
    {
        public ParamType()
        {
            ParamDefs = new HashSet<ParamDef>();
        }

        public int IdType { get; set; }
        public string TypeName { get; set; } = null!;
        public string TypeCaption { get; set; } = null!;

        public virtual ICollection<ParamDef> ParamDefs { get; set; }
    }
}
