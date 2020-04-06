using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeApp.Models;
using PracticeApp;
using System.Collections.Generic;

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
        [TestMethod]
        public void ChangeTask()
        {
            ToDoApp testApp = new ToDoApp();
            ToDoTask testTask = new ToDoTask()
            {
                Name = "Test Task Name",
                Description = "Test Task Description",
                ListId = 1,
                Id = 1
            };
            testApp.CurrentDictOfTasks.Add(testTask.ListId,new List<ToDoTask>() { testTask });

            ToDoTask updatedTask = new ToDoTask()
            {
                Name = "Name Test Task",
                Description = "Description Test Task",
                ListId = 1,
                Id = 1
            };

            testApp.ChangeTask(updatedTask);

            string expectedName = updatedTask.Name;
            string expectedDesc = updatedTask.Description;
            int expectedListId = updatedTask.ListId;
            int expectedId = (int)updatedTask.Id;

            string actualName = testApp.CurrentDictOfTasks[updatedTask.ListId][0].Name;
            string actualDesc = testApp.CurrentDictOfTasks[updatedTask.ListId][0].Description;
            int actualListId = testApp.CurrentDictOfTasks[updatedTask.ListId][0].ListId;
            int actualId = (int)testApp.CurrentDictOfTasks[updatedTask.ListId][0].Id;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDesc, actualDesc);
            Assert.AreEqual(expectedListId, actualListId);
            Assert.AreEqual(expectedId, actualId);
        }
        [TestMethod]
        public void RemoveTask()
        {
            ToDoApp testApp = new ToDoApp();
            ToDoTask testTask = new ToDoTask()
            {
                Name = "Test Task Name",
                Description = "Test Task Description",
                ListId = 1,
                Id = 1
            };
            testApp.CurrentDictOfTasks.Add(testTask.ListId, new List<ToDoTask>() { testTask });
            ToDoTask testTaskTwo = new ToDoTask()
            {
                Name = "Test Task Name",
                Description = "Test Task Description",
                ListId = 1,
                Id = 2
            };
            testApp.CurrentDictOfTasks[testTaskTwo.ListId].Add(testTaskTwo);

            testApp.RemoveTask(testTask.ListId, testTask.Id);

            int expectedCount = 1;
            int actualCount = testApp.CurrentDictOfTasks[1].Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
