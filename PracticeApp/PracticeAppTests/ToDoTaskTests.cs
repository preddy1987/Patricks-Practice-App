using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeApp.Models;
using PracticeApp;

namespace PracticeAppTests
{
    [TestClass]
    public class ToDoTaskTests
    {
        [TestMethod]
        public void TestAddNewTask()
        {
            ToDoApp testApp = new ToDoApp();
            ToDoTask testTask = new ToDoTask()
            {
                Name = "Test Task Name",
                Description = "Test Task Description",
                ListId = 1
            };
            testApp.AddNewTask(testTask);

            int expectedCount = 1;
            string expectedName = testTask.Name;
            string expectedDesc = testTask.Description;
            int expectedListId = testTask.ListId;
            int expectedId = 1;

            int actualCount = testApp.CurrentDictOfTasks.Count;
            string actualName = testApp.CurrentDictOfTasks[testTask.ListId][0].Name;
            string actualDesc = testApp.CurrentDictOfTasks[testTask.ListId][0].Description;
            int actualListId = testApp.CurrentDictOfTasks[testTask.ListId][0].ListId;
            int actualId = (int)testApp.CurrentDictOfTasks[testTask.ListId][0].Id;

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDesc, actualDesc);
            Assert.AreEqual(expectedListId, actualListId);
            Assert.AreEqual(expectedId, actualId);

        }
    }
}
