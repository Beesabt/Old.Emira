using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

using emira.HelperFunctions;
using emira.GUI;
using NLog;

namespace emira.DataAccessLayer
{
    class DatabaseHandler
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        string command = string.Empty;
        string sResult = string.Empty;
        int iResult = 0;
        bool bResult = false;
        private SQLiteConnection sqlite;
        SQLiteCommand SQLiteCommand;
        DataTable dataTable;
        SQLiteDataAdapter dataAdapter;
        CustomMsgBox customMsgBox;

        public DatabaseHandler()
        {
            try
            {
                string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
                string path = (System.IO.Path.GetDirectoryName(executable));
                AppDomain.CurrentDomain.SetData("DataDirectory", path);
                sqlite = new SQLiteConnection(@"Data Source = |DataDirectory|\ApplicationFiles\DataBase\Emira_Database.db; Version = 3;");
            }
            catch (Exception error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
        }


        private int ExecuteScalar(string command)
        {
            try
            {
                SQLiteCommand = new SQLiteCommand();
                SQLiteCommand = sqlite.CreateCommand();
                SQLiteCommand.CommandText = command;
                SQLiteCommand.Connection = sqlite;
                sqlite.Open();

                var obj = SQLiteCommand.ExecuteScalar();

                if (obj == null) { return 0; }
                Int32.TryParse(obj.ToString(), out iResult);
            }
            catch (SQLiteException error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
            finally
            {
                sqlite.Close();
            }
            return iResult;
        }

        private string GetString(string command)
        {
            try
            {
                SQLiteCommand = new SQLiteCommand();
                SQLiteCommand = sqlite.CreateCommand();
                SQLiteCommand.CommandText = command;
                sqlite.Open();

                var obj = SQLiteCommand.ExecuteScalar();

                if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                {
                    return string.Empty;
                }
                else
                {
                    sResult = obj.ToString();
                }
            }
            catch (SQLiteException error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
            finally
            {
                sqlite.Close();
            }
            return sResult;
        }

        private int ExecuteNonQuery(string command)
        {
            try
            {
                SQLiteCommand = new SQLiteCommand();
                SQLiteCommand = sqlite.CreateCommand();
                SQLiteCommand.CommandText = command;
                sqlite.Open();

                iResult = SQLiteCommand.ExecuteNonQuery();
            }
            catch (SQLiteException error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
            finally
            {
                sqlite.Close();
            }
            return iResult;
        }

        private bool Update(string tableName, Dictionary<string, string> data, string where)
        {
            string _vals = string.Empty;

            try
            {
                if (data.Count >= 1)
                {
                    foreach (KeyValuePair<string, string> val in data)
                    {
                        _vals += string.Format("{0}='{1}',", val.Key.ToString(), val.Value.ToString());
                    }
                    _vals = _vals.Substring(0, _vals.Length - 1);
                }

                string command = string.Format("UPDATE {0} SET {1} WHERE {2}", tableName, _vals, where);
                SQLiteCommand = new SQLiteCommand();
                SQLiteCommand = sqlite.CreateCommand();
                SQLiteCommand.CommandText = command;
                sqlite.Open();

                iResult = SQLiteCommand.ExecuteNonQuery();

                if (iResult > 0) bResult = true;
            }
            catch (SQLiteException error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
            finally
            {
                sqlite.Close();
            }
            return bResult;
        }

        private DataTable GetDataTable(string command)
        {
            try
            {
                SQLiteCommand = new SQLiteCommand();
                SQLiteCommand = sqlite.CreateCommand();
                SQLiteCommand.CommandText = command;
                sqlite.Open();

                dataAdapter = new SQLiteDataAdapter(SQLiteCommand);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
            }
            catch (SQLiteException error)
            {
                Logger.Error(error);
                customMsgBox = new CustomMsgBox();
                customMsgBox.Show(Texts.ErrorMessages.SomethingUnexpectedHappened, Texts.Captions.Error, CustomMsgBox.MsgBoxIcon.Error, CustomMsgBox.Button.Close);
            }
            finally
            {
                sqlite.Close();
            }
            return dataTable;
        }



        #region Login.cs

        public bool LoginValidationDB(string email, string password)
        {
            string command = string.Format("SELECT COUNT({1}) FROM {0} WHERE {1}='{2}' and {3}='{4}'",
                Texts.DataTableNames.Person,
                Texts.PersonProperties.Email,
                email,
                Texts.PersonProperties.Password,
                password);
            if (ExecuteScalar(command) != 0) bResult = true;
            return bResult;
        }

        public int GetUserID(string email, string password)
        {
            string command = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}' AND {4}='{5}'",
                 Texts.PersonProperties.RowID,
                 Texts.DataTableNames.Person,
                 Texts.PersonProperties.Email,
                 email,
                 Texts.PersonProperties.Password,
                 password);
            iResult = ExecuteScalar(command);
            return iResult;
        }

        #endregion

        #region Home.cs

        public string GetPassword(string email)
        {
            string command = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}'",
                 Texts.PersonProperties.Password,
                 Texts.DataTableNames.Person,
                 Texts.PersonProperties.Email,
                 email);
            sResult = GetString(command);
            return sResult;
        }

        #endregion

        #region Settings.cs

        public bool OldValueValidationDB(string key, string value)
        {
            string command = string.Format("SELECT COUNT({1}) FROM {0} WHERE {1}='{2}'",
                Texts.DataTableNames.Person,
                key,
                value);
            if (ExecuteScalar(command) != 0) bResult = true;
            return bResult;
        }

        public bool SetNewValueDB(Dictionary<string, string> data, string key, string value)
        {
            bResult = Update(Texts.DataTableNames.Person, data, string.Format("{0}='{1}'", key, value));
            return bResult;
        }

        public DataTable GetSomePersonalInforamtionFromDB()
        {
            string command = string.Format("SELECT {0},{1},{2},{3},{4} FROM {5}",
                Texts.PersonProperties.Name,
                Texts.PersonProperties.RegisterNumber,
                Texts.PersonProperties.Company,
                Texts.PersonProperties.CostCenter,
                Texts.PersonProperties.Position,
                Texts.DataTableNames.Person);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public DataTable GetPersonalInformationDB()
        {
            string command = string.Format("SELECT * FROM {0}", Texts.DataTableNames.Person);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        #endregion

        #region TaskModification.cs 

        public int GetMaxGroupID()
        {
            string command = string.Format("SELECT MAX({0}) FROM {1}",
                Texts.TaskGropuProperties.GroupID,
                Texts.DataTableNames.TaskGroup);
            iResult = ExecuteScalar(command);
            return iResult;
        }

        public int GetMaxTaskID(string groupID)
        {
            string command = string.Format("SELECT MAX({0}) FROM {1} WHERE {2} = {3}",
                Texts.TaskProperties.TaskID,
                Texts.DataTableNames.Task,
                Texts.TaskProperties.GroupID,
                groupID);
            iResult = ExecuteScalar(command);
            return iResult;
        }

        public DataTable GetGroups(string command)
        {
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public DataTable GetTaskForExport()
        {
            command = string.Format("SELECT {0}.{2}, TaskGroup.{3}, {0}.{4}, {0}.{5}, {0}.{6} FROM {0} JOIN {1} USING ({2}) WHERE {0}.{2} != '0' ORDER BY {0}.{2}, {0}.{4}",
                Texts.DataTableNames.Task,
                Texts.DataTableNames.TaskGroup,
                Texts.TaskProperties.GroupID,
                Texts.TaskGropuProperties.GroupName,
                Texts.TaskProperties.TaskID,
                Texts.TaskProperties.TaskName,
                Texts.TaskProperties.Selected);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public int InsertNewGroup(string groupID, string groupName)
        {
            string command = string.Format("INSERT INTO {0} ({1}, {2}) VALUES ('{3}', '{4}')",
                Texts.DataTableNames.TaskGroup,
                Texts.TaskGropuProperties.GroupID,
                Texts.TaskGropuProperties.GroupName,
                groupID,
                groupName);
            iResult = ExecuteNonQuery(command);
            return iResult;
        }

        public int InsertNewTask(string groupID, string taskID, string taskName)
        {
            string command = string.Format("INSERT INTO {0} ({1}, {2}, {3}, {4}) VALUES ('{5}', '{6}', '{7}', 0)",
                Texts.DataTableNames.Task,
                Texts.TaskProperties.GroupID,
                Texts.TaskProperties.TaskID,
                Texts.TaskProperties.TaskName,
                Texts.TaskProperties.Selected,
                groupID,
                taskID,
                taskName);
            iResult = ExecuteNonQuery(command);
            return iResult;
        }

        public bool ModifyGroup(string tableName, Dictionary<string, string> data, string key, string value)
        {
            bResult = Update(tableName, data, string.Format("{0}='{1}'", key, value));
            return bResult;
        }

        public bool ModifyTask(string command)
        {
            iResult = ExecuteNonQuery(command);
            if (iResult > 0) bResult = true;
            return bResult;
        }

        public bool DeleteGroupAndTasks(string dataTableName, string groupID)
        {
            string command = string.Format("DELETE FROM {0} WHERE {1}='{2}'",
                          dataTableName,
                          Texts.TaskProperties.GroupID,
                          groupID);
            iResult = ExecuteNonQuery(command);
            if (iResult > 0) bResult = true;
            return bResult;
        }

        public bool DeleteUsedGroupFromCatalog(string groupID)
        {
            string command = string.Format("DELETE FROM {0} WHERE {1}='{2}' AND {3} = 0",
                          Texts.DataTableNames.Catalog,
                          Texts.CatalogProperties.GroupID,
                          groupID,
                          Texts.CatalogProperties.Locked);
            iResult = ExecuteNonQuery(command);
            if (iResult > 0) bResult = true;
            return bResult;
        }

        public string isTaskSelected(string groupID, string taskID)
        {
            command = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}' AND {4}='{5}'",
                Texts.TaskProperties.Selected,
                Texts.DataTableNames.Task,
                Texts.TaskProperties.GroupID,
                groupID,
                Texts.TaskProperties.TaskID,
                taskID);
            dataTable = new DataTable();
            sResult = GetString(command);
            return sResult;
        }

        public bool DeleteTask(string groupID, string taskID)
        {
            string command = string.Format("DELETE FROM {0} WHERE {1}='{2}' AND {3}='{4}'",
                Texts.DataTableNames.Task,
                Texts.TaskProperties.GroupID,
                groupID,
                Texts.TaskProperties.TaskID,
                taskID);
            iResult = ExecuteNonQuery(command);
            if (iResult > 0) bResult = true;
            return bResult;
        }

        public bool DeleteUsedTaskFromCatalog(string groupID, string taskID)
        {
            string command = string.Format("DELETE FROM {0} WHERE {1}='{2}' AND {3}='{4}' AND {5} = 0",
                          Texts.DataTableNames.Catalog,
                          Texts.CatalogProperties.GroupID,
                          groupID,
                          Texts.CatalogProperties.TaskID,
                          taskID,
                          Texts.CatalogProperties.Locked);
            iResult = ExecuteNonQuery(command);
            if (iResult > 0) bResult = true;
            return bResult;
        }


        public bool DoesExist(string tableName, string columName, string value)
        {
            string command = string.Format("SELECT COUNT({1}) FROM {0} WHERE {1}='{2}'",
                tableName,
                columName,
                value);
            if (ExecuteScalar(command) != 0) bResult = true;
            return bResult;
        }

        public bool DoesItHave(string groupID, string key, string value)
        {
            string command = string.Format("SELECT COUNT({1}) FROM {0} WHERE {2}='{3}' AND {1} = '{4}'",
                Texts.DataTableNames.Task,
                Texts.TaskProperties.GroupID,
                key,
                value,
                groupID);
            if (ExecuteScalar(command) != 0) bResult = true;
            return bResult;
        }

        public void DeleteNotLockedItemsFromCatalog()
        {
            string command = string.Format("DELETE FROM {0} WHERE {1} = 0 AND {2} != 0",
               Texts.DataTableNames.Catalog,
               Texts.CatalogProperties.Locked,
               Texts.CatalogProperties.GroupID);
            ExecuteNonQuery(command);
        }

        public void DeleteAllFromTask()
        {
            string command = string.Format("DELETE FROM {0} WHERE {1} != 0",
                Texts.DataTableNames.Task,
                Texts.TaskProperties.GroupID);
            ExecuteNonQuery(command);
        }

        public void DeleteAllFromTaskGroup()
        {
            string command = string.Format("DELETE FROM {0} WHERE {1} != 0",
                Texts.DataTableNames.TaskGroup,
                Texts.TaskProperties.GroupID);
            ExecuteNonQuery(command);
        }

        #endregion

        #region Holiday.cs

        public DataTable GetPersonalInformationDBForHoliday()
        {
            string command = string.Format("SELECT {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7} FROM {8}",
                Texts.PersonProperties.DateOfBirth,
                Texts.PersonProperties.DateOfStart,
                Texts.PersonProperties.NumberOfChildren,
                Texts.PersonProperties.NumberOfDisabledChildren,
                Texts.PersonProperties.NumberOfNewBornBabies,
                Texts.PersonProperties.HealthDamage,
                Texts.PersonProperties.HolidaysLeftFromPreviousYear,
                Texts.PersonProperties.ExtraHoliday,
                Texts.DataTableNames.Person);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public string GetTheSmallestYear()
        {
            string command = string.Format("SELECT MIN({0}) FROM {1}",
                Texts.HolidayProperties.StartDate,
                Texts.DataTableNames.Holiday);
            sResult = GetString(command);
            return sResult;
        }

        public DataTable GetHolidaysFromDB(string selectedYear, bool selectedStatus)
        {
            if (selectedStatus)
            {
                command = string.Format("SELECT {0}, {1}, {2}, {3} FROM {4} WHERE {3} = 1 AND {1} LIKE '{5}%' ORDER BY {1}",
                    Texts.HolidayProperties.RowID,
                    Texts.HolidayProperties.StartDate,
                    Texts.HolidayProperties.EndDate,
                    Texts.HolidayProperties.Status,
                    Texts.DataTableNames.Holiday,
                    selectedYear);
            }
            else
            {
                command = string.Format("SELECT {0}, {1}, {2}, {3} FROM {4} WHERE {1} LIKE '{5}%' ORDER BY {1}",
                    Texts.HolidayProperties.RowID,
                    Texts.HolidayProperties.StartDate,
                    Texts.HolidayProperties.EndDate,
                    Texts.HolidayProperties.Status,
                    Texts.DataTableNames.Holiday,
                    selectedYear);
            }
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public DataTable GetUsedHolidays(int actualYear)
        {
            string command = string.Format("SELECT {0}, {1} FROM {2} WHERE {3} = 1 AND {4} LIKE '{5}%'",
                Texts.HolidayProperties.StartDate,
                Texts.HolidayProperties.EndDate,
                Texts.DataTableNames.Holiday,
                Texts.HolidayProperties.Status,
                Texts.HolidayProperties.StartDate,
                actualYear);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public DataTable GetConflictedDateIDs(string startDate, string endDate)
        {
            string command = string.Format("SELECT {0} FROM {1} WHERE {2} = 1 AND {3} BETWEEN '{4}' AND '{5}' AND {6} BETWEEN '{4}' AND '{5}'",
                Texts.HolidayProperties.RowID,
                Texts.DataTableNames.Holiday,
                Texts.HolidayProperties.Status,
                Texts.HolidayProperties.StartDate,
                startDate,
                endDate,
                Texts.HolidayProperties.EndDate);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public int AddNewHolidayToDB(string startDate, string endDate)
        {
            string command = string.Format("INSERT INTO {0} ({1}, {2}, {3}) VALUES ('{4}', '{5}', 1)",
                Texts.DataTableNames.Holiday,
                Texts.HolidayProperties.StartDate,
                Texts.HolidayProperties.EndDate,
                Texts.HolidayProperties.Status,
                startDate,
                endDate);
            iResult = ExecuteNonQuery(command);
            return iResult;
        }

        public bool UpdateHoliday(Dictionary<string, string> data, string key, string value)
        {
            bResult = Update(Texts.DataTableNames.Holiday, data, string.Format("{0}='{1}'", key, value));
            return bResult;
        }

        public string GetRowID(string startDate, string endDate)
        {
            string command = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}' AND {4}='{5}'",
                Texts.HolidayProperties.RowID,
                Texts.DataTableNames.Holiday,
                Texts.HolidayProperties.StartDate,
                startDate,
                Texts.HolidayProperties.EndDate,
                endDate);
            sResult = GetString(command);
            return sResult;
        }

        public bool DoesExistHoliday(string tableName, string columName, string value)
        {
            string command = string.Format("SELECT COUNT({1}) FROM {0} WHERE {1} LIKE'{2}%'",
                tableName,
                columName,
                value);
            if (ExecuteScalar(command) != 0) bResult = true;
            return bResult;
        }

        public bool IsClosed(string date)
        {
            string command = string.Format("SELECT COUNT({1}) FROM {0} WHERE {1} LIKE '{2}%' AND {3}=1",
                Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.Date,
                date,
                Texts.CatalogProperties.Locked);
            if (ExecuteScalar(command) != 0) bResult = true;
            return bResult;
        }

        #endregion

        #region AddGovernmentHoliday

        public DataTable GetGovernmentHolidaysFromDB(string selectedYear)
        {
            command = string.Format("SELECT {0} FROM {2} WHERE {0} LIKE '{1}%' ORDER BY {0}",
                Texts.GovernmentHolidaysProperties.Date,
                selectedYear,
                Texts.DataTableNames.GovernmentHolidays);

            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public int AddNewGovernmentHoliday(string date)
        {
            string command = string.Format("INSERT INTO {0} ({1}) VALUES ('{2}')",
                           Texts.DataTableNames.GovernmentHolidays,
                           Texts.GovernmentHolidaysProperties.Date,
                           date);
            iResult = ExecuteNonQuery(command);
            return iResult;
        }

        public int DeleteNewGovernmentHoliday(string date)
        {
            command = string.Format("DELETE FROM {0} WHERE {1}='{2}'",
                Texts.DataTableNames.GovernmentHolidays,
                Texts.GovernmentHolidaysProperties.Date,
                date);
            iResult = ExecuteNonQuery(command);
            return iResult;
        }

        public bool isHoliday(string date)
        {
            string command = string.Format("SELECT COUNT({1}) FROM {0} WHERE '{2}' BETWEEN {3} AND {4}",
               Texts.DataTableNames.Holiday,
               Texts.HolidayProperties.RowID,
               date,
               Texts.HolidayProperties.StartDate,
               Texts.HolidayProperties.EndDate);
            if (ExecuteScalar(command) != 0) bResult = true;
            return bResult;
        }

        #endregion

        #region WorkingHours.cs

        public DataTable GetTask()
        {
            command = string.Format("SELECT {1}, {2}, {3}, {4} FROM {0} ORDER BY {1}, {2}",
                Texts.DataTableNames.Task,
                Texts.TaskProperties.GroupID,
                Texts.TaskProperties.TaskID,
                Texts.TaskProperties.TaskName,
                Texts.TaskProperties.Selected);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public DataTable GetTasksByMonth(string date)
        {
            command = string.Format("SELECT DISTINCT {0}.{1}, {0}.{2}, {0}.{3}  FROM {0} JOIN {4} USING ({2}) WHERE {4}.{5} LIKE '{6}%'",
                Texts.DataTableNames.Task,
                Texts.TaskProperties.GroupID,
                Texts.TaskProperties.TaskID,
                Texts.TaskProperties.TaskName,
                Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.Date,
                date);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public DataTable GetHolidaysByMonth(string date)
        {
            command = string.Format("SELECT {0}.{1}, {0}.{2} FROM {0} WHERE {0}.{3} = 1 AND {0}.{2} LIKE '{4}%' OR {0}.{1} LIKE '{4}%'",
                Texts.DataTableNames.Holiday,
                Texts.HolidayProperties.StartDate,
                Texts.HolidayProperties.EndDate,
                Texts.HolidayProperties.Status,
                date);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public int GetWorkingHours()
        {
            command = string.Format("SELECT {0} FROM {1}",
                Texts.PersonProperties.WorkingHours,
                Texts.DataTableNames.Person);
            iResult = ExecuteScalar(command);
            return iResult;
        }

        public DataTable GetSelectedTaskFromDB()
        {
            command = string.Format("SELECT * FROM {0} WHERE {1}='1'",
                Texts.DataTableNames.Task,
                Texts.TaskProperties.Selected);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public DataTable GetSelectedTaskByGroup(string groupID)
        {
            command = string.Format("SELECT * FROM {0} WHERE {1} = {2} AND {3} = 1",
                Texts.DataTableNames.Task,
                Texts.TaskProperties.GroupID,
                groupID,
                Texts.TaskProperties.Selected);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public string GetHoursFromCatalog(string groupID, string taskID, string date)
        {
            command = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}' AND {4}='{5}' AND {6}='{7}'",
                Texts.CatalogProperties.NumberOfHours,
                Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.GroupID,
                groupID,
                Texts.CatalogProperties.TaskID,
                taskID,
                Texts.CatalogProperties.Date,
                date);
            sResult = GetString(command);
            return sResult;
        }

        public int IsRecordExist(string groupID, string taskID, string date)
        {
            command = string.Format("SELECT rowid FROM {0} WHERE {1}='{2}' AND {3}='{4}' AND {5}='{6}'",
                Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.GroupID,
                groupID,
                Texts.CatalogProperties.TaskID,
                taskID,
                Texts.CatalogProperties.Date,
                date);
            iResult = ExecuteScalar(command);
            return iResult;
        }

        public int SaveHourToCatalog(string groupID, string taskID, string taskName, string date, double numberOfHours)
        {
            command = string.Format("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}, {6}) VALUES('{7}', '{8}', '{9}', '{10}', '{11}', 0)",
                Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.GroupID,
                Texts.CatalogProperties.TaskID,
                Texts.CatalogProperties.TaskName,
                Texts.CatalogProperties.Date,
                Texts.CatalogProperties.NumberOfHours,
                Texts.CatalogProperties.Locked,
                groupID,
                taskID,
                taskName,
                date,
                numberOfHours);
            iResult = ExecuteNonQuery(command);
            return iResult;
        }

        public bool ModifyHourInCatalog(Dictionary<string, string> data, string value)
        {
            bResult = Update(Texts.DataTableNames.Catalog, data, string.Format("{0}='{1}'", "rowid", value));
            return bResult;
        }

        public int DeleteHourFromCatalog(string groupID, string taskID, string date)
        {
            command = string.Format("DELETE FROM {0} WHERE {1}='{2}' AND {3}='{4}' AND {5}='{6}'",
                Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.GroupID,
                groupID,
                Texts.CatalogProperties.TaskID,
                taskID,
                Texts.CatalogProperties.Date,
                date);
            iResult = ExecuteNonQuery(command);
            return iResult;
        }

        public int DeleteHours(string date, string groupID, string taskID)
        {
            command = string.Format("DELETE FROM {0} WHERE {1} LIKE '{2}%' AND {3}='{4}' AND {5}='{6}'",
                Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.Date,
                date,
                Texts.CatalogProperties.GroupID,
                groupID,
                Texts.CatalogProperties.TaskID,
                taskID);
            iResult = ExecuteNonQuery(command);
            return iResult;
        }

        public int GetNumberOfRecords(string date)
        {
            command = string.Format("SELECT COUNT(*) FROM {0} WHERE {1} LIKE '{2}%'",
                Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.Date,
                date);
            iResult = ExecuteScalar(command);
            return iResult;
        }

        public bool LockMonthInDB(Dictionary<string, string> data, string value)
        {
            bResult = Update(Texts.DataTableNames.Catalog, data, string.Format("{0} LIKE '{1}%'", Texts.CatalogProperties.Date, value));
            return bResult;
        }

        public DataTable GetGovernmentHolidaysFromDB()
        {
            command = string.Format("SELECT * FROM {0} ORDER BY {1}",
                Texts.DataTableNames.GovernmentHolidays,
                Texts.GovernmentHolidaysProperties.Date);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        #endregion

        #region Statistics

        public DataTable GetTasksAndHours(string year, string month)
        {
            command = string.Format("SELECT DISTINCT {0}, SUM({1}) AS NumberOfHours FROM {2} WHERE {3} LIKE '{4}-{5}%' GROUP BY {0}",
                Texts.CatalogProperties.TaskName,
                Texts.CatalogProperties.NumberOfHours,
                Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.Date,
                year,
                month);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        #endregion
    }
}
