// ============================================================================
// opcdiary.IvsUtility - TestIvsUtility - UnitTest1.cs
// 
// Last update	:2013-11-04  Tadahiro Ishisaka
// Origin		:2013-11-04 
// ============================================================================
// 
// License:
// 
//    Copyright 2013 Tadahiro Ishisaka
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// 
// --------------------------------------------------------------------------
// 

using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpcDiary;

namespace TestIvsUtility
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestStringIsSelector()
        {
            var testString = "渡\u908A\uDB40\uDD07さん";
            Assert.AreEqual(testString.IsVariationSelector(0), false);
            Assert.AreEqual(testString.IsVariationSelector(1), false);
            Assert.AreEqual(testString.IsVariationSelector(2), true);
            Assert.AreEqual(testString.IsVariationSelector(3), true);
            Assert.AreEqual(testString.IsVariationSelector(4), false);
            Assert.AreEqual(testString.IsVariationSelector(5), false);
        }

        [TestMethod]
        public void TestCharIsSelector()
        {
            char c = '\uDD07';
            char d = 'あ';
            Assert.AreEqual(c.IsVariationSelector(), true);
            Assert.AreEqual(d.IsVariationSelector(), false);
        }
    }
}