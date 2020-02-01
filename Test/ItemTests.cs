using System;
using Xunit;
using Shouldly;
using Inventory;

namespace Test
{
    public class ItemTests
    {
        [Fact]
        public void NormalTestQuality()
        {
            var normalItem = new NormalItem(4,5);
            normalItem.EndOfDayUpdate();
            normalItem.Quality.ShouldBe(4);
        }

        [Fact]
        public void NormalTestSellin()
        {
            var normalItem = new NormalItem(4, 5);
            normalItem.EndOfDayUpdate();
            normalItem.SellIn.ShouldBe(3);
        }

        [Fact]
        public void NormalTestQualityNotBelowZero()
        {
            var normalItem = new NormalItem(4, 0);
            normalItem.EndOfDayUpdate();
            normalItem.Quality.ShouldBe(0);
        }

        [Fact]
        public void NormalTestQualityDecreasesTwiceAsFastWhenSellinNegative()
        {
            var normalItem = new NormalItem(0, 4);
            normalItem.EndOfDayUpdate();
            normalItem.Quality.ShouldBe(2);
        }

        [Fact]
        public void AgedBrieTestQuality()
        {
            var agedBrie = new AgedBrie(4, 5);
            agedBrie.EndOfDayUpdate();
            agedBrie.Quality.ShouldBe(6);
        }

        [Fact]
        public void AgedBrieTestMaximumQuality()
        {
            var agedBrie = new AgedBrie(4, 50);
            agedBrie.EndOfDayUpdate();
            agedBrie.Quality.ShouldBe(50);
        }
    }
}
