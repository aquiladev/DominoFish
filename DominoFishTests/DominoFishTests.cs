using DominoFish;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoFishTests
{
    [TestFixture]
    public class DominoFishTests
    {
        [Test]
        public void Float_Positive()
        {
            //arrange
            var fish = new CatFish();

            //act
            var result = fish.Float(new int[,] { { 1, 5 }, { 3, 1 }, { 3, 6 }, { 5, 5 } });

            //assert
            Assert.NotNull(result);
        }

        [Test]
        public void Float_F()
        {
            //arrange
            var fish = new CatFish();

            //act
            var result = fish.Float(new int[,] { { 1, 1 }, { 2, 3 } });

            //assert
            Assert.Null(result);
        }
    }
}
