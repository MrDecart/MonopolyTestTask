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

        [Fact]
        public void AddBox_Valid_Box_Added_Into_Collection_Test()
        {
            var box = new Box { Id = 1, Height = 10, Width = 10 };
            var pallet = new Pallet { Height = 10, Width = 100 };

            pallet.AddBox(box);
            var resultBox = pallet.Boxes.ToList();

            Assert.Equal(1, pallet.Boxes.Count);
            Assert.Equal(resultBox[0].Id, box.Id);
        }

        [Theory]
        [InlineData("Width", 1000, 10)]
        [InlineData("Height", 10, 1000)]
        
        public void AddBox_Invalid_Box_Throws_ArgumentOutOfRangeException_Test(string argument, int boxWidth, int boxHeight)
        {
            var box = new Box { Id = 1, Height = boxHeight, Width = boxWidth };
            var pallet = new Pallet { Height = 10, Width = 100 };


            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => pallet.AddBox(box));
            Assert.Equal($"{argument} of box is greater than {argument} of pallet (Parameter 'box')", exception.Message);
        }
    }
}

