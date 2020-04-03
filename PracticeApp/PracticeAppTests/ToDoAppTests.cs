using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeApp.Models;
using PracticeApp;

namespace PracticeAppTests
{
    [TestClass]
    public class PracticeAppTests
    {
        [TestMethod]
        public void TestSetCurrentTaskList()
        {
            ToDoApp testPracticeApp = new ToDoApp();
            TaskList testTaskList = new TaskList()
            {
                Name = "Test Task List",
                Description = "Testing the Task List",
                Id = 1
            };
            testPracticeApp.CurrentDictOfTaskLists.Add((int)testTaskList.Id, testTaskList);
            testPracticeApp.SetCurrentTaskList((int)testTaskList.Id);

            string expectedName = testTaskList.Name;
            string expectedDesc = testTaskList.Description;
            int expectedId = (int)testTaskList.Id;

            string actualName = testPracticeApp.CurrentTaskList.Name;
            string actualDesc = testPracticeApp.CurrentTaskList.Description;
            int actualId = (int)testPracticeApp.CurrentTaskList.Id;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDesc, actualDesc);
            Assert.AreEqual(expectedId, actualId);
        }
    }
}
