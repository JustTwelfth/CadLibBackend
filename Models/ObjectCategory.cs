using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    /// <summary>
    /// Категории объектов
    /// </summary>
    public partial class ObjectCategory
    {
        public ObjectCategory()
        {
            CatTableDefs = new HashSet<CatTableDef>();
            ObjectsShadows = new HashSet<ObjectsShadow>();
            ParametersDefaults = new HashSet<ParametersDefault>();
        }

        public int IdObjectCategory { get; set; }
        public string Name { get; set; } = null!;
        public string Caption { get; set; } = null!;
        public int? IdIcon { get; set; }
        public short? IsNameCalculated { get; set; }
        public string? NameFormula { get; set; }

        public virtual ICollection<CatTableDef> CatTableDefs { get; set; }
        public virtual ICollection<ObjectsShadow> ObjectsShadows { get; set; }
        public virtual ICollection<ParametersDefault> ParametersDefaults { get; set; }
    }
}
