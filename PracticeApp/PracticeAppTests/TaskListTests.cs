using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeApp.Models;
using PracticeApp;

namespace PracticeAppTests
{
    [TestClass]
    public class TaskListTests
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
        [TestMethod]
        public void TestAddNewList()
        {
            ToDoApp testPracticeApp = new ToDoApp();
            TaskList testTaskList = new TaskList()
            {
                Name = "Test Task List",
                Description = "Testing the Task List"
            };
            testPracticeApp.AddNewList(testTaskList);

            string expectedName = testTaskList.Name;
            string expectedDesc = testTaskList.Description;
            int expectedId = (int)testTaskList.Id;

            string actualName = testPracticeApp.CurrentDictOfTaskLists[(int)testTaskList.Id].Name;
            string actualDesc = testPracticeApp.CurrentDictOfTaskLists[(int)testTaskList.Id].Description;
            int actualId = (int)testPracticeApp.CurrentDictOfTaskLists[(int)testTaskList.Id].Id;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDesc, actualDesc);
            Assert.AreEqual(expectedId, actualId);
        }
        [TestMethod]
        public void TestChangeList()
        {
            ToDoApp testPracticeApp = new ToDoApp();
            TaskList testTaskList = new TaskList()
            {
                Name = "Test Task List",
                Description = "Testing the Task List",
                Id = 1
            };
            testPracticeApp.CurrentDictOfTaskLists.Add((int)testTaskList.Id, testTaskList);

            TaskList updatedTaskList = new TaskList()
            {
                Name = "Test Task List Test Test",
                Description = "Testing the Task List Test Test",
                Id = 1
            };

            testPracticeApp.ChangeList(updatedTaskList);

            string expectedName = updatedTaskList.Name;
            string expectedDesc = updatedTaskList.Description;
            int expectedId = (int)updatedTaskList.Id;

            string actualName = testPracticeApp.CurrentDictOfTaskLists[(int)testTaskList.Id].Name;
            string actualDesc = testPracticeApp.CurrentDictOfTaskLists[(int)testTaskList.Id].Description;
            int actualId = (int)testPracticeApp.CurrentDictOfTaskLists[(int)testTaskList.Id].Id;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDesc, actualDesc);
            Assert.AreEqual(expectedId, actualId);
        }
        [TestMethod]
        public void TestRemoveList()
        {
            ToDoApp testPracticeApp = new ToDoApp();
            TaskList testTaskList = new TaskList()
            {
                Name = "Test Task List",
                Description = "Testing the Task List",
                Id = 1
            };
            testPracticeApp.CurrentDictOfTaskLists.Add((int)testTaskList.Id, testTaskList);
            TaskList testTaskListTwo = new TaskList()
            {
                Name = "Test Task List",
                Description = "Testing the Task List",
                Id = 2
            };
            testPracticeApp.CurrentDictOfTaskLists.Add((int)testTaskListTwo.Id, testTaskListTwo);

            testPracticeApp.RemoveList(testTaskListTwo.Id);

            int expectedCount = 1;
            int actualCount = testPracticeApp.CurrentDictOfTaskLists.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
