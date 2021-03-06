﻿using System;
using JlgCommon.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JlgCommonTests.Extensions
{
    [TestClass]
    public class DateTimeExtensionsTests
    {
        [TestMethod]
        public void ToAbbreviatedFormat()
        {
            var jan = new DateTime(2014, 1, 1);
            Assert.AreEqual("Jan 2014", jan.ToMonthYearString(), false);
            var feb = new DateTime(2014, 2, 1);
            Assert.AreEqual("Feb 2014", feb.ToMonthYearString(), false);
            var mar = new DateTime(2014, 3, 1);
            Assert.AreEqual("Mar 2014", mar.ToMonthYearString(), false);
            var apr = new DateTime(2014, 4, 1);
            Assert.AreEqual("Apr 2014", apr.ToMonthYearString(), false);
            var may = new DateTime(2014, 5, 1);
            Assert.AreEqual("May 2014", may.ToMonthYearString(), false);
            var jun = new DateTime(2014, 6, 1);
            Assert.AreEqual("Jun 2014", jun.ToMonthYearString(), false);
            var jul = new DateTime(2014, 7, 1);
            Assert.AreEqual("Jul 2014", jul.ToMonthYearString(), false);
            var aug = new DateTime(2014, 8, 1);
            Assert.AreEqual("Aug 2014", aug.ToMonthYearString(), false);
            var sep = new DateTime(2014, 9, 1);
            Assert.AreEqual("Sep 2014", sep.ToMonthYearString(), false);
            var oct = new DateTime(2014, 10, 1);
            Assert.AreEqual("Oct 2014", oct.ToMonthYearString(), false);
            var nov = new DateTime(2014, 11, 1);
            Assert.AreEqual("Nov 2014", nov.ToMonthYearString(), false);
            var dec = new DateTime(2014, 12, 1);
            Assert.AreEqual("Dec 2014", dec.ToMonthYearString(), false);
        }

        [TestMethod]
        public void ToMonthNameDayYear()
        {
            var date = new DateTime(2014, 3, 12);
            Assert.AreEqual("Mar 12 2014", date.ToMonthNameDayYearString(), false);
        }

        [TestMethod]
        public void ToDateIgnoringTime()
        {
            var date = new DateTime(2014, 3, 12, 2, 15, 12);
            Assert.AreEqual(new DateTime(2014, 3, 12), date.ToDateIgnoringTime());
        }

        [TestMethod]
        public void ToYearMonth()
        {
            var date = new DateTime(2014, 3, 12, 2, 15, 12);
            Assert.AreEqual(new DateTime(2014, 3, 1), date.ToMonthYear());
        }

        [TestMethod]
        public void DifferenceInMonths()
        {
            var start = new DateTime(2014, 3, 12);
            var end = new DateTime(2014, 3, 2);
            Assert.AreEqual(end.DifferenceInMonths(start), 0);
            Assert.AreEqual(start, new DateTime(2014, 3, 12));
            Assert.AreEqual(end, new DateTime(2014, 3, 2));

            start = new DateTime(2014, 3, 12);
            end = new DateTime(2014, 4, 2);
            Assert.AreEqual(end.DifferenceInMonths(start), 1);
            Assert.AreEqual(start.DifferenceInMonths(end), -1);

            start = new DateTime(2014, 11, 12);
            end = new DateTime(2015, 2, 10);
            Assert.AreEqual(end.DifferenceInMonths(start), 3);
            Assert.AreEqual(start.DifferenceInMonths(end), -3);

        }

        

    }
}
