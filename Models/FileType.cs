using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class FileType
    {
        public FileType()
        {
            Files = new HashSet<File>();
        }

        public int IdFileType { get; set; }
        public string Caption { get; set; } = null!;
        public string Extension { get; set; } = null!;

        public virtual ICollection<File> Files { get; set; }
    }
}
