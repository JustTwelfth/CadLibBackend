using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CadLibBackend.Models;
using System.IO;
using FileModel = CadLibBackend.Models.File;
namespace CadLibBackend.Data
{
    public partial class CadLibDbContext : DbContext
    {
        public CadLibDbContext()
        {
        }

        public CadLibDbContext(DbContextOptions<CadLibDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CatTableDef> CatTableDefs { get; set; } = null!;
        public virtual DbSet<Expertise> Expertises { get; set; } = null!;
        public virtual DbSet<FileModel> Files { get; set; } = null!;
        public virtual DbSet<FileCategory> FileCategories { get; set; } = null!;
        public virtual DbSet<FileParametersStr> FileParametersStrs { get; set; } = null!;
        public virtual DbSet<FileType> FileTypes { get; set; } = null!;
        public virtual DbSet<MeasureUnit> MeasureUnits { get; set; } = null!;
        public virtual DbSet<Measurement> Measurements { get; set; } = null!;
        public virtual DbSet<ObjectCategory> ObjectCategories { get; set; } = null!;
        public virtual DbSet<ObjectsShadow> ObjectsShadows { get; set; } = null!;
        public virtual DbSet<ParamCategory> ParamCategories { get; set; } = null!;
        public virtual DbSet<ParamCategory1> ParamCategories1 { get; set; } = null!;
        public virtual DbSet<ParamDef> ParamDefs { get; set; } = null!;
        public virtual DbSet<ParamTable> ParamTables { get; set; } = null!;
        public virtual DbSet<ParamType> ParamTypes { get; set; } = null!;
        public virtual DbSet<ParamValue> ParamValues { get; set; } = null!;
        public virtual DbSet<ParametersDbl> ParametersDbls { get; set; } = null!;
        public virtual DbSet<ParametersDefault> ParametersDefaults { get; set; } = null!;
        public virtual DbSet<ParametersInt> ParametersInts { get; set; } = null!;
        public virtual DbSet<ParametersStr> ParametersStrs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=newtest;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Cyrillic_General_BIN");

            modelBuilder.Entity<CatTableDef>(entity =>
            {
                entity.HasKey(e => new { e.IdObjectCategory, e.IdParamDef });

                entity.Property(e => e.IdObjectCategory).HasColumnName("idObjectCategory");

                entity.Property(e => e.IdParamDef).HasColumnName("idParamDef");

                entity.HasOne(d => d.IdObjectCategoryNavigation)
                    .WithMany(p => p.CatTableDefs)
                    .HasForeignKey(d => d.IdObjectCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatTableDefs_REF_CAT");

                entity.HasOne(d => d.IdParamDefNavigation)
                    .WithMany(p => p.CatTableDefs)
                    .HasForeignKey(d => d.IdParamDef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CatTableDefs_REF_PAR");
            });

            modelBuilder.Entity<Expertise>(entity =>
            {
                entity.HasKey(e => e.IdNode)
                    .HasName("PK__Expertis__AD40C0265496F5FD");

                entity.ToTable("Expertise");

                entity.Property(e => e.IdNode).HasColumnName("idNode");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.DocumentFileName).HasMaxLength(50);

                entity.Property(e => e.HazardCategory).HasMaxLength(50);

                entity.Property(e => e.IdFile).HasColumnName("idFile");

                entity.Property(e => e.IdObject).HasColumnName("idObject");

                entity.Property(e => e.Message).HasMaxLength(1024);

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.HasOne(d => d.IdFileNavigation)
                    .WithMany(p => p.Expertises)
                    .HasForeignKey(d => d.IdFile)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_Expertise_idFile");

                entity.HasOne(d => d.IdObjectNavigation)
                    .WithMany(p => p.Expertises)
                    .HasForeignKey(d => d.IdObject)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_Expertise_idObject");
            });

            modelBuilder.Entity<FileModel>(entity =>
            {
                entity.HasKey(e => e.IdFile)
                    .HasName("PK__Files__775AFE72B539EE34");

                entity.HasIndex(e => e.Uid, "idx_Files_UID")
                    .IsUnique();

                entity.Property(e => e.IdFile)
                    .ValueGeneratedNever()
                    .HasColumnName("idFile");

                entity.Property(e => e.Data).HasColumnType("image");

                entity.Property(e => e.FileName).HasMaxLength(255);

                entity.Property(e => e.IdFileCategory).HasColumnName("idFileCategory");

                entity.Property(e => e.IdFileType).HasColumnName("idFileType");

                entity.Property(e => e.IsExternal).HasColumnName("isExternal");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Url)
                    .HasMaxLength(4000)
                    .HasColumnName("URL");

                entity.HasOne(d => d.IdFileCategoryNavigation)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.IdFileCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILES_REFERENCE_FILECATE");

                entity.HasOne(d => d.IdFileTypeNavigation)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.IdFileType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FILES_REFERENCE_FILETYPE");
            });

            modelBuilder.Entity<FileCategory>(entity =>
            {
                entity.HasKey(e => e.IdFileCategory)
                    .HasName("PK__FileCate__036D684B2A3DA66F");

                entity.HasIndex(e => e.SysName, "IDX_FILECAT_SYSNAME")
                    .IsUnique();

                entity.Property(e => e.IdFileCategory)
                    .ValueGeneratedNever()
                    .HasColumnName("idFileCategory");

                entity.Property(e => e.Caption).HasMaxLength(128);

                entity.Property(e => e.IdIcon).HasColumnName("idIcon");

                entity.Property(e => e.IsUnique)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.SysName).HasMaxLength(32);
            });

