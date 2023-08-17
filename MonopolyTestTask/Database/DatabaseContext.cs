using Microsoft.EntityFrameworkCore;

using MonopolyTestTask.Entities;

namespace MonopolyTestTask.Database;

public class DatabaseContext : DbContext
{
    public DbSet<Box> Boxes { get; set; }
    public DbSet<Pallet> Pallets { get; set; }

    private List<Box> _boxes = new List<Box>()
    {
        new Box
        {
            Id = 1,
            Width = 10,
            Length = 5,
            Height = 10,
            Weight = 10,
            ProductionDate = new DateTime(2004, 07, 07),
            PalletId = 4
        },
        new Box
        {
            Id = 2,
            Width = 10,
            Length = 8,
            Height = 10,
            Weight = 10,
            ExperationDate = new DateTime(2025, 07, 07),
            PalletId = 4
        },
        new Box
        {
            Id = 3,
            Width = 10,
            Length = 2,
            Height = 10,
            Weight = 10,
            ExperationDate = new DateTime(2010, 07, 07),
            PalletId = 3
        },
        new Box
        {
            Id = 4,
            Width = 17,
            Length = 12,
            Height = 10,
            Weight = 10,
            ProductionDate = new DateTime(2020, 04, 07),
            PalletId = 3
        },
        new Box
        {
            Id = 5,
            Width = 10,
            Length = 5,
            Height = 7,
            Weight = 10,
            ProductionDate = new DateTime(2019, 07, 07),
            PalletId = 2
        },
        new Box
        {
            Id = 6,
            Width = 10,
            Length = 10,
            Height = 10,
            Weight = 15,
            ProductionDate = new DateTime(2008, 07, 10),
            PalletId = 2
        },
        new Box
        {
            Id = 7,
            Width = 10,
            Length = 1,
            Height = 10,
            Weight = 11,
            ProductionDate = new DateTime(2015, 07, 07),
            PalletId = 1
        },
        new Box
        {
            Id = 8,
            Width = 2,
            Length = 5,
            Height = 10,
            Weight = 10,
            ProductionDate = new DateTime(2018, 07, 07),
            PalletId = 4
        },
        new Box
        {
            Id = 9,
            Width = 8,
            Length = 7,
            Height = 10,
            Weight = 10,
            ProductionDate = new DateTime(2018, 07, 07),
            PalletId = 4
        },
        new Box
        {
            Id = 10,
            Width = 10,
            Length = 5,
            Height = 10,
            Weight = 10,
            ProductionDate = new DateTime(2015, 07, 07),
            PalletId = 4
        },
        new Box
        {
            Id = 11,
            Width = 10,
            Length = 7,
            Height = 5,
            Weight = 10,
            ProductionDate = new DateTime(2015, 07, 07),
            PalletId = 1
        },
        new Box
        {
            Id = 12,
            Width = 10,
            Length = 9,
            Height = 15,
            Weight = 10,
            ProductionDate = new DateTime(2000, 07, 07),
            PalletId = 3
        },
        new Box
        {
            Id = 13,
            Width = 10,
            Length = 4,
            Height = 10,
            Weight = 10,
            ProductionDate = new DateTime(2000, 07, 07),
            PalletId = 1
        },
        new Box
        {
            Id = 14,
            Width = 11,
            Length = 5,
            Height = 10,
            Weight = 12,
            ProductionDate = new DateTime(2002, 10, 07),
            PalletId = 2
        },
        new Box
        {
            Id = 15,
            Width = 12,
            Length = 5,
            Height = 10,
            Weight = 11,
            ProductionDate = new DateTime(2001, 07, 07),
            PalletId = 1
        },
    };
    private List<Pallet> _pallets = new List<Pallet>()
    {
        new Pallet
        {
            Id = 1,
            Width = 40,
            Length = 50,
            Height = 40,
        },
        new Pallet
        {
            Id = 2,
            Width = 40,
            Length = 50,
            Height = 40,
        },
        new Pallet
        {
            Id = 3,
            Width = 40,
            Length = 50,
            Height = 40,
        },
        new Pallet
        {
            Id = 4,
            Width = 40,
            Length = 50,
            Height = 40,
        }
    };

    public DatabaseContext(DbContextOptions<DatabaseContext> contextOptions) : base(contextOptions)
    {
        if (Database.IsSqlite())
            Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pallet>()
            .Navigation(x => x.Boxes)
            .AutoInclude();

        modelBuilder.Entity<Box>()
            .HasData(_boxes);

        modelBuilder.Entity<Pallet>()
            .HasData(_pallets);


        base.OnModelCreating(modelBuilder);
    }
}

