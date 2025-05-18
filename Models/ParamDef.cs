using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class ParamDef
    {
        public ParamDef()
        {
            CatTableDefs = new HashSet<CatTableDef>();
            FileParametersStrs = new HashSet<FileParametersStr>();
            ParamCategories = new HashSet<ParamCategory>();
            ParamValues = new HashSet<ParamValue>();
            ParametersDbls = new HashSet<ParametersDbl>();
            ParametersDefaults = new HashSet<ParametersDefault>();
            ParametersInts = new HashSet<ParametersInt>();
            ParametersStrs = new HashSet<ParametersStr>();
        }

        public int IdParamDef { get; set; }
        public int? IdType { get; set; }
        public int? IdParamTable { get; set; }
        public string Name { get; set; } = null!;
        public string Caption { get; set; } = null!;
        public int? Size { get; set; }
        public int? IdDependency { get; set; }
        public short Readonly { get; set; }
        public string DefaultValue { get; set; } = null!;
        public string DefaultValueComment { get; set; } = null!;
        public int? IdMeasureUnitBase { get; set; }
        public int? IdMeasureUnit { get; set; }
        public int Accuracy { get; set; }
        public int ValueType { get; set; }

        public virtual MeasureUnit? IdMeasureUnitBaseNavigation { get; set; }
        public virtual MeasureUnit? IdMeasureUnitNavigation { get; set; }
        public virtual ParamTable? IdParamTableNavigation { get; set; }
        public virtual ParamType? IdTypeNavigation { get; set; }
        public virtual ICollection<CatTableDef> CatTableDefs { get; set; }
        public virtual ICollection<FileParametersStr> FileParametersStrs { get; set; }
        public virtual ICollection<ParamCategory> ParamCategories { get; set; }
        public virtual ICollection<ParamValue> ParamValues { get; set; }
        public virtual ICollection<ParametersDbl> ParametersDbls { get; set; }
        public virtual ICollection<ParametersDefault> ParametersDefaults { get; set; }
        public virtual ICollection<ParametersInt> ParametersInts { get; set; }
        public virtual ICollection<ParametersStr> ParametersStrs { get; set; }
    }
}
