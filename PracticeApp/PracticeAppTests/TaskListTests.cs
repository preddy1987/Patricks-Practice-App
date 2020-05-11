using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeApp.Models;
using PracticeApp;
using System.Collections.Generic;
using System;
using System.Linq;

namespace PracticeAppTests
{
    [TestClass]
    public class TaskListTests
    {
        [TestMethod]
        public void TestSetSelectedTaskList()
        {
            ToDoApp testPracticeApp = new ToDoApp();
            TaskList testTaskList = new TaskList()
            {
                Name = "Test Task List",
                Description = "Testing the Task List",
            };

            testPracticeApp.CurrentTaskLists.Add(testTaskList);
            testPracticeApp.SetSelectedTaskList(testTaskList.Id);

            string expectedName = testTaskList.Name;
            string expectedDesc = testTaskList.Description;
            Guid? expectedId = testTaskList.Id;

            string actualName = testPracticeApp.SelectedTaskList.Name;
            string actualDesc = testPracticeApp.SelectedTaskList.Description;
            Guid? actualId = testPracticeApp.SelectedTaskList.Id;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDesc, actualDesc);
            Assert.AreEqual(expectedId, actualId);
        }
        [TestMethod]
        public void TestAddNewTaskList()
        {
            ToDoApp testPracticeApp = new ToDoApp();
            TaskList testTaskList = new TaskList()
            {
                Name = "Test Task List",
                Description = "Testing the Task List"
            };
            testPracticeApp.AddNewTaskList(testTaskList);

            string expectedName = testTaskList.Name;
            string expectedDesc = testTaskList.Description;
            Guid? expectedId = testTaskList.Id;

            TaskList addedTaskList = testPracticeApp.CurrentTaskLists.Find(t => t.Id == testTaskList.Id);

            string actualName = addedTaskList.Name;
            string actualDesc = addedTaskList.Description;
            Guid? actualId = addedTaskList.Id;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDesc, actualDesc);
            Assert.AreEqual(expectedId, actualId);
        }
        [TestMethod]
        public void TestUpdateTaskList()
        {
            ToDoApp testPracticeApp = new ToDoApp();
            TaskList testTaskList = new TaskList()
            {
                Name = "Test Task List",
                Description = "Testing the Task List"
            };
            testPracticeApp.CurrentTaskLists.Add(testTaskList);

            TaskList updatedTaskList = new TaskList()
            {
                Name = "Test Task List Test Test",
                Description = "Testing the Task List Test Test",
                Id = testTaskList.Id
            };

            testPracticeApp.UpdateTaskList(updatedTaskList);

            string expectedName = updatedTaskList.Name;
            string expectedDesc = updatedTaskList.Description;
            Guid? expectedId = updatedTaskList.Id;

            TaskList addedTaskList = testPracticeApp.CurrentTaskLists.Find(t => t.Id == testTaskList.Id);

            string actualName = addedTaskList.Name;
            string actualDesc = addedTaskList.Description;
            Guid? actualId = addedTaskList.Id;

            Assert.AreEqual(expectedName, actualName);
            Assert.AreEqual(expectedDesc, actualDesc);
            Assert.AreEqual(expectedId, actualId);
        }
        [TestMethod]
        public void TestRemoveTaskList()
        {

            ToDoApp testPracticeApp = new ToDoApp();
            #region Create Three TaskLists
            TaskList testTaskList = new TaskList()
            {
                Name = "Test Task List 1",
                Description = "Testing the Task List 1",
            };
            testPracticeApp.CurrentTaskLists.Add(testTaskList);
            TaskList testTaskListTwo = new TaskList()
            {
                Name = "Test Task List 2",
                Description = "Testing the Task List 2",
            };
            testPracticeApp.CurrentTaskLists.Add(testTaskListTwo);
            TaskList testTaskListThree = new TaskList()
            {
                Name = "Test Task List 3",
                Description = "Testing the Task List 3",
            };
            testPracticeApp.CurrentTaskLists.Add(testTaskListThree);
            #endregion

            testPracticeApp.RemoveTaskList(testTaskListTwo.Id);

            int expectedCount = 2;
            string expectedTaskListName = testTaskListThree.Name;
            string expectedTaskListDesc = testTaskListThree.Description;

            int actualTaskListCount = testPracticeApp.CurrentTaskLists.Count;
            string actualTaskListName = testPracticeApp.CurrentTaskLists[1].Name;
            string actualTaskListDesc = testPracticeApp.CurrentTaskLists[1].Description;

            Assert.AreEqual(expectedCount, actualTaskListCount);
            Assert.AreEqual(expectedTaskListName, actualTaskListName);
            Assert.AreEqual(expectedTaskListDesc, actualTaskListDesc);
        }

    }
}
