using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class Expertise
    {
        public string? Status { get; set; }
        public DateTime? Date { get; set; }
        public string Message { get; set; } = null!;
        public string? Comment { get; set; }
        public int? IdObject { get; set; }
        public int? IdFile { get; set; }
        public int IdNode { get; set; }
        public byte[]? Image { get; set; }
        public byte[]? Document { get; set; }
        public string? DocumentFileName { get; set; }
        public string? HazardCategory { get; set; }

        public virtual File? IdFileNavigation { get; set; }
        public virtual ObjectsShadow? IdObjectNavigation { get; set; }
    }
}
