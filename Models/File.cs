using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class File
    {
        public File()
        {
            Expertises = new HashSet<Expertise>();
            FileParametersStrs = new HashSet<FileParametersStr>();
            IdObjects = new HashSet<ObjectsShadow>();
        }

        public int IdFile { get; set; }
        public int IdFileType { get; set; }
        public int IdFileCategory { get; set; }
        public string FileName { get; set; } = null!;
        public DateTime? ModifiedDate { get; set; }
        public Guid? Uid { get; set; }
        public byte[]? Data { get; set; }
        public bool IsExternal { get; set; }
        public string? Url { get; set; }

        public virtual FileCategory IdFileCategoryNavigation { get; set; } = null!;
        public virtual FileType IdFileTypeNavigation { get; set; } = null!;
        public virtual ICollection<Expertise> Expertises { get; set; }
        public virtual ICollection<FileParametersStr> FileParametersStrs { get; set; }

        public virtual ICollection<ObjectsShadow> IdObjects { get; set; }
    }
}
