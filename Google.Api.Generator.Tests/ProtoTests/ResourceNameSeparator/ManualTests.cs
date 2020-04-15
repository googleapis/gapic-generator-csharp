using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Testing.ResourceNameSeparator
{
    public class ManualTests
    {
        [Fact]
        public void From()
        {
            var r1 = RequestName.FromItemAItemBDetailsADetailsBDetailsCExtra("a", "b", "da", "db", "dc", "e");
            Assert.Equal("a", r1.ItemAId);
            Assert.Equal("b", r1.ItemBId);
            Assert.Equal("da", r1.DetailsAId);
            Assert.Equal("db", r1.DetailsBId);
            Assert.Equal("dc", r1.DetailsCId);
            Assert.Equal("e", r1.ExtraId);
            var r2 = RequestName.FromAB1B2B3("A", "B1", "B2", "B3");
            Assert.Equal("A", r2.AId);
            Assert.Equal("B1", r2.B1Id);
            Assert.Equal("B2", r2.B2Id);
            Assert.Equal("B3", r2.B3Id);
        }

        [Fact]
        public void Parse()
        {
            var r1 = RequestName.Parse("items/a~b/details/da_db:dc/extra/e");
            Assert.Equal("a", r1.ItemAId);
            Assert.Equal("b", r1.ItemBId);
            Assert.Equal("da", r1.DetailsAId);
            Assert.Equal("db", r1.DetailsBId);
            Assert.Equal("dc", r1.DetailsCId);
            Assert.Equal("e", r1.ExtraId);
            var r2 = RequestName.Parse("as/aaaAaaa/bs/~B1~B2~B3~");
            Assert.Equal("A", r2.AId);
            Assert.Equal("B1", r2.B1Id);
            Assert.Equal("B2", r2.B2Id);
            Assert.Equal("B3", r2.B3Id);
        }
    }
}
