using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeApp.Models;
using PracticeApp;
using System.Collections.Generic;
using System;

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
                ListId = Guid.NewGuid()
            };
            testApp.AddNewTask(testTask);

            int expectedCount = 1;
            string expectedName = testTask.Name;
            string expectedDesc = testTask.Description;
            Guid? expectedListId = testTask.ListId;
            Guid? expectedId = testTask.Id;

            ToDoTask addedToDoTask = testApp.CurrentToDoTasks.Find(t=> t.Id == testTask.Id);

            int actualCount = testApp.CurrentToDoTasks.Count;
            string actualName = addedToDoTask.Name;
            string actualDesc = addedToDoTask.Description;
            Guid? actualListId = addedToDoTask.ListId;
            Guid? actualId = addedToDoTask.Id;

            Assert.AreEqual(expectedCount, actualCount);
            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDesc, actualDesc);
            Assert.AreEqual(expectedListId, actualListId);
            Assert.AreEqual(expectedId, actualId);

        }
        [TestMethod]
        public void TestUpdateToDoTask()
        {
            ToDoApp testApp = new ToDoApp();
            ToDoTask testTask = new ToDoTask()
            {
                Name = "Test Task Name",
                Description = "Test Task Description",
                ListId = Guid.NewGuid(),
            };
            testApp.CurrentToDoTasks.Add(testTask);

            ToDoTask updatedTask = new ToDoTask()
            {
                Name = "Name Test Task",
                Description = "Description Test Task",
                ListId = testTask.ListId,
                Id = testTask.Id
            };

            testApp.UpdateToDoTask(updatedTask);

            string expectedName = updatedTask.Name;
            string expectedDesc = updatedTask.Description;
            Guid? expectedListId = updatedTask.ListId;
            Guid? expectedId = updatedTask.Id;

            ToDoTask addedToDoTask = testApp.CurrentToDoTasks.Find(t => t.Id == testTask.Id);

            string actualName = addedToDoTask.Name;
            string actualDesc = addedToDoTask.Description;
            Guid? actualListId = addedToDoTask.ListId;
            Guid? actualId = addedToDoTask.Id;

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
                ListId = Guid.NewGuid(),
            };
            testApp.CurrentToDoTasks.Add(testTask);
            ToDoTask testTaskTwo = new ToDoTask()
            {
                Name = "Test Task Name",
                Description = "Test Task Description",
                ListId = Guid.NewGuid(),
            };
            testApp.CurrentToDoTasks.Add(testTaskTwo);

            testApp.RemoveTask(testTask.Id);

            int expectedCount = 1;
            int actualCount = testApp.CurrentToDoTasks.Count;

            Assert.AreEqual(expectedCount, actualCount);
        }
    }
}
