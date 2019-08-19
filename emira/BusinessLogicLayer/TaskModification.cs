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

        public DataTable GetTasks(bool withSelected = true)
        {
            string command = string.Empty;
            if (!withSelected)
            {
                command = string.Format("SELECT {1},{2},{3},{4} FROM {0} ORDER BY {1}", Texts.DataTableNames.Task,
                            Texts.TaskProperties.TaskGroupID,
                            Texts.TaskProperties.TaskGroupName,
                            Texts.TaskProperties.TaskID,
                            Texts.TaskProperties.TaskName);
            }
            else
            {
                command = string.Format("SELECT * FROM {0} ORDER BY {1}", Texts.DataTableNames.Task, Texts.TaskProperties.TaskGroupID);
            }

            DBHandler = new DatabaseHandler();
            dataTable = new DataTable();

            dataTable = DBHandler.GetTask(command);
            return dataTable;
        }

        /// <summary>
        /// Get the groups from the DB
        /// </summary>
        /// <returns>List of the groups</returns>
        public List<string> GetGroups()
        {
            List<string> _groups = new List<string>();
            try
            {
                StringBuilder _sb = new StringBuilder();
                DBHandler = new DatabaseHandler();
                dataTable = new DataTable();

                // Get the group(s)
                dataTable = DBHandler.GetGroups();

                // Remove the first one because it is reserved
                dataTable.Rows.RemoveAt(0);

                string _actualMonth = string.Empty;
                string _actualYear = string.Empty;

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
                int _groupID = -1; // 0 is reserved for 'Távollét'
                int _result = 0;
                DBHandler = new DatabaseHandler();

                // Get groupID as int
                Int32.TryParse(groupID, out _groupID);

                // Check the exists of the groupID and groupName
                _existGroupID = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupID, groupID);
                _existGroupName = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupName, groupName);

                // Insert the new group
                if (!_existGroupID && !_existGroupName)
                {
                    _result = DBHandler.InsertNewGroup(_groupID, groupName);
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

        public bool AddNewTask(string taskGroupID, string taskGroup, string taskID, string taskName)
        {
            bool _isSuccess = false;
            int _result = 0;
            string _taskGroupID = Texts.TaskProperties.TaskGroupID;
            string _taskGroup = Texts.TaskProperties.TaskGroupName;
            string _taskID = Texts.TaskProperties.TaskID;
            string _taskName = Texts.TaskProperties.TaskName;
            bool existGroupID = false;
            bool existGroupName = false;
            bool existTaskID = false;
            bool sameGroupIDAndGroupName = false;
            bool existTaskName = false;
            DBHandler = new DatabaseHandler();
            string newTaskID = taskGroupID + "_" + taskID;

            // Validation
            existGroupID = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, _taskGroupID, taskGroupID);
            existGroupName = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, _taskGroup, taskGroup);
            existTaskID = DBHandler.DoesExist(Texts.DataTableNames.Task, _taskID, newTaskID);
            sameGroupIDAndGroupName = DBHandler.DoesItHave(_taskGroupID, taskGroupID, _taskGroup, taskGroup);
            existTaskName = DBHandler.DoesItHave(_taskGroupID, taskGroupID, _taskName, taskName);

            if (!existGroupID && !existGroupName)
            {
                _result = DBHandler.InsertNewTask(taskGroupID, taskGroup, newTaskID, taskName);
                if (_result > 0) _isSuccess = true;
                return _isSuccess;
            }

            if (existGroupID && sameGroupIDAndGroupName && !existTaskID && !existTaskName)
            {
                _result = DBHandler.InsertNewTask(taskGroupID, taskGroup, newTaskID, taskName);
                if (_result > 0) _isSuccess = true;
                return _isSuccess;
            }

            return _isSuccess;
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
                int _groupID = -1; // 0 is reserved for 'Távollét'
                int _updatedRow = 0;

                // Get groupID as int
                Int32.TryParse(newGroupID, out _groupID);

                // Check the exists of the groupID and groupName
                // 1. If the group ID is the same, but the group name changed
                if (oldGroupID == newGroupID)
                {
                    _existGroupName = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupName, newGroupName);
                    if (_existGroupName) return _isSuccess;

                    // Update the group
                    DBHandler = new DatabaseHandler();

                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add(Texts.TaskGropuProperties.GroupID, newGroupID);
                    data.Add(Texts.TaskGropuProperties.GroupName, newGroupName);

                    _isSuccess = DBHandler.ModifyGroup(data, Texts.TaskGropuProperties.GroupID, oldGroupID, _updatedRow);

                    return _isSuccess;
                }

                // 2. If the group Name is the same, but the group ID changed
                if (oldGroupName == newGroupName)
                {
                    _existGroupID = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupID, newGroupID);
                    if (_existGroupID) return _isSuccess;

                    // Update the group
                    DBHandler = new DatabaseHandler();

                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add(Texts.TaskGropuProperties.GroupID, newGroupID);
                    data.Add(Texts.TaskGropuProperties.GroupName, newGroupName);

                    _isSuccess = DBHandler.ModifyGroup(data, Texts.TaskGropuProperties.GroupID, oldGroupID, _updatedRow);

                    return _isSuccess;
                }

                // 3. If the group ID and Name are changed (= switch)
                _existGroupID = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupID, newGroupID);
                _existGroupName = DBHandler.DoesExist(Texts.DataTableNames.TaskGroup, Texts.TaskGropuProperties.GroupName, newGroupName);

                if (!_existGroupID && !_existGroupName)
                {
                    // Update the group
                    DBHandler = new DatabaseHandler();

                    Dictionary<string, string> data = new Dictionary<string, string>();
                    data.Add(Texts.TaskGropuProperties.GroupID, newGroupID);
                    data.Add(Texts.TaskGropuProperties.GroupName, newGroupName);

                    _isSuccess = DBHandler.ModifyGroup(data, Texts.TaskGropuProperties.GroupID, oldGroupID, _updatedRow);
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

        public bool UpdateTask(string oldTaskID, string taskGroupID, string taskGroup, string taskID, string taskName)
        {
            bool isSuccess = false;
            int updatedRow = 0;
            DBHandler = new DatabaseHandler();
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(Texts.TaskProperties.TaskGroupID, taskGroupID);
            data.Add(Texts.TaskProperties.TaskGroupName, taskGroup);
            data.Add(Texts.TaskProperties.TaskID, taskID);
            data.Add(Texts.TaskProperties.TaskName, taskName);
            isSuccess = DBHandler.ModifyTask(data, Texts.TaskProperties.TaskID, oldTaskID, updatedRow);
            return isSuccess;
        }

        public bool DeleteItem(string taskGroupID, string taskGroup, string taskID, string taskName)
        {
            bool isSuccess = false;
            int result = 0;
            DBHandler = new DatabaseHandler();
            result = DBHandler.DeleteRow(taskGroupID, taskGroup, taskID, taskName);
            if (result > 0) isSuccess = true;
            return isSuccess;
        }

    }
}
