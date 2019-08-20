using System;
using System.Collections.Generic;

using emira.DataAccessLayer;
using emira.HelperFunctions;
using emira.GUI;
using NLog;

namespace emira.BusinessLogicLayer
{
    class AddRemoveTask
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        CustomMsgBox customMsgBox;
        DatabaseHandler DBHandler;
       
        public void SaveModification(Dictionary<string, string> data, string _taskGroupID)
        {
            try
            {
                DBHandler = new DatabaseHandler();
                DBHandler.ModifyTask(data, Texts.TaskProperties.TaskID, _taskGroupID, updatedRow: 0);
            }
            catch(Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }      
        }

        public void DeleteHours(string date, string taskID)
        {
            try
            {
                DBHandler = new DatabaseHandler();
                DBHandler.DeleteHours(date, taskID);
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
