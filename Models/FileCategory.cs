using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class FileCategory
    {
        public FileCategory()
        {
            Files = new HashSet<File>();
        }

        public int IdFileCategory { get; set; }
        public string SysName { get; set; } = null!;
        public string Caption { get; set; } = null!;
        public bool? IsUnique { get; set; }
        public int? IdIcon { get; set; }
        public bool IsAutonomous { get; set; }

        public virtual ICollection<File> Files { get; set; }
    }
}
