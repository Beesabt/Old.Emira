using emira.DataAccessLayer;
using emira.HelperFunctions;
using System.Collections.Generic;
using System.Data;

namespace emira.BusinessLogicLayer
{
    class AddRemoveTask
    {
        DatabaseHandler _DBHandler;
        DataTable _dataTable;

        public DataTable GetTask()
        {
            _DBHandler = new DatabaseHandler();
            _dataTable = new DataTable();

            _dataTable = _DBHandler.GetTask();
        
            return _dataTable;
        }

        public void SaveModification(Dictionary<string, string> data, string _taskGroupID)
        {
            _DBHandler = new DatabaseHandler();
            _DBHandler.ModifyTask(data, Texts.TaskProperties.TaskID, _taskGroupID, updatedRow: 0);           
        }
    }
}
