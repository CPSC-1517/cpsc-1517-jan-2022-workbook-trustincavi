using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PracticeConsole;
using PracticeConsole.Data;
using System.Collections.Generic;

namespace UnitTestSample
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        [DataRow("Bob", "Changes")]
        public void CreatePerson_GoodCreate_CreatePerson(
            string firstname, string lastname)
        {
            try
            {
                Employment employment = new("worker", SupervisoryLevel.Entry, 2.5);
                ResidentAddress employmentAddress = new(19334, "Exx st", "", "", "Edmonton", "AB");
                List<Employment> employments = new();
                employments.Add(employment);
                Person me = new(firstname, lastname, employmentAddress, employments);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType} {ex.Message}");
            }
        }

        [TestMethod]
        [DataRow("Bob", "Changes")]
        public void ChangeName_GoodChange_ChangePersonName(
            string firstname, string lastname)
        {
            try
            {
                Employment employment = new("worker", SupervisoryLevel.Entry, 2.5);
                ResidentAddress employmentAddress = new(19334, "Exx st", "", "", "Edmonton", "AB");
                List<Employment> employments = new();
                employments.Add(employment);
                Person me = new(firstname, lastname, employmentAddress, employments);
                me.ChangeName(firstname, lastname);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Unexpected exception of type {ex.GetType} {ex.Message}");
            }
        }


        [TestMethod]
        [DataRow("", "Changes")]
        [DataRow("Bob", "")]
        [DataRow("", "")]
        public void ChangeName_BadChange_ChangePersonName(
            string firstname, string lastname)
        {
            try
            {
                Employment employment = new("worker", SupervisoryLevel.Entry, 2.5);
                ResidentAddress employmentAddress = new(19334, "Exx st", "", "", "Edmonton", "AB");
                List<Employment> employments = new();
                employments.Add(employment);
                Person me = new(firstname, lastname, employmentAddress, employments);
                
                // the logic being tested
                me.ChangeName(firstname, lastname);
                Assert.Fail("Exception was expected and failed to be thrown");
            }
            catch (Exception ex)
            {
                Assert.IsFalse(ex.Message.Contains("Assert.Fail"));
                Assert.IsTrue(ex.Message.Length > 0, "Exception contained no message");
            }
        }

    }
}
