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
        public void TestGetToDoTasks()
        {
            List<TaskList> taskLists = new List<TaskList>();
            List<ToDoTask> toDoTasks = new List<ToDoTask>();
            int numberOfListsToMake = 3;
            int numberOfTasksPerList = 3;
            
            for(int i = 1;i <= numberOfListsToMake; i++)
            {
                TaskList taskList = new TaskList()
                {
                    Name = $"Test List #{i}",
                    Description = $"Test Desc {i}"
                };
                taskLists.Add(taskList);
                for(int x = 1; x <= numberOfTasksPerList; x++)
                {
                    ToDoTask toDoTask = new ToDoTask()
                    {
                        Name = $"Test Task #{x} for {taskList.Name}",
                        Description = $"Test Desc {x} for {taskList.Description}",
                        ListId = taskList.Id
                    };
                    toDoTasks.Add(toDoTask);
                }
            }
            ToDoApp testPracticeApp = new ToDoApp(taskLists, toDoTasks);

            int selectedListForTest = 2;
            int taskSelectBaseOnList = (selectedListForTest * 3) - 2;

            List<ToDoTask> tasksFromList = testPracticeApp.GetToDoTasks(testPracticeApp.CurrentTaskLists[selectedListForTest - 1].Id);

            int expectedListCount = numberOfTasksPerList;
            string expectedTaskName = toDoTasks[taskSelectBaseOnList].Name;
            string expectedTaskDesc = toDoTasks[taskSelectBaseOnList].Description;
            Guid? expectedTaskId = toDoTasks[taskSelectBaseOnList].ListId;

            int actualListCount = tasksFromList.Count;
            string actualTaskName = tasksFromList[1].Name;
            string actualTaskDesc = tasksFromList[1].Description;
            Guid? actualTaskId = tasksFromList[1].ListId;

            Assert.AreEqual(expectedListCount, actualListCount);
            Assert.AreEqual(expectedTaskName, actualTaskName);
            Assert.AreEqual(expectedTaskDesc, actualTaskDesc);
            Assert.AreEqual(expectedTaskId, actualTaskId);

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
