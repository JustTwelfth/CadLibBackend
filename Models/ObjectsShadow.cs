using System;
using System.Collections.Generic;

namespace CadLibBackend.Models
{
    public partial class ObjectsShadow
    {
        public ObjectsShadow()
        {
            Expertises = new HashSet<Expertise>();
            InverseIdParentObjectNavigation = new HashSet<ObjectsShadow>();
            ParametersDbls = new HashSet<ParametersDbl>();
            ParametersInts = new HashSet<ParametersInt>();
            ParametersStrs = new HashSet<ParametersStr>();
            IdFiles = new HashSet<File>();
        }

        public int IdObject { get; set; }
        public int? IdParentObject { get; set; }
        public int IdElementLocal { get; set; }
        public int IdObjectCategory { get; set; }
        public string Name { get; set; } = null!;
        public int? Tag { get; set; }
        public int IdSysStatus { get; set; }
        public int? IdSysUser { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? Uid { get; set; }
        public int NElementOrder { get; set; }
        public int? IsDeleted { get; set; }

        public virtual ObjectCategory IdObjectCategoryNavigation { get; set; } = null!;
        public virtual ObjectsShadow? IdParentObjectNavigation { get; set; }
        public virtual ICollection<Expertise> Expertises { get; set; }
        public virtual ICollection<ObjectsShadow> InverseIdParentObjectNavigation { get; set; }
        public virtual ICollection<ParametersDbl> ParametersDbls { get; set; }
        public virtual ICollection<ParametersInt> ParametersInts { get; set; }
        public virtual ICollection<ParametersStr> ParametersStrs { get; set; }

        public virtual ICollection<File> IdFiles { get; set; }
    }
}
