using System;
using System.Collections.Generic;
using BlogPost.Models;
using Microsoft.EntityFrameworkCore;
using BlogPost.Dto;

namespace BlogPost.DataContext;

public partial class BlogpostContext : DbContext
{
    public BlogpostContext()
    {
    }

    public BlogpostContext(DbContextOptions<BlogpostContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blogpost> Blogposts { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=FUOCHUNG;Initial Catalog=blogpost;Integrated Security=True;Encrypt=false;TrustServerCertificate=true; Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blogpost>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__blogpost__3213E83F2F8EFE5A");

            entity.ToTable("blogpost");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Author)
                .HasMaxLength(155)
                .HasColumnName("author");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.Featuredimage)
                .HasMaxLength(155)
                .HasColumnName("featuredimage");
            entity.Property(e => e.Heading)
                .HasMaxLength(300)
                .HasColumnName("heading");
            entity.Property(e => e.Pagetitle)
                .HasMaxLength(300)
                .HasColumnName("pagetitle");
            entity.Property(e => e.Publisheddate)
                .HasColumnType("datetime")
                .HasColumnName("publisheddate");
            entity.Property(e => e.Shortdescription)
                .HasMaxLength(300)
                .HasColumnName("shortdescription");
            entity.Property(e => e.Urlhandle)
                .HasMaxLength(155)
                .HasColumnName("urlhandle");
            entity.Property(e => e.Visible).HasColumnName("visible");

            entity.HasMany(d => d.Tags).WithMany(p => p.Blogposts)
                .UsingEntity<Dictionary<string, object>>(
                    "Blogposttag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("Tagid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_tag"),
                    l => l.HasOne<Blogpost>().WithMany()
                        .HasForeignKey("Blogpostid")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("fk_blogpost"),
                    j =>
                    {
                        j.HasKey("Blogpostid", "Tagid").HasName("PK__blogpost__1092D8DCAE7AA27B");
                        j.ToTable("blogposttag");
                        j.IndexerProperty<int>("Blogpostid").HasColumnName("blogpostid");
                        j.IndexerProperty<int>("Tagid").HasColumnName("tagid");
                    });
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tag__3213E83FC6ACEF8D");

            entity.ToTable("tag");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Displayname)
                .HasMaxLength(300)
                .HasColumnName("displayname");
            entity.Property(e => e.Name)
                .HasMaxLength(155)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public DbSet<BlogPost.Dto.tagDto>? tagDto { get; set; }
}
