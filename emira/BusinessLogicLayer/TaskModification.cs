using KiRA.DAL;
using System.Collections.Generic;
using System.Data;

namespace KiRA.BusinessLogic
{
    class TaskModification
    {
        DatabaseHandler _DBHandler;
        DataTable _dataTable;

        public DataTable GetTasks()
        {
            _DBHandler = new DatabaseHandler();
            _dataTable = new DataTable();

            _dataTable = _DBHandler.GetTask();
            return _dataTable;
        }

        public bool AddNewTask(string taskGroupID, string taskGroup, string taskID, string taskName)
        {
            bool _isSuccess = false;
            int _result = 0;
            string _taskGroupID = Text.TaskProperties.TaskGroupID;
            string _taskGroup = Text.TaskProperties.TaskGroup;
            string _taskID = Text.TaskProperties.TaskID;
            string _taskName = Text.TaskProperties.TaskName;
            bool existGroupID = false;
            bool existGroupName = false;
            bool existTaskID = false;
            bool sameGroupIDAndGroupName = false;
            bool existTaskName = false;
            _DBHandler = new DatabaseHandler();
            string newTaskID = taskGroupID + "_" + taskID;

            // Validation
            existGroupID = _DBHandler.DoesExist(_taskGroupID, taskGroupID);
            existGroupName = _DBHandler.DoesExist(_taskGroup, taskGroup);
            existTaskID = _DBHandler.DoesExist(_taskID, newTaskID);
            sameGroupIDAndGroupName = _DBHandler.DoesItHave(_taskGroupID, taskGroupID, _taskGroup, taskGroup);
            existTaskName = _DBHandler.DoesItHave(_taskGroupID, taskGroupID, _taskName, taskName);

            if (!existGroupID && !existGroupName)
            {
                _result = _DBHandler.InsertNewTask(taskGroupID, taskGroup, newTaskID, taskName);
                if (_result > 0) _isSuccess = true;
                return _isSuccess;
            }

            if (existGroupID && sameGroupIDAndGroupName && !existTaskID && !existTaskName)
            {
                _result = _DBHandler.InsertNewTask(taskGroupID, taskGroup, newTaskID, taskName);
                if (_result > 0) _isSuccess = true;
                return _isSuccess;
            }
            
            return _isSuccess;
        }

        public bool TextBoxValueValidation(string textBoxValue)
        {
            bool isSuccess = true;
            if (string.IsNullOrEmpty(textBoxValue.Trim()) || string.IsNullOrWhiteSpace(textBoxValue))
            {
                isSuccess = false;
            }
            return isSuccess;
        }

        public bool UpdateTask(string oldTaskID, string taskGroupID, string taskGroup, string taskID, string taskName)
        {
            bool isSuccess = false;
            int updatedRow = 0;
            _DBHandler = new DatabaseHandler();
            Dictionary<string, string> data = new Dictionary<string, string>();
            data.Add(Text.TaskProperties.TaskGroupID, taskGroupID);
            data.Add(Text.TaskProperties.TaskGroup, taskGroup);
            data.Add(Text.TaskProperties.TaskID, taskID);
            data.Add(Text.TaskProperties.TaskName, taskName);
            isSuccess = _DBHandler.ModifyTask(data, Text.TaskProperties.TaskID, oldTaskID, updatedRow);
            return isSuccess;
        }

        public bool DeleteItem(string taskGroupID, string taskGroup, string taskID, string taskName)
        {
            bool isSuccess = false;
            int result = 0;
            _DBHandler = new DatabaseHandler();
            result = _DBHandler.DeleteRow(taskGroupID, taskGroup, taskID, taskName);
            if (result > 0) isSuccess = true;
            return isSuccess;
        }
    }
}
