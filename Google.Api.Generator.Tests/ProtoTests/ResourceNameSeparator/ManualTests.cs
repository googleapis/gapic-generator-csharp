// Copyright 2020 Google Inc. All Rights Reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
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

        [Fact]
        public void ParseErrors()
        {
            Assert.Throws<ArgumentException>(() => RequestName.Parse("items/a~/details/da_db:dc/extra/e"));
            Assert.Throws<ArgumentException>(() => RequestName.Parse("items/ab/details/da_db:dc/extra/e"));
            Assert.Throws<ArgumentException>(() => RequestName.Parse("items/a~b/details/da:db:dc/extra/e"));
            Assert.Throws<ArgumentException>(() => RequestName.Parse("items/a~b/details/da_db_dc/extra/e"));
        }

        [Fact]
        public void Format()
        {
            Assert.Equal("items/a~b/details/da_db:dc/extra/e",
                RequestName.FormatItemAItemBDetailsADetailsBDetailsCExtra("a", "b", "da", "db", "dc", "e"));
            Assert.Equal("as/aaaAaaa/bs/~B1~B2~B3~",
                RequestName.FormatAB1B2B3("A", "B1", "B2", "B3"));
        }
    }
}
