using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Aggregates;
using ACME.LearningCenterPlatform.API.Publishing.Domain.Model.Entities;
using ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ACME.LearningCenterPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Publishing Context

        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(30);

        builder.Entity<Tutorial>().HasKey(t => t.Id);
        builder.Entity<Tutorial>().Property(t => t.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Tutorial>().Property(t => t.Title).IsRequired().HasMaxLength(50);
        builder.Entity<Tutorial>().Property(t => t.Summary).HasMaxLength(240);

        builder.Entity<Asset>().HasDiscriminator(a => a.Type);
        builder.Entity<Asset>().HasKey(p => p.Id);
        builder.Entity<Asset>().HasDiscriminator<string>("asset_type")
            .HasValue<Asset>("asset_base")
            .HasValue<ImageAsset>("asset_image")
            .HasValue<VideoAsset>("asset_video")
            .HasValue<ReadableContentAsset>("asset_readable_content");

        builder.Entity<Asset>().OwnsOne(i => i.AssetIdentifier,
            ai =>
            {
                ai.WithOwner().HasForeignKey("Id");
                ai.Property(p => p.Identifier).HasColumnName("AssetIdentifier");
            });
        builder.Entity<ImageAsset>().Property(p => p.ImageUri).IsRequired();
        builder.Entity<VideoAsset>().Property(p => p.VideoUri).IsRequired();
        builder.Entity<ReadableContentAsset>().Property(p => p.ReadableContent).IsRequired();

        builder.Entity<Tutorial>().HasMany(t => t.Assets);

        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}