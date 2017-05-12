namespace BC.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BcModel : DbContext
    {
        public BcModel()
            : base("name=BcModel")
        {
        }

        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>()
                .Property(e => e.Desc)
                .IsUnicode(false);

            modelBuilder.Entity<Log>()
                .Property(e => e.Data)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.Href)
                .IsUnicode(false);

            modelBuilder.Entity<Menu>()
                .Property(e => e.IconCss)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .Property(e => e.Href)
                .IsUnicode(false);

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.Roles)
                .WithMany(e => e.Permissions)
                .Map(m => m.ToTable("RolePermission").MapLeftKey("PermissionId").MapRightKey("RoleId"));

            modelBuilder.Entity<Permission>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Permissions)
                .Map(m => m.ToTable("UserPermission").MapLeftKey("PermissionId").MapRightKey("UserId"));

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserPwd)
                .IsUnicode(false);
        }
    }
}