            modelBuilder.Entity<FileParametersStr>(entity =>
            {
                entity.HasKey(e => new { e.IdParamDef, e.IdFile });

                entity.ToTable("FileParameters_STR");

                entity.HasIndex(e => e.IdFile, "ByFile");

                entity.Property(e => e.IdParamDef).HasColumnName("idParamDef");

                entity.Property(e => e.IdFile).HasColumnName("idFile");

                entity.Property(e => e.Value).HasMaxLength(440);

                entity.HasOne(d => d.IdFileNavigation)
                    .WithMany(p => p.FileParametersStrs)
                    .HasForeignKey(d => d.IdFile)
                    .HasConstraintName("FK_FP_REFERENCE_FILES");

                entity.HasOne(d => d.IdParamDefNavigation)
                    .WithMany(p => p.FileParametersStrs)
                    .HasForeignKey(d => d.IdParamDef)
                    .HasConstraintName("FK_FP_REFERENCE_PARAMDEF");
            });

            modelBuilder.Entity<FileType>(entity =>
            {
                entity.HasKey(e => e.IdFileType)
                    .HasName("PK__FileType__232484AE983CF200");

                entity.HasIndex(e => e.Extension, "idx_FileTypes_Extension")
                    .IsUnique();

                entity.Property(e => e.IdFileType)
                    .ValueGeneratedNever()
                    .HasColumnName("idFileType");

                entity.Property(e => e.Caption).HasMaxLength(128);

                entity.Property(e => e.Extension)
                    .HasMaxLength(16)
                    .UseCollation("Cyrillic_General_CI_AS");
            });

            modelBuilder.Entity<MeasureUnit>(entity =>
            {
                entity.HasKey(e => e.IdMeasureUnit);

                entity.Property(e => e.IdMeasureUnit)
                    .ValueGeneratedNever()
                    .HasColumnName("idMeasureUnit");

                entity.Property(e => e.FromBaseFunction).HasMaxLength(420);

                entity.Property(e => e.IdMeasurement).HasColumnName("idMeasurement");

                entity.Property(e => e.LongName).HasMaxLength(128);

                entity.Property(e => e.ShortName).HasMaxLength(32);

                entity.Property(e => e.SysName).HasMaxLength(64);

                entity.Property(e => e.ToBaseFunction).HasMaxLength(420);

                entity.HasOne(d => d.IdMeasurementNavigation)
                    .WithMany(p => p.MeasureUnits)
                    .HasForeignKey(d => d.IdMeasurement)
                    .HasConstraintName("FK_MeasureUnits_MeasurementId");
            });

            modelBuilder.Entity<Measurement>(entity =>
            {
                entity.HasKey(e => e.IdMeasurement)
                    .HasName("PK__Measurem__281315D332F1A4FC");

                entity.Property(e => e.IdMeasurement)
                    .ValueGeneratedNever()
                    .HasColumnName("idMeasurement");

                entity.Property(e => e.Caption).HasMaxLength(128);

                entity.Property(e => e.SysName).HasMaxLength(64);
            });

