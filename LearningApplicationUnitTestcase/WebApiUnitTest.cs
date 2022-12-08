using LearningApplication.Controllers;
using LearningApplication.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Web.Mvc;

namespace LearningApplicationUnitTestcase
{
    [TestClass]
    public class WebApiUnitTest
    {

        ValuesController controller;
        public string ApiUrl;
        ValuesModel values;

        /// <summary>
        /// Method for common variable initialization
        /// </summary>
        [TestInitialize]
        public void TestInitialize()
        {
            controller = new ValuesController();
            ConfigurationManager.AppSettings["ApiUrl"] = "https://localhost:44395/api/";
            var result = controller.Index() as ViewResult; // Installed Microsoft.AspNet.Mvc from Nuget Packages
            values = (ValuesModel)result.ViewData.Model;
        }

        /// <summary>
        /// Test case for data is not null from API
        /// </summary>
        [TestMethod]
        public void TestStringNotEmpty()
        {  
            Assert.IsNotNull(values.MyString);
        }

        /// <summary>
        /// Test case for string are equal
        /// </summary>
        [TestMethod]
        public void TestMatchingString()
        {
            Assert.AreEqual("Sample local API string Data to display in the UI", values.MyString);
        }

        /// <summary>
        /// Test case for string are not equal
        /// </summary>
        [TestMethod]
        public void TestNonMatchingString()
        {
            Assert.AreNotEqual("Test", values.MyString);
        }

        /// <summary>
        /// Test case for string are not equal
        /// </summary>
        [TestMethod]
        public void TestNonMatchingStringNegative()
        {
            Assert.AreEqual("Test", values.MyString);
        }

    }
}
