using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class MeasureUnit
    {
        public MeasureUnit()
        {
            ParamDefIdMeasureUnitBaseNavigations = new HashSet<ParamDef>();
            ParamDefIdMeasureUnitNavigations = new HashSet<ParamDef>();
        }

        public int IdMeasureUnit { get; set; }
        public int IdMeasurement { get; set; }
        public string SysName { get; set; } = null!;
        public string? LongName { get; set; }
        public string? ShortName { get; set; }
        public double? Coefficient { get; set; }
        public string? Comment { get; set; }
        public string? ToBaseFunction { get; set; }
        public string? FromBaseFunction { get; set; }

        public virtual Measurement IdMeasurementNavigation { get; set; } = null!;
        public virtual ICollection<ParamDef> ParamDefIdMeasureUnitBaseNavigations { get; set; }
        public virtual ICollection<ParamDef> ParamDefIdMeasureUnitNavigations { get; set; }
    }
}
