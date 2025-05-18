using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class Measurement
    {
        public Measurement()
        {
            MeasureUnits = new HashSet<MeasureUnit>();
        }

        public int IdMeasurement { get; set; }
        public string SysName { get; set; } = null!;
        public string Caption { get; set; } = null!;

        public virtual ICollection<MeasureUnit> MeasureUnits { get; set; }
    }
}
