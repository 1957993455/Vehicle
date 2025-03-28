using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Linq;
using Vehicle.App.Domain.Store;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Vehicle.App.EntityFrameworkCore.EntityFrameworkCore.EntityTypeConifg;

public class StoreEntityConfig : IEntityTypeConfiguration<StoreAggregateRoot>
{
    public void Configure(EntityTypeBuilder<StoreAggregateRoot> builder)
    {
        builder.ToTable("Stores", b => b.HasComment("门店信息表"));

        // 配置主键
        builder.HasKey(x => x.Id);

        // 配置基础信息
        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired()
            .HasComment("门店名称");

        builder.Property(x => x.StoreCode)
            .HasMaxLength(20)
            .IsRequired()
            .HasComment("门店编码");

        // 添加唯一索引
        builder.HasIndex(x => x.StoreCode)
            .IsUnique()
            .HasDatabaseName("UK_Store_Code");

        // 配置地址值对象
        builder.OwnsOne(x => x.Address, address =>
        {
            address.Property(a => a.Province)
                .HasMaxLength(100)
                .IsRequired()
                .HasComment("省");

            address.Property(a => a.City)
                .HasMaxLength(100)
                .IsRequired()
                .HasComment("市");

            address.Property(a => a.District)
                .HasMaxLength(100)
                .IsRequired()
                .HasComment("区");
            address.Property(a => a.Street)
                .HasMaxLength(100)
                .IsRequired()
                .HasComment("街道");
            address.Property(a => a.Detail)
                .HasMaxLength(200)
                .IsRequired()
                .HasComment("详细地址");
        });

        // 配置地理位置值对象
        builder.OwnsOne(x => x.Location, location =>
        {
            location.Property(l => l.Longitude)
                .HasPrecision(9, 6)
                .IsRequired()
                .HasComment("经度");
            location.Property(l => l.Latitude)
                .HasPrecision(8, 6)
                .IsRequired()
                .HasComment("纬度");

            // 添加地理位置索引
            location.HasIndex(nameof(GeoLocationValueObject.Longitude), nameof(GeoLocationValueObject.Latitude))
                .HasDatabaseName("IX_Store_Location");
        });

        // 配置运营信息
        builder.Property(x => x.Status)
            .IsRequired()
            .HasComment("门店状态");


        builder.Property(x => x.ManagerId)
            .HasComment("店长用户ID");

        // 配置扩展属性
        builder.Property(x => x.Tags)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            )
            .HasMaxLength(1000)
            .HasComment("门店标签");

        builder.Property(x => x.Description)
            .HasMaxLength(2000)
            .HasComment("门店描述");

        builder.ConfigureByConvention();
        builder.ApplyObjectExtensionMappings();
    }
}
