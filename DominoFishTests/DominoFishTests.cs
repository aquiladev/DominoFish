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
            var result = fish.Float(new[]{
                new Squama(1, 5), 
                new Squama(3, 1), 
                new Squama(3, 6), 
                new Squama(5, 6) });

            //assert
            Assert.NotNull(result);
        }

        [Test]
        public void Float_Positive1()
        {
            //arrange
            var fish = new CatFish();

            //act
            var result = fish.Float(new[]{
                new Squama(1, 5) });

            //assert
            Assert.NotNull(result);
        }

        [Test]
        public void Float_Positive2()
        {
            //arrange
            var fish = new CatFish();

            //act
            var result = fish.Float(new[]{
                new Squama(1, 5), 
                new Squama(3, 1), 
                new Squama(3, 6) });

            //assert
            Assert.NotNull(result);
        }

        [Test]
        public void Float_Negative()
        {
            //arrange
            var fish = new CatFish();

            //act
            var result = fish.Float(new[] { 
                new Squama(1, 2), 
                new Squama(2, 2), 
                new Squama(2, 4), 
                new Squama(4, 4), 
                new Squama(2, 2), 
                new Squama(1, 2), 
                new Squama(5, 6) });

            //assert
            Assert.Null(result);
        }

        [Test]
        public void Float_Negative2()
        {
            //arrange
            var fish = new CatFish();

            //act
            var result = fish.Float(new Squama[] {
                new Squama( 1, 1 ), 
                new Squama( 2, 2 ) });

            //assert
            Assert.Null(result);
        }
    }
}
