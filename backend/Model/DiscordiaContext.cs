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

    public virtual DbSet<Forum> Forums { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CT-C-0018C\\SQLEXPRESS;Initial Catalog=Discordia;Integrated Security=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forum__3213E83FA2165879");

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

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Person__3213E83F81031BAA");

            entity.ToTable("Person");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Birth)
                .HasColumnType("date")
                .HasColumnName("birth");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Photo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("photo");
            entity.Property(e => e.Salt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("salt");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Post__3213E83FE7476258");

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
                .HasConstraintName("FK__Post__id_creator__5070F446");

            entity.HasOne(d => d.IdForumNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.IdForum)
                .HasConstraintName("FK__Post__id_forum__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
