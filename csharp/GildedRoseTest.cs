using NUnit.Framework;
using System.Collections.Generic;

namespace csharp
{
    [TestFixture]
    public class GildedRoseTest
    {
        [Test(Description = "Once the sell by date not passed, Quality degrades by 1")]
        public void UpdateQuality_SellInNotPassed_QualityDecreasedByOne()
        {
            var items = new List<Item> { new Item { Name = "Some", SellIn = 10, Quality = 10 } };
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();

            Assert.AreEqual(9, items[0].Quality);
        }

        [Test(Description = "Once the sell by date has passed, Quality degrades twice as fast")]
        public void UpdateQuality_SellInHasPassed_QualityDecreasedByTwo()
        {
            var items = new List<Item> { new Item { Name = "Some", SellIn = 0, Quality = 10 } };
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();

            Assert.AreEqual(8, items[0].Quality);
        }

        [Test(Description = "The Quality of an item is never negative")]
        public void UpdateQuality_QualityIsZero_QualityIsNotDecreased()
        {
            var items = new List<Item> { new Item { Name = "Some", SellIn = 1, Quality = 0 } };
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }

        [Test(Description = "The Quality of an item is never more than 50")]
        public void UpdateQuality_QualityIs50_QualityIsNotIncreased()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 0, Quality = 50 } };
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();

            Assert.AreEqual(50, items[0].Quality);
        }

        [Test(Description = "Sulfuras, being a legendary item, never has to decreases in Quality and its Quality is 80")]
        public void UpdateQuality_NameIsSulfaras_QualityIsAlways80()
        {
            var items = new List<Item> { new Item { Name = "Sulfuras", SellIn = 10, Quality = 0 } };
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();

            Assert.AreEqual(80, items[0].Quality);
        }

        [Test(Description = "Sulfuras, being a legendary item, never has to decreases in Quality more than 80")]
        public void UpdateQuality_NameIsSulfaras_QualityIsNotMore80()
        {
            var items = new List<Item> { new Item { Name = "Sulfuras", SellIn = 10, Quality = 80 } };
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();

            Assert.AreEqual(80, items[0].Quality);
        }

        [Test(Description = "Aged Brie actually increases in Quality the older it gets")]
        public void UpdateQuality_NameIsAgedBrie_QualityIncreased()
        {
            var items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 5, Quality = 0 } };
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();

            Assert.AreEqual(1, items[0].Quality);
        }

        [Test(Description = "Backstage passes, like aged brie, increases in Quality as its SellIn value approaches;")]
        public void UpdateQuality_NameIsBackstagePasses_QualityIsIncreased()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 11, Quality = 0 } };
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();

            Assert.AreEqual(1, items[0].Quality);
        }

        [Test(Description = "Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but")]
        public void UpdateQuality_NameIsBackstagePassesSellIn10Days_QualityIsIncreasedBy2()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 10, Quality = 5 } };
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();

            Assert.AreEqual(7, items[0].Quality);
        }

        [Test(Description = "Quality increases by 3 when there are 5 days or less")]
        public void UpdateQuality_NameIsBackstagePassesSellIn5Days_QualityIsIncreasedBy3()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 5, Quality = 5 } };
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();

            Assert.AreEqual(8, items[0].Quality);
        }

        [Test(Description = "Quality drops to 0 after the concert")]
        public void UpdateQuality_NameIsBackstageSellIn0Days_QualityIsZero()
        {
            var items = new List<Item> { new Item { Name = "Backstage passes", SellIn = 0, Quality = 5 } };
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();

            Assert.AreEqual(0, items[0].Quality);
        }

        [Test(Description = "Conjured items degrade in Quality twice as fast as normal items")]
        public void UpdateQuality_NameIsConjured_QualityDegradesBy2()
        {
            var items = new List<Item> { new Item { Name = "Conjured", SellIn = 5, Quality = 5 } };
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();

            Assert.AreEqual(3, items[0].Quality);
        }

        [Test(Description = "Conjured items degrade in Quality twice as fast as normal items")]
        public void UpdateQuality_ConjuredAndSellInPassed_QualityDegradesBy4()
        {
            var items = new List<Item> { new Item { Name = "Conjured", SellIn = -1, Quality = 5 } };
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();

            Assert.AreEqual(1, items[0].Quality);
        }

        [Test(Description = "While passed null as collection")]
        public void UpdateQuality_NullCollectionPassed_NotFail()
        {
            List<Item> items = null;
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();
        }

        [Test(Description = "While passed Item with null Name")]
        public void UpdateQuality_ItemWithNullAsName_HandledAsDefaultItem()
        {
            var items = new List<Item> { new Item { Name = null, SellIn = 5, Quality = 5 } };
            var app = new GildedRose(items, new QualityUpdaterResolver());
            
            app.UpdateQuality();
            
            Assert.AreEqual(4, items[0].Quality);
        }
    }
}