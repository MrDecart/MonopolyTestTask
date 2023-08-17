using MonopolyTestTask.Entities;

using Xunit;

namespace MonopolyTestTask.Tests
{
    public class Pallet_Test
    {
        [Fact]
        public void Filling_Automatic_Fields_Test()
        {
            var palette = new Pallet
            {
                Id = 1,
                Width = 10,
                Length = 10,
                Height = 10,
                Boxes = new List<Box>
                {
                    new Box
                    {
                        Id = 1,
                        Width = 10,
                        Length = 10,
                        Height = 10,
                        Weight = 10,
                        ExperationDate = new DateTime(2005, 01, 01),
                        PalletId = 1
                    },
                    new Box
                    {
                        Id = 1,
                        Width = 10,
                        Length = 10,
                        Height = 10,
                        Weight = 10,
                        ExperationDate = new DateTime(2023, 08, 16),
                        PalletId = 1
                    }

                }
            };

            Assert.Equal(50, palette.Weight);
            Assert.Equal(3000, palette.Volume);
            Assert.Equal(new DateTime(2005, 01, 01), palette.ExperationDate);
        }

        [Fact]
        public void ExpirationDate_NoBoxesInPalette_ReturnsMaxDateTime()
        {
            var palette = new Pallet
            {
                Id = 1,
                Width = 10,
                Length = 10,
                Height = 10
            };

            Assert.Equal(DateTime.MaxValue.Date, palette.ExperationDate);
        }
    }
}
