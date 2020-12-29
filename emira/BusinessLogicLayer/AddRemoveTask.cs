using System;

using emira.DataAccessLayer;
using emira.Utilities;

namespace emira.BusinessLogicLayer
{
    class AddRemoveTask
    {
        DatabaseHandler DBHandler;
       
        public void SaveModification(string value, string groupID, string taskID)
        {
            try
            {
                DBHandler = new DatabaseHandler();
                string _command = string.Empty;

                _command = string.Format("UPDATE {0} SET {1}='{2}' WHERE {3}='{4}' AND {5}='{6}'",
                    Texts.DataTableNames.Task,
                    Texts.TaskProperties.Selected,
                    value,
                    Texts.TaskProperties.GroupID,
                    groupID,
                    Texts.TaskProperties.TaskID,
                    taskID);

                DBHandler.ModifyTask(_command);
            }
            catch(Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
            }      
        }

        public void DeleteHours(string date, string groupID, string taskID)
        {
            try
            {
                DBHandler = new DatabaseHandler();
                DBHandler.DeleteHours(date, groupID, taskID);
            }
            catch (Exception error)
            {
                MyLogger.GetInstance().Error(error.Message);
            }
        }

    }
}
