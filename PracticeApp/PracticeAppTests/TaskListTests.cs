using Microsoft.VisualStudio.TestTools.UnitTesting;
using PracticeApp.Models;
using PracticeApp;
using System.Collections.Generic;

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
        public void TestRemoveListandTasks()
        {
            ToDoApp testPracticeApp = new ToDoApp();

            #region Create Three TaskLists
            TaskList testTaskList = new TaskList()
            {
                Name = "Test Task List 1",
                Description = "Testing the Task List 1",
                Id = 1
            };
            testPracticeApp.CurrentDictOfTaskLists.Add((int)testTaskList.Id, testTaskList);
            TaskList testTaskListTwo = new TaskList()
            {
                Name = "Test Task List 2",
                Description = "Testing the Task List 2",
                Id = 2
            };
            testPracticeApp.CurrentDictOfTaskLists.Add((int)testTaskListTwo.Id, testTaskListTwo);
            TaskList testTaskListThree = new TaskList()
            {
                Name = "Test Task List 3",
                Description = "Testing the Task List 3",
                Id = 3
            };
            testPracticeApp.CurrentDictOfTaskLists.Add((int)testTaskListThree.Id, testTaskListThree);
            #endregion

            #region Create Three ToDoTasks per TaskList
            ToDoTask taskOne = new ToDoTask()
            {
                Id = 1,
                Name = "Task 1 Orginal List 1",
                Description = "Test Task 1",
                ListId = 1
            };           
            ToDoTask taskTwo = new ToDoTask()
            {
                Id = 2,
                Name = "Task 2",
                Description = "Test Task 2",
                ListId = 1
            };
            ToDoTask taskThree = new ToDoTask()
            {
                Id = 3,
                Name = "Task 3 Orginal List 1",
                Description = "Test Task 3",
                ListId = 1
            };
            testPracticeApp.CurrentDictOfTasks.Add(taskOne.ListId, new List<ToDoTask>() { taskOne, taskTwo, taskThree });

            ToDoTask taskFour = new ToDoTask()
            {
                Id = 1,
                Name = "Task 1 Orginal List 2",
                Description = "Test Task 1",
                ListId = 2
            };           
            ToDoTask taskFive = new ToDoTask()
            {
                Id = 2,
                Name = "Task 2 Orginal List 2",
                Description = "Test Task 2",
                ListId = 2
            };
            ToDoTask taskSix = new ToDoTask()
            {
                Id = 3,
                Name = "Task 3 Orginal List 2",
                Description = "Test Task 3",
                ListId = 2
            };
            testPracticeApp.CurrentDictOfTasks.Add(taskFour.ListId, new List<ToDoTask>() { taskFour, taskFive, taskSix });

            ToDoTask taskSeven = new ToDoTask()
            {
                Id = 1,
                Name = "Task 1 Orginal List 3",
                Description = "Test Task 1",
                ListId = 3
            };
            ToDoTask taskEight = new ToDoTask()
            {
                Id = 2,
                Name = "Task 2 Orginal List 3",
                Description = "Test Task 2",
                ListId = 3
            };
            ToDoTask taskNine = new ToDoTask()
            {
                Id = 3,
                Name = "Task 3 Orginal List 3",
                Description = "Test Task 3",
                ListId = 3
            };
            testPracticeApp.CurrentDictOfTasks.Add(taskSeven.ListId, new List<ToDoTask>() { taskSeven, taskEight, taskNine });
            #endregion

            testPracticeApp.RemoveListandTasks(testTaskListTwo.Id);

            int expectedCount = 2;
            string expectedTaskListName = testTaskListThree.Name;
            string expectedTaskListDesc = testTaskListThree.Description;
            string expectedToDoTaskName = taskSeven.Name;

            int actualTaskListCount = testPracticeApp.CurrentDictOfTaskLists.Count;
            int actualToDoTaskCount = testPracticeApp.CurrentDictOfTasks.Count;

            string actualTaskListName = testPracticeApp.CurrentDictOfTaskLists[2].Name;
            string actualTaskListDesc = testPracticeApp.CurrentDictOfTaskLists[2].Description;
            string actualToDoTaskName = testPracticeApp.CurrentDictOfTasks[2][0].Name;

            Assert.AreEqual(expectedCount, actualTaskListCount);
            Assert.AreEqual(expectedCount, actualToDoTaskCount);
            Assert.AreEqual(expectedTaskListName, actualTaskListName);
            Assert.AreEqual(expectedTaskListDesc, actualTaskListDesc);
            Assert.AreEqual(expectedToDoTaskName, actualToDoTaskName);
        }
    }
}