            modelBuilder.Entity<ObjectCategory>(entity =>
            {
                entity.HasKey(e => e.IdObjectCategory)
                    .HasName("PK__ObjectCa__B77A6E0A7B2D0859");

                entity.HasComment("Категории объектов");

                entity.Property(e => e.IdObjectCategory)
                    .ValueGeneratedNever()
                    .HasColumnName("idObjectCategory");

                entity.Property(e => e.Caption).HasMaxLength(255);

                entity.Property(e => e.IdIcon).HasColumnName("idIcon");

                entity.Property(e => e.Name).HasMaxLength(64);
            });

            modelBuilder.Entity<ObjectsShadow>(entity =>
            {
                entity.HasKey(e => e.IdObject)
                    .HasName("PK__Objects__C3CB079C83384D2E");

                entity.ToTable("ObjectsShadow");

                entity.HasIndex(e => e.Uid, "IDX_OBJECTS_UID")
                    .IsUnique();

                entity.HasIndex(e => e.IdParentObject, "IDX_OBJ_PARENT");

                entity.Property(e => e.IdObject)
                    .ValueGeneratedNever()
                    .HasColumnName("idObject");

                entity.Property(e => e.IdElementLocal).HasColumnName("idElementLocal");

                entity.Property(e => e.IdObjectCategory).HasColumnName("idObjectCategory");

                entity.Property(e => e.IdParentObject).HasColumnName("idParentObject");

                entity.Property(e => e.IdSysStatus)
                    .HasColumnName("idSysStatus")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IdSysUser).HasColumnName("idSysUser");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.NElementOrder).HasColumnName("nElementOrder");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.Uid)
                    .HasColumnName("UID")
                    .HasDefaultValueSql("(newid())");

