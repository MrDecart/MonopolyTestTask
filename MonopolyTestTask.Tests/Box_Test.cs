using MonopolyTestTask.Entities;

using Xunit;

namespace MonopolyTestTask.Tests
{
    public class Box_Test
    {

        [Fact]
        public void ExpirationDate_ProductionDate_Exists()
        {
            var result = new Box
            {
                ProductionDate = DateTime.Today
            };

            Assert.Equal(DateTime.Today.AddDays(100).Date, result.ExperationDate);
        }

        [Fact]
        public void ExpirationDate_ProductionDate_Not_Exists()
        {
            var result = new Box
            {
                ExperationDate = new DateTime(2000, 07, 07),
                ProductionDate = null
            };

            Assert.Equal(new DateTime(2000, 07, 07), result.ExperationDate);
        }

        [Fact]
        public void Volume_Returns_1000()
        {
            var result = new Box
            {
                Length = 10,
                Height = 10,
                Width = 10,
            };

            Assert.Equal(1000, result.Volume);
        }
    }
}
