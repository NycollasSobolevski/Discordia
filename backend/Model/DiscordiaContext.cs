using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Model;

public partial class DiscordiaContext : DbContext
{
    public DiscordiaContext()
    {
    }

    public DiscordiaContext(DbContextOptions<DiscordiaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Forum> Forums { get; set; }

    public virtual DbSet<Func> Funcs { get; set; }

    public virtual DbSet<Like> Likes { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Subscribed> Subscribeds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-0018C\\SQLEXPRESS;Initial Catalog=Discordia;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3213E83F2C1F444F");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Comment1)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("comment");
            entity.Property(e => e.IdPerson).HasColumnName("id_person");
            entity.Property(e => e.IdPost).HasColumnName("id_post");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__id_per__42E1EEFE");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Comments)
                .HasForeignKey(d => d.IdPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Comments__id_pos__43D61337");
        });

        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forum__3213E83F72A7B6A0");

            entity.ToTable("Forum");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Created)
                .HasColumnType("date")
                .HasColumnName("created");
            entity.Property(e => e.CreatorId).HasColumnName("creator_id");
            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Creator).WithMany(p => p.Forums)
                .HasForeignKey(d => d.CreatorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_creator_ID");
        });

        modelBuilder.Entity<Func>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Funcs__3213E83F25505ADF");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Like>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Likes__3213E83F1956B038");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdPerson).HasColumnName("id_person");
            entity.Property(e => e.IdPost).HasColumnName("id_post");
            entity.Property(e => e.Positive).HasColumnName("positive");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Likes)
                .HasForeignKey(d => d.IdPerson)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Likes__id_person__3F115E1A");

            entity.HasOne(d => d.IdPostNavigation).WithMany(p => p.Likes)
                .HasForeignKey(d => d.IdPost)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Likes__id_post__40058253");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3213E83FE6EB4F05");

            entity.ToTable("Permission");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdFuncs).HasColumnName("id_funcs");
            entity.Property(e => e.IdPosition).HasColumnName("id_position");

            entity.HasOne(d => d.IdFuncsNavigation).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.IdFuncs)
                .HasConstraintName("FK__Permissio__id_fu__31B762FC");

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.Permissions)
                .HasForeignKey(d => d.IdPosition)
                .HasConstraintName("FK__Permissio__id_po__32AB8735");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3213E83FDE9957D5");

            entity.ToTable("Person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birth)
                .HasColumnType("date")
                .HasColumnName("birth");
            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Photo)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("photo");
            entity.Property(e => e.Salt)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("salt");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Position__3213E83F9C2C096A");

            entity.ToTable("Position");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdForum).HasColumnName("id_forum");
            entity.Property(e => e.Name)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdForumNavigation).WithMany(p => p.Positions)
                .HasForeignKey(d => d.IdForum)
                .HasConstraintName("FK__Position__id_for__2EDAF651");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3213E83F5A0F31D8");

            entity.ToTable("Post");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Attachment).HasColumnName("attachment");
            entity.Property(e => e.Content)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("date")
                .HasColumnName("createdAt");
            entity.Property(e => e.IdCreator).HasColumnName("id_creator");
            entity.Property(e => e.IdForum).HasColumnName("id_forum");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.IdCreatorNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdCreator)
                .HasConstraintName("FK__Post__id_creator__3C34F16F");

            entity.HasOne(d => d.IdForumNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdForum)
                .HasConstraintName("FK__Post__id_forum__3B40CD36");
        });

        modelBuilder.Entity<Subscribed>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Subscrib__3213E83F25E075CD");

            entity.ToTable("Subscribed");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IdForum).HasColumnName("id_forum");
            entity.Property(e => e.IdPerson).HasColumnName("id_person");
            entity.Property(e => e.IdPosition).HasColumnName("id_position");

            entity.HasOne(d => d.IdForumNavigation).WithMany(p => p.Subscribeds)
                .HasForeignKey(d => d.IdForum)
                .HasConstraintName("FK__Subscribe__id_fo__37703C52");

            entity.HasOne(d => d.IdPersonNavigation).WithMany(p => p.Subscribeds)
                .HasForeignKey(d => d.IdPerson)
                .HasConstraintName("FK__Subscribe__id_pe__3587F3E0");

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.Subscribeds)
                .HasForeignKey(d => d.IdPosition)
                .HasConstraintName("FK__Subscribe__id_po__367C1819");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