                entity.HasOne(d => d.IdObjectCategoryNavigation)
                    .WithMany(p => p.ObjectsShadows)
                    .HasForeignKey(d => d.IdObjectCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OBJECTS_REFERENCE_CATEGORI");

                entity.HasOne(d => d.IdParentObjectNavigation)
                    .WithMany(p => p.InverseIdParentObjectNavigation)
                    .HasForeignKey(d => d.IdParentObject)
                    .HasConstraintName("FK_OBJECTS_REFERENCE_OBJECTS");

                entity.HasMany(d => d.IdFiles)
                    .WithMany(p => p.IdObjects)
                    .UsingEntity<Dictionary<string, object>>(
                        "ObjectFile",
                        l => l.HasOne<FileModel>().WithMany().HasForeignKey("IdFile").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ObjectFiles_REF_FILES"),
                        r => r.HasOne<ObjectsShadow>().WithMany().HasForeignKey("IdObject").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK_ObjectFiles_REF_OBJECTS"),
                        j =>
                        {
                            j.HasKey("IdObject", "IdFile");

                            j.ToTable("ObjectFiles");

                            j.HasIndex(new[] { "IdFile" }, "idx_ObjectFiles_idFile");

                            j.IndexerProperty<int>("IdObject").HasColumnName("idObject");

                            j.IndexerProperty<int>("IdFile").HasColumnName("idFile");
                        });
            });

            modelBuilder.Entity<ParamCategory>(entity =>
            {
                entity.HasKey(e => new { e.IdParamCategory, e.IdParamDef });

                entity.Property(e => e.IdParamCategory).HasColumnName("idParamCategory");

                entity.Property(e => e.IdParamDef).HasColumnName("idParamDef");

                entity.Property(e => e.ParamOrder).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.HasOne(d => d.IdParamCategoryNavigation)
                    .WithMany(p => p.ParamCategories)
                    .HasForeignKey(d => d.IdParamCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAMCAT_REFERENCE_CATEGORY");

                entity.HasOne(d => d.IdParamDefNavigation)
                    .WithMany(p => p.ParamCategories)
                    .HasForeignKey(d => d.IdParamDef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAMCAT_REFERENCE_PARAMDEF");
            });

            modelBuilder.Entity<ParamCategory1>(entity =>
            {
                entity.HasKey(e => e.IdParamCategory)
                    .HasName("PK__ParamCat__AD4DFFCBA77DBF71");

                entity.ToTable("ParamCategory");

                entity.HasIndex(e => e.Name, "IDX_OBJECTS_UID")
                    .IsUnique();

                entity.Property(e => e.IdParamCategory)
                    .ValueGeneratedNever()
                    .HasColumnName("idParamCategory");

                entity.Property(e => e.CategoryOrder).HasDefaultValueSql("(0x7FFFFFFF)");

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<ParamDef>(entity =>
            {
                entity.HasKey(e => e.IdParamDef)
                    .HasName("PK__ParamDef__CA48961307BC3BBC");

                entity.HasIndex(e => e.Name, "IDX_PARAMDEFS_NAME")
                    .IsUnique();

                entity.HasIndex(e => e.IdParamTable, "IDX_ParamDefs_idParamTable");

                entity.Property(e => e.IdParamDef)
                    .ValueGeneratedNever()
                    .HasColumnName("idParamDef");

                entity.Property(e => e.Accuracy).HasDefaultValueSql("((-1))");

                entity.Property(e => e.Caption).HasMaxLength(255);

                entity.Property(e => e.DefaultValue).HasMaxLength(440);

                entity.Property(e => e.DefaultValueComment).HasDefaultValueSql("('')");

                entity.Property(e => e.IdDependency).HasColumnName("idDependency");

                entity.Property(e => e.IdMeasureUnit).HasColumnName("idMeasureUnit");

                entity.Property(e => e.IdMeasureUnitBase).HasColumnName("idMeasureUnitBase");

                entity.Property(e => e.IdParamTable).HasColumnName("idParamTable");

                entity.Property(e => e.IdType).HasColumnName("idType");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.ValueType).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.IdMeasureUnitNavigation)
                    .WithMany(p => p.ParamDefIdMeasureUnitNavigations)
                    .HasForeignKey(d => d.IdMeasureUnit)
                    .HasConstraintName("FK_PARAMDEF_REFERENCE_MEASURE_UNIT");

                entity.HasOne(d => d.IdMeasureUnitBaseNavigation)
                    .WithMany(p => p.ParamDefIdMeasureUnitBaseNavigations)
                    .HasForeignKey(d => d.IdMeasureUnitBase)
                    .HasConstraintName("FK_PARAMDEF_REFERENCE_MEASURE_UNIT_BASE");

                entity.HasOne(d => d.IdParamTableNavigation)
                    .WithMany(p => p.ParamDefs)
                    .HasForeignKey(d => d.IdParamTable)
                    .HasConstraintName("FK_PARAMDEF_REFERENCE_PARAMTBL");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.ParamDefs)
                    .HasForeignKey(d => d.IdType)
                    .HasConstraintName("FK_PARAMDEF_REFERENCE_PARAMTYP");
            });

            modelBuilder.Entity<ParamTable>(entity =>
            {
                entity.HasKey(e => e.IdParamTable)
                    .HasName("PK__ParamTab__A7698693463BBD8F");

                entity.Property(e => e.IdParamTable)
                    .ValueGeneratedNever()
                    .HasColumnName("idParamTable");

                entity.Property(e => e.TableDescription).HasMaxLength(128);

                entity.Property(e => e.TableName).HasMaxLength(64);
            });

            modelBuilder.Entity<ParamType>(entity =>
            {
                entity.HasKey(e => e.IdType)
                    .HasName("PK__ParamTyp__4BB98BC69442AFD9");

                entity.Property(e => e.IdType)
                    .ValueGeneratedNever()
                    .HasColumnName("idType");

                entity.Property(e => e.TypeCaption).HasMaxLength(128);

                entity.Property(e => e.TypeName).HasMaxLength(64);
            });

            modelBuilder.Entity<ParamValue>(entity =>
            {
                entity.HasKey(e => e.IdParamValue)
                    .HasName("PK__ParamVal__1AA9126B7DF1510B");

                entity.Property(e => e.IdParamValue)
                    .ValueGeneratedNever()
                    .HasColumnName("idParamValue");

                entity.Property(e => e.Comment).HasMaxLength(1024);

                entity.Property(e => e.IdParamDef).HasColumnName("idParamDef");

                entity.Property(e => e.Value).HasMaxLength(440);

                entity.HasOne(d => d.IdParamDefNavigation)
                    .WithMany(p => p.ParamValues)
                    .HasForeignKey(d => d.IdParamDef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAMVAL_REFERENCE_PARAMDEF");
            });

            modelBuilder.Entity<ParametersDbl>(entity =>
            {
                entity.HasKey(e => new { e.IdParamDef, e.IdObject });

                entity.ToTable("Parameters_DBL");

                entity.HasIndex(e => new { e.IdObject, e.IdParamDef }, "ByObject");

                entity.HasIndex(e => new { e.IdParamDef, e.Value }, "IDX_PARAM_DBL_VAL");

                entity.Property(e => e.IdParamDef).HasColumnName("idParamDef");

                entity.Property(e => e.IdObject).HasColumnName("idObject");

                entity.HasOne(d => d.IdObjectNavigation)
                    .WithMany(p => p.ParametersDbls)
                    .HasForeignKey(d => d.IdObject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAMETE_D_REFERENCE_OBJECTS");

                entity.HasOne(d => d.IdParamDefNavigation)
                    .WithMany(p => p.ParametersDbls)
                    .HasForeignKey(d => d.IdParamDef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAMETE_D_REFERENCE_PARAMDEF");
            });

            modelBuilder.Entity<ParametersDefault>(entity =>
            {
                entity.HasKey(e => new { e.IdObjectCategory, e.IdParamDef });

                entity.ToTable("ParametersDefault");

                entity.Property(e => e.IdObjectCategory).HasColumnName("idObjectCategory");

                entity.Property(e => e.IdParamDef).HasColumnName("idParamDef");

                entity.Property(e => e.Value).HasMaxLength(440);

                entity.HasOne(d => d.IdObjectCategoryNavigation)
                    .WithMany(p => p.ParametersDefaults)
                    .HasForeignKey(d => d.IdObjectCategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAMTDEF_REFERENCE_CATEGS");

                entity.HasOne(d => d.IdParamDefNavigation)
                    .WithMany(p => p.ParametersDefaults)
                    .HasForeignKey(d => d.IdParamDef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAMTDEF_REFERENCE_PARAMDEFS");
            });

            modelBuilder.Entity<ParametersInt>(entity =>
            {
                entity.HasKey(e => new { e.IdParamDef, e.IdObject });

                entity.ToTable("Parameters_INT");

                entity.HasIndex(e => new { e.IdObject, e.IdParamDef }, "ByObject");

                entity.HasIndex(e => new { e.IdParamDef, e.Value }, "IDX_PARAM_INT_VAL");

                entity.Property(e => e.IdParamDef).HasColumnName("idParamDef");

                entity.Property(e => e.IdObject).HasColumnName("idObject");

                entity.HasOne(d => d.IdObjectNavigation)
                    .WithMany(p => p.ParametersInts)
                    .HasForeignKey(d => d.IdObject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAMETE_I_REFERENCE_OBJECTS");

                entity.HasOne(d => d.IdParamDefNavigation)
                    .WithMany(p => p.ParametersInts)
                    .HasForeignKey(d => d.IdParamDef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAMETE_I_REFERENCE_PARAMDEF");
            });

            modelBuilder.Entity<ParametersStr>(entity =>
            {
                entity.HasKey(e => new { e.IdParamDef, e.IdObject });

                entity.ToTable("Parameters_STR");

                entity.HasIndex(e => new { e.IdObject, e.IdParamDef }, "ByObject");

                entity.HasIndex(e => new { e.IdParamDef, e.Value }, "IDX_PARAM_STR_VAL");

                entity.Property(e => e.IdParamDef).HasColumnName("idParamDef");

                entity.Property(e => e.IdObject).HasColumnName("idObject");

                entity.Property(e => e.Value).HasMaxLength(448);

                entity.HasOne(d => d.IdObjectNavigation)
                    .WithMany(p => p.ParametersStrs)
                    .HasForeignKey(d => d.IdObject)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAMETE_REFERENCE_OBJECTS");

                entity.HasOne(d => d.IdParamDefNavigation)
                    .WithMany(p => p.ParametersStrs)
                    .HasForeignKey(d => d.IdParamDef)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PARAMETE_REFERENCE_PARAMDEF");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
