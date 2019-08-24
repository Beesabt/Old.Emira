using System;
using System.Collections.Generic;
using System.Data;

using emira.DataAccessLayer;
using emira.HelperFunctions;
using emira.GUI;
using NLog;
using System.Text;

namespace emira.BusinessLogicLayer
{
    class TaskModification
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        CustomMsgBox customMsgBox;
        DatabaseHandler DBHandler;
        DataTable dataTable;

        /// <summary>
        /// Get the groups from the DB for combobox
        /// </summary>
        /// <returns>List of the groups</returns>
        public List<string> GetGroups(bool forCombobox = false)
        {
            List<string> _groups = new List<string>();
            try
            {
                StringBuilder _sb = new StringBuilder();
                DBHandler = new DatabaseHandler();
                dataTable = new DataTable();

                // Get the group(s)
                string _command = string.Empty;
                if (forCombobox)
                {
                    _command = string.Format("SELECT * FROM {0} WHERE {1} != '0' ORDER BY {1}",
                        Texts.DataTableNames.TaskGroup,
                        Texts.TaskGropuProperties.GroupID);
                }
                else
                {
                    _command = string.Format("SELECT * FROM {0} ORDER BY {1}",
                        Texts.DataTableNames.TaskGroup,
                        Texts.TaskGropuProperties.GroupID);
                }

                dataTable = DBHandler.GetGroups(_command);

                // Get the ID and Name for the combobox into a list
                string _actualGroupID = string.Empty;
                string _actualGroupName = string.Empty;

                foreach (DataRow item in dataTable.Rows)
                {
                    _actualGroupID = item[Texts.TaskGropuProperties.GroupID].ToString();
                    _actualGroupName = item[Texts.TaskGropuProperties.GroupName].ToString();

                    // Add to list the 'groupID groupName'
                    _sb.Append(_actualGroupID + " " + _actualGroupName);
                    _groups.Add(_sb.ToString());

                    // Clean up the string builder for the new 'groupID groupName'
                    _sb = _sb.Clear();
                }

                return _groups;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _groups;
            }
        }

        /// <summary>
        /// Get the task(s) for tree view 
        /// </summary>
        /// <returns>DataTable with the task(s)</returns>
        public DataTable GetTasks()
        {
            dataTable = new DataTable();
            try
            {
                DBHandler = new DatabaseHandler();

                dataTable = DBHandler.GetTask();

                return dataTable;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return dataTable;
            }
        }

        /// <summary>
        /// Validation of the text box against empty field
        /// </summary>
        /// <param name="textBoxValue">Textbox's value</param>
        /// <returns>True, if it is not empty</returns>
        public bool TextBoxValueValidation(string textBoxValue)
        {
            bool _isSuccess = true;
            try
            {
                if (string.IsNullOrEmpty(textBoxValue.Trim()) || string.IsNullOrWhiteSpace(textBoxValue))
                {
                    _isSuccess = false;
                }
                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }

        /// <summary>
        /// Get the next group ID for number up down
        /// </summary>
        /// <returns>Return with the next group ID</returns>
        public int GetNextGroupID()
        {
            int _nextGroupID = 1;
            try
            {
                int _maxGroupID = 0;
                DBHandler = new DatabaseHandler();

                _maxGroupID = DBHandler.GetMaxGroupID();

                _nextGroupID = _maxGroupID + 1;

                return _nextGroupID;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _nextGroupID;
            }
        }

        /// <summary>
        /// Get the next task ID for number up down
        /// </summary>
        /// <param name="groupID">Group ID of the task</param>
        /// <returns>Return with the next task ID</returns>
        public int GetNextTaskID(string groupID)
        {
            int _nextTaskID = 1;
            try
            {
                DBHandler = new DatabaseHandler();
                int _maxTaskID = 0;

                _maxTaskID = DBHandler.GetMaxTaskID(groupID);

                _nextTaskID = _maxTaskID + 1;

                return _nextTaskID;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _nextTaskID;
            }
        }


        //// ADD
        /// <summary>
        /// Add new group to the DB
        /// </summary>
        /// <param name="groupID">ID of the new group</param>
        /// <param name="groupName">Name of the new group</param>
        /// <returns>True, if the new group is added</returns>
        public bool AddNewGroup(string groupID, string groupName)
        {
            bool _isSuccess = false;
            try
            {
                bool _existGroupID = false;
                bool _existGroupName = false;
                int _result = 0;
                DBHandler = new DatabaseHandler();

                // Check the exists of the groupID and groupName
                _existGroupID = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupID, groupID);
                _existGroupName = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupName, groupName);

                // Insert the new group
                if (!_existGroupID && !_existGroupName)
                {
                    _result = DBHandler.InsertNewGroup(groupID, groupName);
                    if (_result > 0) _isSuccess = true;
                    return _isSuccess;
                }

                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }

        /// <summary>
        /// Add new task to the DB
        /// </summary>
        /// <param name="groupID">ID of the group</param>
        /// <param name="taskID">ID of the new task</param>
        /// <param name="taskName">Name of the new task</param>
        /// <returns>True, if the new task is added</returns>
        public bool AddNewTask(string groupID, string taskID, string taskName)
        {
            bool _isSuccess = false;
            try
            {
                bool _existGroupID = false;
                bool _existGroupName = false;
                int _result = 0;
                DBHandler = new DatabaseHandler();

                // Check the exists of the taskID and taskName
                _existGroupID = DBHandler.DoesItHave(groupID, Texts.TaskProperties.TaskID, taskID);
                _existGroupName = DBHandler.DoesItHave(groupID, Texts.TaskProperties.TaskName, taskName);

                // Insert the new group
                if (!_existGroupID && !_existGroupName)
                {
                    _result = DBHandler.InsertNewTask(groupID, taskID, taskName);
                    if (_result > 0) _isSuccess = true;
                    return _isSuccess;
                }

                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }


        //// UPDATE
        /// <summary>
        /// Update the group ID or Name or both (= switch)
        /// </summary>
        /// <param name="oldGroupID">old group ID</param>
        /// <param name="newGroupID">new group ID</param>
        /// <param name="oldGroupName">old group Name</param>
        /// <param name="newGroupName">new group Name</param>
        /// <returns>True, if the update was success</returns>
        public bool UpdateGroup(string oldGroupID, string newGroupID, string oldGroupName, string newGroupName)
        {
            bool _isSuccess = false;
            try
            {
                bool _existGroupID = false;
                bool _existGroupName = false;
                DBHandler = new DatabaseHandler();

                // 1. If the group ID is the same, but the group Name changed
                if (oldGroupID == newGroupID)
                {
                    _existGroupName = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupName, newGroupName);
                    if (_existGroupName) return _isSuccess;

                    // Update the group
                    Dictionary<string, string> _data = new Dictionary<string, string>();
                    _data.Add(Texts.TaskGropuProperties.GroupName, newGroupName);

                    _isSuccess = DBHandler.ModifyGroup(Texts.DataTableNames.TaskGroup, _data, Texts.TaskGropuProperties.GroupID, oldGroupID);

                    return _isSuccess;
                }

                // 2. If the group Name is the same, but the group ID changed
                if (oldGroupName == newGroupName)
                {
                    _existGroupID = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupID, newGroupID);
                    if (_existGroupID) return _isSuccess;

                    // Update the group
                    Dictionary<string, string> _data = new Dictionary<string, string>();
                    _data.Add(Texts.TaskGropuProperties.GroupID, newGroupID);

                    // Change first in the Catalog
                    DBHandler.ModifyGroup(Texts.DataTableNames.Catalog, _data, Texts.TaskGropuProperties.GroupID, oldGroupID);

                    // And then in the Task
                    DBHandler.ModifyGroup(Texts.DataTableNames.Task, _data, Texts.TaskGropuProperties.GroupID, oldGroupID);

                    // Finaly in the TaskGroup
                    _isSuccess = DBHandler.ModifyGroup(Texts.DataTableNames.TaskGroup, _data, Texts.TaskGropuProperties.GroupID, oldGroupID);

                    return _isSuccess;
                }

                // 3. If the group ID and Name are changed (= switch)
                _existGroupID = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupID, newGroupID);
                _existGroupName = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupName, newGroupName);

                if (!_existGroupID && !_existGroupName)
                {
                    // Update the group
                    Dictionary<string, string> _dataForCatalogAndTask = new Dictionary<string, string>();
                    _dataForCatalogAndTask.Add(Texts.TaskGropuProperties.GroupID, newGroupID);

                    // Change first in the Catalog
                    DBHandler.ModifyGroup(Texts.DataTableNames.Catalog, _dataForCatalogAndTask, Texts.TaskGropuProperties.GroupID, oldGroupID);

                    // And then in the Task
                    DBHandler.ModifyGroup(Texts.DataTableNames.Task, _dataForCatalogAndTask, Texts.TaskGropuProperties.GroupID, oldGroupID);

                    // It contains the new group Name as well
                    Dictionary<string, string> _data = new Dictionary<string, string>();
                    _data.Add(Texts.TaskGropuProperties.GroupID, newGroupID);
                    _data.Add(Texts.TaskGropuProperties.GroupName, newGroupName);

                    // Finaly in the TaskGroup
                    _isSuccess = DBHandler.ModifyGroup(Texts.DataTableNames.TaskGroup, _data, Texts.TaskGropuProperties.GroupID, oldGroupID);
                }

                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }

        /// <summary>
        /// Update the task ID and task Name and the group ID if it is modified
        /// </summary>
        /// <param name="newGroupID">New group ID</param>
        /// <param name="oldGroupID">Old group ID</param>
        /// <param name="newTaskID">New task ID</param>
        /// <param name="oldTaskID">Old task ID</param>
        /// <param name="newTaskName">New task Name</param>
        /// <param name="oldTaskName">Olda task Name</param>
        /// <returns>True if the update was success</returns>
        public bool UpdateTask(string newGroupID, string oldGroupID, string newTaskID, string oldTaskID, string newTaskName, string oldTaskName)
        {
            bool _isSuccess = false;
            try
            {
                bool _existTaskID = false;
                bool _existTaskName = false;
                string _command = string.Empty;

                //// IF THE GROUP IDs ARE THE SAME
                if (newGroupID == oldGroupID)
                {
                    DBHandler = new DatabaseHandler();

                    //// Check the exists of the taskID and taskName
                    // 1.If the task ID is the same, but the task Name changed
                    if (newTaskID == oldTaskID)
                    {
                        _existTaskName = DBHandler.DoesItHave(oldGroupID, Texts.TaskProperties.TaskName, newTaskName);
                        if (_existTaskName) return _isSuccess;

                        // Command for Catalog table
                        _command = string.Format("UPDATE {0} SET {1}='{2}' WHERE {3}='{4}' AND {5}='{6}' AND {7} = 0",
                            Texts.DataTableNames.Catalog,
                            Texts.CatalogProperties.TaskName,
                            newTaskName,
                            Texts.CatalogProperties.GroupID,
                            oldGroupID,
                            Texts.CatalogProperties.TaskID,
                            oldTaskID,
                            Texts.CatalogProperties.Locked);

                        // Change first in the Catalog
                        DBHandler.ModifyTask(_command);

                        // Command for Task table
                        _command = string.Format("UPDATE {0} SET {1}='{2}' WHERE {3}='{4}' AND {5}='{6}'",
                            Texts.DataTableNames.Task,
                            Texts.TaskProperties.TaskName,
                            newTaskName,
                            Texts.TaskProperties.GroupID,
                            oldGroupID,
                            Texts.TaskProperties.TaskID,
                            oldTaskID);

                        // And then in the Task table
                        _isSuccess = DBHandler.ModifyTask(_command);

                        return _isSuccess;
                    }

                    // 2.If the task Name is the same, but the task ID changed
                    if (oldTaskName == newTaskName)
                    {
                        _existTaskID = DBHandler.DoesItHave(oldGroupID, Texts.TaskProperties.TaskID, newTaskID);
                        if (_existTaskID) return _isSuccess;

                        // Command for Catalog table
                        _command = string.Format("UPDATE {0} SET {1}='{2}' WHERE {3}='{4}' AND {5}='{6}' AND {7} = 0",
                            Texts.DataTableNames.Catalog,
                            Texts.CatalogProperties.TaskID,
                            newTaskID,
                            Texts.CatalogProperties.GroupID,
                            oldGroupID,
                            Texts.CatalogProperties.TaskID,
                            oldTaskID,
                            Texts.CatalogProperties.Locked);

                        // Change first in the Catalog
                        DBHandler.ModifyTask(_command);

                        // Command for Task table
                        _command = string.Format("UPDATE {0} SET {1}='{2}' WHERE {3}='{4}' AND {1}='{5}'",
                            Texts.DataTableNames.Task,
                            Texts.TaskProperties.TaskID,
                            newTaskID,
                            Texts.TaskProperties.GroupID,
                            oldGroupID,
                            oldTaskID);

                        // And then in the Task table
                        _isSuccess = DBHandler.ModifyTask(_command);

                        return _isSuccess;
                    }

                    // 3.If the task ID and Name are changed(= switch)
                    _existTaskID = DBHandler.DoesItHave(oldGroupID, Texts.TaskProperties.TaskID, newTaskID);
                    _existTaskName = DBHandler.DoesItHave(oldGroupID, Texts.TaskProperties.TaskName, newTaskName);

                    if (!_existTaskID && !_existTaskName)
                    {
                        // Command for Catalog table
                        _command = string.Format("UPDATE {0} SET {1}='{2}', {3}='{4}' WHERE {5}='{6}' AND {1}='{7}' AND {8} = 0",
                            Texts.DataTableNames.Catalog,
                            Texts.CatalogProperties.TaskID,
                            newTaskID,
                            Texts.CatalogProperties.TaskName,
                            newTaskName,
                            Texts.CatalogProperties.GroupID,
                            oldGroupID,
                            oldTaskID,
                            Texts.CatalogProperties.Locked);

                        // Change first in the Catalog
                        DBHandler.ModifyTask(_command);

                        // Command for Task table
                        _command = string.Format("UPDATE {0} SET {1}='{2}', {3}='{4}' WHERE {5}='{6}' AND {1}='{7}'",
                            Texts.DataTableNames.Task,
                            Texts.TaskProperties.TaskID,
                            newTaskID,
                            Texts.TaskProperties.TaskName,
                            newTaskName,
                            Texts.TaskProperties.GroupID,
                            oldGroupID,
                            oldTaskID);

                        // And then in the Task table
                        _isSuccess = DBHandler.ModifyTask(_command);
                    }

                    return _isSuccess;
                }
                else
                {
                    DBHandler = new DatabaseHandler();

                    // 4.If the group ID, task ID and Name are changed(= switch)
                    _existTaskID = DBHandler.DoesItHave(newGroupID, Texts.TaskProperties.TaskID, newTaskID);
                    _existTaskName = DBHandler.DoesItHave(newGroupID, Texts.TaskProperties.TaskName, newTaskName);

                    if (!_existTaskID && !_existTaskName)
                    {
                        // Command for Catalog table
                        _command = string.Format("UPDATE {0} SET {1}='{2}', {3}='{4}', {5}='{6}' WHERE {1}='{7}' AND {3}='{8}' AND {9} = 0",
                            Texts.DataTableNames.Catalog,
                            Texts.CatalogProperties.GroupID,
                            newGroupID,
                            Texts.CatalogProperties.TaskID,
                            newTaskID,
                            Texts.CatalogProperties.TaskName,
                            newTaskName,
                            oldGroupID,
                            oldTaskID,
                            Texts.CatalogProperties.Locked);

                        // Change first in the Catalog
                        DBHandler.ModifyTask(_command);

                        // Command for Task table
                        _command = string.Format("UPDATE {0} SET {1}='{2}', {3}='{4}', {5}='{6}' WHERE {1}='{7}' AND {3}='{8}'",
                            Texts.DataTableNames.Task,
                            Texts.CatalogProperties.GroupID,
                            newGroupID,
                            Texts.CatalogProperties.TaskID,
                            newTaskID,
                            Texts.CatalogProperties.TaskName,
                            newTaskName,
                            oldGroupID,
                            oldTaskID);

                        // And then in the Task table
                        _isSuccess = DBHandler.ModifyTask(_command);
                    }
                }

                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }


        //// DELETE
        /// <summary>
        /// Get the selected task by groupID
        /// </summary>
        /// <param name="groupID">The selected group ID</param>
        /// <returns>DataTable with the selected tasks</returns>
        public DataTable GetSelectedTaskBySelectedGroup(string groupID)
        {
            dataTable = new DataTable();
            try
            {
                DBHandler = new DatabaseHandler();

                dataTable = DBHandler.GetSelectedTaskByGroup(groupID);

                return dataTable;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return dataTable;
            }
        }

        /// <summary>
        /// Get the status of the selection of the task
        /// </summary>
        /// <param name="groupID">Group ID of the task</param>
        /// <param name="taskID">Task ID of the task</param>
        /// <returns>True, if the task is selected</returns>
        public bool GetSelectionStateOfTheSelectedTask(string groupID, string taskID)
        {
            bool _selected = false;
            try
            {
                string _result = string.Empty;

                DBHandler = new DatabaseHandler();

                _result = DBHandler.isTaskSelected(groupID, taskID);

                Boolean.TryParse(_result, out _selected);

                return _selected;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _selected;
            }
        }

        /// <summary>
        /// Delete the group and tasks from Catalog and Task table
        /// </summary>
        /// <param name="groupID">The group ID what the user want to delete</param>
        /// <returns>True, if the group is deleted</returns>
        public bool DeleteGroup(string groupID)
        {
            bool _isSuccess = false;
            try
            {
                DBHandler = new DatabaseHandler();

                // Delete the task(s) from Catalog were the period is not locked
                DBHandler.DeleteUsedGroupFromCatalog(groupID);

                // Delete the task(s) from the Task which is under the selected group
                DBHandler.DeleteGroupAndTasks(Texts.DataTableNames.Task, groupID);

                // Delete the group
                _isSuccess = DBHandler.DeleteGroupAndTasks(Texts.DataTableNames.TaskGroup, groupID);

                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }

        /// <summary>
        /// Delete the task from the Catalog and Task table
        /// </summary>
        /// <param name="groupID">Group ID of the task</param>
        /// <param name="taskID">Task ID of the task</param>
        /// <returns>True, if the task is deleted</returns>
        public bool DeleteTask(string groupID, string taskID)
        {
            bool _isSuccess = false;
            try
            {
                DBHandler = new DatabaseHandler();

                // Delete the task(s) from Catalog were the period is not locked
                DBHandler.DeleteUsedTaskFromCatalog(groupID, taskID);

                // Delete the task(s) from the Task which is under the selected group
                _isSuccess = DBHandler.DeleteTask(groupID, taskID);

                return _isSuccess;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return _isSuccess;
            }
        }




        /// <summary>
        /// Get tasks for export
        /// </summary>
        /// <param name="withSelected">Only just the selected tasks</param>
        /// <returns>DataTable with the informations</returns>
        public DataTable GetTasksForExport()
        {
            dataTable = new DataTable();
            try
            {
                DBHandler = new DatabaseHandler();
                dataTable = DBHandler.GetTaskForExport();
                return dataTable;
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
                return dataTable;
            }
        }
    }
}
