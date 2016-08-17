using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberGenerator.Controllers;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace NumberGenerator.Tests.Controllers
{
    [TestClass]
    public class NumberGeneratorTest
    {
        [TestMethod]
        public void TestIndex()
        {            
            NumberGeneratorController controller = new NumberGeneratorController();            
            ViewResult result = controller.Index() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void TestAllNumberSequence()
        {
            NumberGeneratorController controller = new NumberGeneratorController();
            JsonResult result = controller.GetNumberSequence("100") as JsonResult;
            Assert.IsNotNull(result);
            dynamic data = result.Data;
            /*public List<Int64> evenNumbers { get; set; }
        public List<Int64> oddNumbers { get; set; }
        public List<Int64> allNumbers { get; set; }
        public List<string> cezNumbers { get; set; }
        public List<Int64> fibNumbers { get; set; }*/
            List<Int64> allNumbers = (List<Int64>)data.nvm.allNumbers;
            //check that we have all 101 numbers starting from 0
            Assert.AreEqual(101, allNumbers.Count);
            
            // check that all 101 are unique numbers
            List<Int64> distinct = allNumbers.Select(m => m).Distinct().ToList();
            Assert.AreEqual(101, distinct.Count);
        }

        [TestMethod]
        public void TestOddNumberSequence()
        {
            NumberGeneratorController controller = new NumberGeneratorController();
            JsonResult result = controller.GetNumberSequence("100") as JsonResult;
            Assert.IsNotNull(result);
            dynamic data = result.Data;

            List<Int64> numbers = (List<Int64>)data.nvm.oddNumbers;
            //check that we have all 50 numbers starting from 0
            Assert.AreEqual(50, numbers.Count);

            // check that all 50 are unique numbers
            List<Int64> distinct = numbers.Where(m => m % 2 == 1).ToList();
            Assert.AreEqual(50, distinct.Count);
        }

        [TestMethod]
        public void TestEvenNumberSequence()
        {
            NumberGeneratorController controller = new NumberGeneratorController();
            JsonResult result = controller.GetNumberSequence("100") as JsonResult;
            Assert.IsNotNull(result);
            dynamic data = result.Data;
            
            List<Int64> numbers = (List<Int64>)data.nvm.evenNumbers;
            //check that we have all 51 numbers starting from 0
            Assert.AreEqual(51, numbers.Count);

            // check that all 51 are unique numbers
            List<Int64> distinct = numbers.Where(m => m % 2 == 0).ToList();
            Assert.AreEqual(51, distinct.Count);
        }

        [TestMethod]
        public void TestFibonacciNumberSequence()
        {
            NumberGeneratorController controller = new NumberGeneratorController();
            JsonResult result = controller.GetNumberSequence("100") as JsonResult;
            Assert.IsNotNull(result);
            dynamic data = result.Data;

            List<Int64> numbers = (List<Int64>)data.nvm.fibNumbers;
            //check that we have all 12 numbers starting from 0
            Assert.AreEqual(12, numbers.Count);

            // check random entries from the sequence
            
            Assert.AreEqual(0, numbers[0]);
            Assert.AreEqual(1, numbers[2]);
            Assert.AreEqual(3, numbers[4]);
            Assert.AreEqual(8, numbers[6]);
            Assert.AreEqual(21, numbers[8]);
            Assert.AreEqual(34, numbers[9]);
            Assert.AreEqual(89, numbers[11]);
        }

        [TestMethod]
        public void TestFibonacciNumberSequenceForZero()
        {
            NumberGeneratorController controller = new NumberGeneratorController();
            JsonResult result = controller.GetNumberSequence("0") as JsonResult;
            Assert.IsNotNull(result);
            dynamic data = result.Data;

            List<Int64> numbers = (List<Int64>)data.nvm.fibNumbers;
            //check that we have only 1 number
            Assert.AreEqual(1, numbers.Count);

            // check random entries from the sequence

            Assert.AreEqual(0, numbers[0]);
        }

        [TestMethod]
        public void TestFibonacciNumberSequenceForOne()
        {
            NumberGeneratorController controller = new NumberGeneratorController();
            JsonResult result = controller.GetNumberSequence("1") as JsonResult;
            Assert.IsNotNull(result);
            dynamic data = result.Data;

            List<Int64> numbers = (List<Int64>)data.nvm.fibNumbers;
            //check that we have only 3 numbers
            Assert.AreEqual(3, numbers.Count);

            // check random entries from the sequence

            Assert.AreEqual(0, numbers[0]);
            Assert.AreEqual(1, numbers[1]);
            Assert.AreEqual(1, numbers[2]);
        }

        [TestMethod]
        public void TestCEZNumberSequence()
        {
            NumberGeneratorController controller = new NumberGeneratorController();
            JsonResult result = controller.GetNumberSequence("100") as JsonResult;
            Assert.IsNotNull(result);
            dynamic data = result.Data;

            List<string> numbers = (List<string>)data.nvm.cezNumbers;
            //check that we have all 101 numbers starting from 0
            Assert.AreEqual(101, numbers.Count);

            // check random entries from the sequence

            Assert.AreEqual("0", numbers[0]);
            Assert.AreEqual("1", numbers[1]);
            Assert.AreEqual("C", numbers[9]);
            Assert.AreEqual("Z", numbers[15]);
            Assert.AreEqual("E", numbers[35]);
            Assert.AreEqual("C", numbers[99]);
            Assert.AreEqual("Z", numbers[90]);
        }

    }
}
