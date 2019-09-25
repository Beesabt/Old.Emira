using System;

using emira.DataAccessLayer;
using emira.HelperFunctions;
using emira.GUI;
using NLog;

namespace emira.BusinessLogicLayer
{
    class AddRemoveTask
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        CustomMsgBox customMsgBox;
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
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
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
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }

    }
}
