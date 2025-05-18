using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class ParamCategory1
    {
        public ParamCategory1()
        {
            ParamCategories = new HashSet<ParamCategory>();
        }

        public int IdParamCategory { get; set; }
        public string Name { get; set; } = null!;
        public int CategoryOrder { get; set; }

        public virtual ICollection<ParamCategory> ParamCategories { get; set; }
    }
}
