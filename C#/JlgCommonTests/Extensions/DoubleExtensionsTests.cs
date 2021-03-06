﻿using JlgCommon.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JlgCommonTests.Extensions
{
    [TestClass]
    public class DoubleExtensionsTests
    {
        [TestMethod]
        public void DifferenceInPercents()
        {
            double nr1 = 10;
            double nr2 = 15;
            Assert.AreEqual(50, nr2.DifferenceInPercents(nr1));
            double nr3 = 20;
            Assert.AreEqual(100, nr3.DifferenceInPercents(nr1));
            double nr4 = 5;
            Assert.AreEqual(-50, nr4.DifferenceInPercents(nr1));
            double nr5 = -5;
            Assert.AreEqual(-150, nr5.DifferenceInPercents(nr1));
        }

        [TestMethod]
        public void DifferenceInPercents_Nullable()
        {
            double? nr1 = 10;
            double? nr2 = 15;
            Assert.AreEqual(50, nr2.DifferenceInPercents(nr1));
            double? nr3 = 20;
            Assert.AreEqual(100, nr3.DifferenceInPercents(nr1));
            double? nr4 = 5;
            Assert.AreEqual(-50, nr4.DifferenceInPercents(nr1));
            double? nr5 = -5;
            Assert.AreEqual(-150, nr5.DifferenceInPercents(nr1));
            double? nr6 = null;
            Assert.AreEqual(null, nr6.DifferenceInPercents(nr1));
            Assert.AreEqual(null, nr4.DifferenceInPercents(nr6));
        }
        
        [TestMethod]
        public void PercentValue()
        {
            double nr1 = 10;
            Assert.AreEqual(5, nr1.PercentValue(50));
            double nr2 = 100;
            Assert.AreEqual(10, nr2.PercentValue(10));
            double nr3 = 50;
            Assert.AreEqual(5, nr3.PercentValue(10));
            double nr4 = 70;
            Assert.AreEqual(3.64, nr4.PercentValue(5.2));
            double nr5 = 100;
            Assert.AreEqual(-20, nr5.PercentValue(-20));
            double nr6 = 30;
            Assert.AreEqual(-0.6, nr6.PercentValue(-2));
            double nr7 = 25.3;
            Assert.AreEqual(-1.8722, nr7.PercentValue(-7.4), 0.0001);
        }    

        [TestMethod]
        public void IncreaseByPercent()
        {
            double nr1 = 10;
            Assert.AreEqual(15, nr1.IncreaseByPercent(50));
            double nr2 = 100;
            Assert.AreEqual(102, nr2.IncreaseByPercent(2));
            double nr3 = 50;
            Assert.AreEqual(55, nr3.IncreaseByPercent(10));
            double nr4 = 70;
            Assert.AreEqual(73.64, nr4.IncreaseByPercent(5.2));
            double nr5 = 100;
            Assert.AreEqual(80, nr5.IncreaseByPercent(-20));
            double nr6 = 30;
            Assert.AreEqual(29.4, nr6.IncreaseByPercent(-2));
            double nr7 = 25.3;
            Assert.AreEqual(23.4278, nr7.IncreaseByPercent(-7.4));
        }    
    
    }
}
