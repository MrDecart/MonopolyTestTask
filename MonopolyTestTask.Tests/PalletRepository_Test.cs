using Microsoft.EntityFrameworkCore;

using MonopolyTestTask.Database;
using MonopolyTestTask.Entities;

using Xunit;

namespace MonopolyTestTask.Tests;

public class PalletRepository_Test
{
    private readonly List<Box> _boxes = new List<Box>()
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
    private readonly List<Pallet> _pallets = new List<Pallet>()
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

    private DbContextOptions<DatabaseContext> _options;
    public PalletRepository_Test()
    {
        _options = new DbContextOptionsBuilder<DatabaseContext>()
            .UseInMemoryDatabase("TestDatabase")
            .Options;

        using (var context = new DatabaseContext(_options))
        {
            context.Database.EnsureDeleted();

            context.Pallets.AddRange(_pallets);
            context.Boxes.AddRange(_boxes);

            context.SaveChanges();
        }
    }

    [Fact]
    public void GetAllByFilter_Returns_3_Groups_Test()
    {
        using var context = new DatabaseContext(_options);
        var palletRepository = new PalletRepository(context);

        var result = palletRepository.GetAllByFilter();

        Assert.Equal(3, result.Count);
        Assert.Equal(2, result[0].Count);
        Assert.True(result[0][0].ExperationDate < result[1][0].ExperationDate);
        Assert.True(result[0][1].Weight > result[0][0].Weight);
    }

    [Fact]
    public void TopPalets_Return_3_Pallets_Test()
    {
        using var context = new DatabaseContext(_options);
        var palletRepository = new PalletRepository(context);

        var result = palletRepository.TopPalets();

        Assert.Equal(3, result.Count);
        Assert.True(result[0].Volume < result[1].Volume);
        Assert.True(result[1].Volume < result[2].Volume);

        foreach (var pallet in context.Pallets)
        {
            var pal = result.FirstOrDefault(x => x.Id == pallet.Id);

            if (pallet.Id == 1)
                Assert.Null(pal);
            else
                Assert.NotNull(pal);
        }
    }
}
