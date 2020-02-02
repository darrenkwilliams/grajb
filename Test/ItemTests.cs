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
            var normalItem = new NormalItem();
            normalItem.EndOfDayUpdate(4, 5);
            normalItem.Quality.ShouldBe(4);
        }

        [Fact]
        public void ConjuredTestQuality()
        {
            var conjuredItem = new Conjured();
            conjuredItem.EndOfDayUpdate(4, 5);
            conjuredItem.Quality.ShouldBe(3);
        }

        [Fact]
        public void SulfurasTestQuality()
        {
            var sulfurasItem = new Sulfuras();
            sulfurasItem.EndOfDayUpdate(4, 5);
            sulfurasItem.Quality.ShouldBe(5);
        }

        [Fact]
        public void BackstagePassTestQualityWhereSellinGreaterThan10()
        {
            var backstagePass = new BackstagePasses();
            backstagePass.EndOfDayUpdate(12, 5);
            backstagePass.Quality.ShouldBe(6);
        }

        [Fact]
        public void BackstagePassTestQualityWhereSellinBetween5and10()
        {
            var backstagePass = new BackstagePasses();
            backstagePass.EndOfDayUpdate(9, 5);
            backstagePass.Quality.ShouldBe(7);
        }

        [Fact]
        public void BackstagePassTestQualityWhereSellinLessThan5()
        {
            var backstagePass = new BackstagePasses();
            backstagePass.EndOfDayUpdate(4, 5);
            backstagePass.Quality.ShouldBe(8);
        }

        [Fact]
        public void BackstagePassTestQualityWhereSellinLess0()
        {
            var backstagePass = new BackstagePasses();
            backstagePass.EndOfDayUpdate(-1, 5);
            backstagePass.Quality.ShouldBe(0);
        }

        [Fact]
        public void NormalTestSellin()
        {
            var normalItem = new NormalItem();
            normalItem.EndOfDayUpdate(4, 5);
            normalItem.SellIn.ShouldBe(3);
        }

        [Fact]
        public void NormalTestQualityNotBelowZero()
        {
            var normalItem = new NormalItem();
            normalItem.EndOfDayUpdate(4, 0);
            normalItem.Quality.ShouldBe(0);
        }

        [Fact]
        public void NormalTestQualityDecreasesTwiceAsFastWhenSellinNegative()
        {
            var normalItem = new NormalItem();
            normalItem.EndOfDayUpdate(0, 4);
            normalItem.Quality.ShouldBe(2);
        }

        [Fact]
        public void AgedBrieTestQuality()
        {
            var agedBrie = new AgedBrie();
            agedBrie.EndOfDayUpdate(4, 5);
            agedBrie.Quality.ShouldBe(6);
        }

        [Fact]
        public void AgedBrieTestMaximumQuality()
        {
            var agedBrie = new AgedBrie();
            agedBrie.EndOfDayUpdate(4, 50);
            agedBrie.Quality.ShouldBe(50);
        }

        [Fact]
        public void AgedBrieTestMaximumQualityMessage()
        {
            var agedBrie = new AgedBrie();
            agedBrie.EndOfDayUpdate(4, 50);
            agedBrie.Quality.ShouldBe(50);
            var message = agedBrie.GetEndOfDayValues();
            message.ShouldContain("50");
        }

        [Fact]
        public void FactoryAgedBrieTestQuality()
        {
            var someItem = InventoryItemFactory.GetItem("Aged Brie");
            someItem.EndOfDayUpdate(4, 5);
            someItem.Quality.ShouldBe(6);
        }
    }
}
