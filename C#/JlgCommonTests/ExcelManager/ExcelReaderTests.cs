﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JlgCommonTests.ExcelManager
{
    [TestClass]
    public class ExcelReaderTests
    {
        private JlgCommon.ExcelManager.ExcelManager _excelManager = new JlgCommon.ExcelManager.ExcelManager(ExcelManagerTests.ExcelReaderTestsFilePath);

        [TestMethod]
        public void GetCellValue()
        {
            _excelManager.Reader.SelectWorksheet("Page1");
            Assert.AreEqual("dan", _excelManager.Reader.GetCellValueAsString(2, 2), false);
            Assert.AreEqual("misailescu", _excelManager.Reader.GetCellValueAsString(2, 3), false);
            Assert.AreEqual(new DateTime(2015, 4, 7), _excelManager.Reader.GetCellValueAsDateTime(3, 5));
            Assert.AreEqual(9, _excelManager.Reader.GetCellValueAsInt(2, 7));
            Assert.AreEqual(7.3245, _excelManager.Reader.GetCellValueAsDouble(3, 7));
        }

        [TestMethod]
        public void GetColumnOrderedIndexes()
        {
            _excelManager.Reader.SelectWorksheet("Page1");
            CollectionAssert.AreEquivalent(new List<int>() { 1, 2, 3, 4, 5, 6, 7 },
                _excelManager.Reader.GetColumnOrderedIndexes());
        }

        [TestMethod]
        public void GetNumberOfRows()
        {
            _excelManager.Reader.SelectWorksheet("Page1");
            Assert.AreEqual(6, _excelManager.Reader.GetNumberOfRows());
        }

        [TestMethod]
        public void GetRowValues()
        {
            //42065 is the string for "02/03/2015"
            _excelManager.Reader.SelectWorksheet("Page1");
            CollectionAssert.AreEquivalent(
                new List<string> { "", "dan", "misailescu", "excel", "42065", "", "9" },
                _excelManager.Reader.GetRowValues(2));
        }

        [TestMethod]
        public void GetRowNotEmptyValues()
        {
            //42065 is the string for "02/03/2015"
            _excelManager.Reader.SelectWorksheet("Page1");
            CollectionAssert.AreEquivalent(
                new List<string> { "dan", "misailescu", "excel", "42065", "9" },
                _excelManager.Reader.GetRowNotEmptyValues(2));
        }

        [TestMethod]
        public void GetRowNotEmptyValuesWithColumnIndexes()
        {
            _excelManager.Reader.SelectWorksheet("Page3");
            var valuesDictionary = _excelManager.Reader.GetRowNotEmptyValuesWithColumnIndexes(3);
            CollectionAssert.AreEquivalent(valuesDictionary,
                new Dictionary<int, string>
                {
                    {2, "searchedString"},
                    {6, "searchedString"}
                });
        }

        [TestMethod]
        public void GetColumnDistinctStringValues()
        {
            _excelManager.Reader.SelectWorksheet("Page1");
            CollectionAssert.AreEquivalent(new List<string>() { "Library", "excel", "manager", "tests" },
                _excelManager.Reader.GetColumnDistinctStringValues(4, 1));

            CollectionAssert.AreEquivalent(new List<string>() { "excel", "manager", "tests" },
                  _excelManager.Reader.GetColumnDistinctStringValues(4, 2));
        }

        [TestMethod]
        public void GetColumnDistinctDates()
        {
            _excelManager.Reader.SelectWorksheet("Page1");
            CollectionAssert.AreEquivalent(new List<DateTime>() { new DateTime(2015, 3, 2), new DateTime(2015, 4, 7), new DateTime(2015, 5, 25) },
                _excelManager.Reader.GetColumnDistinctDates(5, 2));

            CollectionAssert.AreEquivalent(new List<DateTime>() { new DateTime(2015, 4, 7), new DateTime(2015, 3, 2) },
               _excelManager.Reader.GetColumnDistinctDates(5, 5));
        }

        [TestMethod]
        public void GetIndexOfColumnByCellContentString()
        {
            _excelManager.Reader.SelectWorksheet("Page1");
            Assert.AreEqual(5, _excelManager.Reader.GetIndexOfColumnByCellContentString("Dates"));
            Assert.AreEqual(4, _excelManager.Reader.GetIndexOfColumnByCellContentString("excel", 2));
            Assert.AreEqual(4, _excelManager.Reader.GetIndexOfColumnByCellContentString("manager", 3));
        }

        [TestMethod]
        public void GetWorksheetNames()
        {
            CollectionAssert.AreEquivalent(new List<string>() { "Page1", "Page2", "Page3", "Page4" },
                  _excelManager.Reader.GetWorksheetNames());
        }

        [TestMethod]
        public void SelectWorksheet()
        {
            _excelManager.Reader.SelectWorksheet("Page2");
            Assert.AreEqual("Values", _excelManager.Reader.GetCellValueAsString(2, 1), false);
            Assert.AreEqual(3, _excelManager.Reader.GetCellValueAsInt(3, 1));
            Assert.AreEqual(14, _excelManager.Reader.GetCellValueAsInt(4, 1));
            Assert.AreEqual(7, _excelManager.Reader.GetCellValueAsInt(7, 1));
        }

        [TestMethod]
        public void GetFirstRowContainingValuesIndex()
        {
            _excelManager.Reader.SelectWorksheet("Page2");
            Assert.AreEqual(2, _excelManager.Reader.GetFirstNotEmptyRowIndex());
        }

        //[TestMethod]
        //public void GetRowCells()
        //{
        //    _excelManager.Reader.SelectWorksheet("Page3");
        //    var cells = _excelManager.Reader.GetRowCells(1);
        //    //Assert.AreEqual(2, _excelManager.Reader.GetFirstRowContainingValuesIndex());
        //}

        [TestMethod]
        public void GetMergedCells()
        {
            _excelManager.Reader.SelectWorksheet("Page3");
            var mergedCells = _excelManager.Reader.GetMergedCells();
            Assert.AreEqual(mergedCells.Count, 1);

            var firstMergedCells = mergedCells.First();
            Assert.AreEqual(firstMergedCells.IsValid, true);
            Assert.AreEqual(firstMergedCells.StartRowIndex, 1);
            Assert.AreEqual(firstMergedCells.EndRowIndex, 2);
            Assert.AreEqual(firstMergedCells.StartColumnIndex, 1);
            Assert.AreEqual(firstMergedCells.EndColumnIndex, 3);
        }

        [TestMethod]
        public void GetMergedCellsStartingRow()
        {
            _excelManager.Reader.SelectWorksheet("Page3");
            Assert.AreEqual(_excelManager.Reader.GetMergedCellsStartingRow(), 1);
        }

        [TestMethod]
        public void GetMergedCellsEndingRow()
        {
            _excelManager.Reader.SelectWorksheet("Page3");
            Assert.AreEqual(_excelManager.Reader.GetMergedCellsEndingRow(), 2);
        }

        [TestMethod]
        public void GetCellStyle()
        {
            _excelManager.Reader.SelectWorksheet("Page3");
            var style = _excelManager.Reader.GetCellStyle(1, 1);
            Assert.AreEqual(style.Font.FontName, "Arial");
            Assert.AreEqual(style.Font.FontSize, 10);
            Assert.AreEqual(style.Font.Bold, true);
            Assert.AreEqual(style.Alignment.Horizontal.ToString(), "Center");
            Assert.AreEqual(style.Alignment.Vertical.ToString(), "Bottom");
        }

        [TestMethod]
        public void GetColumnIndexesForSpecificStringValue()
        {
            _excelManager.Reader.SelectWorksheet("Page3");
            var columnIndexes = _excelManager.Reader.GetColumnIndexesForSpecificStringValue(3, "searchedString");
            CollectionAssert.AreEquivalent(columnIndexes, new List<int>() { 2, 6 });
        }

        [TestMethod]
        public void GetValuesForWorksheet()
        {
            var valuesDictionary = _excelManager.Reader.GetValuesForWorksheet("Page3");

            Assert.AreEqual(valuesDictionary[1][1], "Merged cells");
            Assert.AreEqual(valuesDictionary[3][2], "searchedString");
            Assert.AreEqual(valuesDictionary[3][6], "searchedString");
        }

        [TestMethod]
        public void GetLastNonEmptyRowIndex()
        {
            var lastIndex = _excelManager.Reader.GetLastNonEmptyRowIndex("Page2");
            Assert.AreEqual(lastIndex, 20);
        }

        [TestMethod]
        public void GetNonEmptyRowsForWorksheet()
        {
            var valuesDictionary = _excelManager.Reader.GetValuesForWorksheet("Page3");

            Assert.AreEqual(valuesDictionary[1][1], "Merged cells");
            Assert.AreEqual(valuesDictionary[3][2], "searchedString");
            Assert.AreEqual(valuesDictionary[3][6], "searchedString");
        }

        [TestMethod]
        public void GetRowAndColumnForSpecificStringValue()
        {
            _excelManager.Reader.SelectWorksheet("Page3");
            var indexes = _excelManager.Reader.GetRowAndColumnForSpecificStringValue("searchedString");
            Assert.AreEqual(indexes.Item1, 3);
            Assert.AreEqual(indexes.Item2, 2);
        }

        [TestMethod]
        public void CellIsValidDateAfter1900()
        {
            _excelManager.Reader.SelectWorksheet("Page1");
            Assert.IsFalse(_excelManager.Reader.CellIsValidDateAfter1900(2, 3));
            Assert.IsTrue(_excelManager.Reader.CellIsValidDateAfter1900(4, 5));
        }

        [TestMethod]
        public void GetColumnDistinctStringValuesWithRowIndexes()
        {
            _excelManager.Reader.SelectWorksheet("Page2");
            var values = new Dictionary<string, int>
            {
                {"Values", 2} ,
                {"3", 3},
                {"14", 4},
                {"8", 5},
                {"10", 6},
                {"7", 7}
            };
            CollectionAssert.AreEqual(_excelManager.Reader.GetColumnDistinctStringValuesWithRowIndexes(1, 2), values);
        }

        [TestMethod]
        public void GetColumnIndexesForStringList()
        {
            _excelManager.Reader.SelectWorksheet("Page2");
            var inputDictionary = new Dictionary<string, int>
            {
                {"Values", 2} ,
                {"3", 3},
                {"14", 4},
                {"8", 5},
                {"10", 6},
                {"7", 7},
                {"66", 8}
            };

            var outputDictionary = new Dictionary<string, int>
            {
                {"Values", 1} ,
                {"3", 1},
                {"14", 1},
                {"8", 1},
                {"10", 1},
                {"7", 1}
            };

            var returnedDictionary = _excelManager.Reader.GetColumnIndexesForStringList(inputDictionary);
            CollectionAssert.AreEqual(outputDictionary, returnedDictionary);
        }

        [TestMethod]
        public void GetRowAndColumnContainingStringValue()
        {
            _excelManager.Reader.SelectWorksheet("Page2");
            var fieldNamesList = new List<string>();

            fieldNamesList.Add("State");
            fieldNamesList.Add("Reporting Year");
            fieldNamesList.Add("Date of completion");
            fieldNamesList.Add("Contact Person");
            fieldNamesList.Add("Position/Title");
            fieldNamesList.Add("Organisation");
            fieldNamesList.Add("Address");
            fieldNamesList.Add("Tel");
            fieldNamesList.Add("Fax");
            fieldNamesList.Add("E-mail");

            var outputList = new List<Tuple<int, int>>();
            outputList.Add(new Tuple<int, int>(2, 3));
            outputList.Add(new Tuple<int, int>(4, 3));
            outputList.Add(new Tuple<int, int>(6, 3));
            outputList.Add(new Tuple<int, int>(8, 3));
            outputList.Add(new Tuple<int, int>(10, 3));
            outputList.Add(new Tuple<int, int>(12, 3));
            outputList.Add(new Tuple<int, int>(14, 3));
            outputList.Add(new Tuple<int, int>(16, 3));
            outputList.Add(new Tuple<int, int>(18, 3));
            outputList.Add(new Tuple<int, int>(20, 3));

            var outputTuples = new List<Tuple<int, int>>();
            for (int i = 0; i < fieldNamesList.Count; i++)
            {
                var value = fieldNamesList[i];
                var outputTuple = _excelManager.Reader.GetRowAndColumnContainingStringValue(value);

                outputTuples.Add(outputTuple);
            }

            CollectionAssert.AreEqual(outputList, outputTuples);
        }

//        [TestMethod]
//        public void GetWorksheetDataAsStringList()
//        {
//            var worksheetData = _excelManager.Reader.GetWorksheetDataAsStringList("Page4");
//
//            var row1 = new Dictionary<int, string> { {2, "this"}, {3, "is"}, {4, "a"}, {5, "test"}};
//            var row2 = new Dictionary<int, string> { {2, "for"}, {3, "getting"}, {4, "worksheet"}, {5, "data"}};
//            var row3 = new Dictionary<int, string> { {3, "as"}, {4, "list"}};
//            var row4 = new Dictionary<int, string> { {3, "of"}};
//            var row5 = new Dictionary<int, string> { {2, "lists" }, {3, "of"}, {5, "string"}};
//            Dictionary<int, string> outputRow1;
//            worksheetData.TryGetValue(2, out outputRow1);
//            Dictionary<int, string> outputRow2;
//            worksheetData.TryGetValue(3, out outputRow2);
//            Dictionary<int, string> outputRow3;
//            worksheetData.TryGetValue(4, out outputRow3);
//            Dictionary<int, string> outputRow4;
//            worksheetData.TryGetValue(5, out outputRow4);
//            Dictionary<int, string> outputRow5;
//            worksheetData.TryGetValue(6, out outputRow5);
//            CollectionAssert.AreEqual(outputRow1, row1);
//            CollectionAssert.AreEqual(outputRow2, row2);
//            CollectionAssert.AreEqual(outputRow3, row3);
//            CollectionAssert.AreEqual(outputRow4, row4);
//            CollectionAssert.AreEqual(outputRow5, row5);
//        }

    }
}
