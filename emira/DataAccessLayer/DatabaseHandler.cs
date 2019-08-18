using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using emira.HelperFunctions;
using emira.GUI;

namespace emira.DataAccessLayer
{
    class DatabaseHandler
    {
        private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();
        string sResult = string.Empty;
        int iResult = 0;
        private SQLiteConnection sqlite;
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
            catch(Exception error)
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
                SQLiteCommand cmd;
                cmd = sqlite.CreateCommand();
                cmd.CommandText = command;
                cmd.Connection = sqlite;
                sqlite.Open();
                var obj = cmd.ExecuteScalar();
                if (obj == null) { return 0; }
                iResult = Convert.ToInt32(obj);
            }
            catch (SQLiteException error)
            {
                MessageBox.Show(error.Message);
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
                SQLiteCommand cmd;
                cmd = sqlite.CreateCommand();
                cmd.CommandText = command;
                sqlite.Open();
                var obj = cmd.ExecuteScalar();
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
                MessageBox.Show(error.Message);
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
                SQLiteCommand cmd;
                cmd = sqlite.CreateCommand();
                cmd.CommandText = command;
                sqlite.Open();
                iResult = cmd.ExecuteNonQuery();
            }
            catch (SQLiteException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                sqlite.Close();
            }
            return iResult;
        }

        private bool Update(string tableName, Dictionary<string, string> data, string where, ref int updatedRows)
        {
            string vals = string.Empty;
            bool returnCode = false;

            try
            {
                if (data.Count >= 1)
                {
                    foreach (KeyValuePair<string, string> val in data)
                    {
                        vals += string.Format("{0}='{1}',", val.Key.ToString(), val.Value.ToString());
                    }
                    vals = vals.Substring(0, vals.Length - 1);
                }
                string command = string.Format("UPDATE {0} SET {1} WHERE {2}", tableName, vals, where);
                SQLiteCommand cmd;
                cmd = sqlite.CreateCommand();
                cmd.CommandText = command;
                sqlite.Open();
                updatedRows = cmd.ExecuteNonQuery();
                if (updatedRows > 0) returnCode = true;
            }
            catch (SQLiteException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                sqlite.Close();
            }
            return returnCode;
        }

        private DataTable GetDataTable(string command)
        {
            try
            {
                SQLiteCommand cmd;
                cmd = sqlite.CreateCommand();
                cmd.CommandText = command;
                sqlite.Open();
                dataAdapter = new SQLiteDataAdapter(cmd);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
            }
            catch (SQLiteException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                sqlite.Close();
            }
            return dataTable;
        }

        #region Login.cs

        public bool LoginValidationDB(string Email, string Password)
        {
            bool isSuccess = false;
            string command = string.Format("SELECT COUNT({1}) FROM {0} WHERE {1}='{2}' and {3}='{4}'", Texts.DataTableNames.Person,
                Texts.PersonProperties.Email, Email, Texts.PersonProperties.Password, Password);
            if (ExecuteScalar(command) != 0) isSuccess = true;
            return isSuccess;
        }

        public int GetUserID(string Email, string Password)
        {
            string command = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}' AND {4}='{5}'", Texts.PersonProperties.ID, Texts.DataTableNames.Person,
                 Texts.PersonProperties.Email, Email, Texts.PersonProperties.Password, Password);
            iResult = ExecuteScalar(command);
            return iResult;
        }

        #endregion

        #region Home.cs

        public string GetPassword(string Email)
        {
            string cmd = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}'", Texts.PersonProperties.Password, Texts.DataTableNames.Person,
                 Texts.PersonProperties.Email, Email);
            sResult = GetString(cmd);
            return sResult;
        }

        #endregion

        #region Settings.cs

        public bool OldValueValidationDB(string Key, string Value)
        {
            bool isSuccess = false;
            string command = string.Format("SELECT COUNT({1}) FROM {0} WHERE {1}='{2}'", Texts.DataTableNames.Person, Key, Value);
            if (ExecuteScalar(command) != 0) isSuccess = true;
            return isSuccess;
        }

        public int SetNewValueDB(Dictionary<string, string> data, string Key, string Value, int updatedRow)
        {
            Update(Texts.DataTableNames.Person, data, string.Format("{0}='{1}'", Key, Value), ref updatedRow);
            return updatedRow;
        }

        public DataTable GetSomePersonalInforamtionFromDB()
        {
            string command = string.Format("SELECT {0},{1},{2},{3},{4} FROM {5} WHERE {6}='{7}'",
                Texts.PersonProperties.Name,
                Texts.PersonProperties.RegisterNumber,
                Texts.PersonProperties.Company,
                Texts.PersonProperties.CostCenter,
                Texts.PersonProperties.Position,
                Texts.DataTableNames.Person,
                Texts.PersonProperties.ID,
                GeneralInfo.UserID);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public DataTable GetPersonalInformationDB()
        {
            string command = string.Format("SELECT * FROM {0} WHERE {1}='{2}'",
                Texts.DataTableNames.Person,
                Texts.PersonProperties.ID,
                GeneralInfo.UserID);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        #endregion

        #region TaskModification.cs 

        public DataTable GetTask(string command)
        {
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public int InsertNewTask(string taskGroupID, string taskGroup, string taskID, string taskName)
        {
            int result = 0;
            string cmd = string.Format("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}) VALUES ('{6}', '{7}', '{8}', '{9}', {10})",
                Texts.DataTableNames.Task, Texts.TaskProperties.TaskGroupID, Texts.TaskProperties.TaskGroupName,
                Texts.TaskProperties.TaskID, Texts.TaskProperties.TaskName,
                Texts.TaskProperties.Selected, taskGroupID, taskGroup, taskID, taskName, 0);
            result = ExecuteNonQuery(cmd);
            return result;
        }

        public bool ModifyTask(Dictionary<string, string> data, string Key, string Value, int updatedRow)
        {
            bool isSuccess = false;
            isSuccess = Update(Texts.DataTableNames.Task, data, string.Format("{0}='{1}'", Key, Value), ref updatedRow);
            return isSuccess;
        }

        public int DeleteRow(string taskGroupID, string taskGroup, string taskID, string taskName)
        {
            int result = 0;
            string cmd = string.Format("DELETE FROM {0} WHERE {1}='{2}' AND {3}='{4}' AND {5}='{6}' AND {7}='{8}'",
                Texts.DataTableNames.Task, Texts.TaskProperties.TaskGroupID, taskGroupID, Texts.TaskProperties.TaskGroupName,
                taskGroup, Texts.TaskProperties.TaskID, taskID, Texts.TaskProperties.TaskName, taskName);
            result = ExecuteNonQuery(cmd);
            return result;
        }

        public bool DoesExist(string ColumName, string Value)
        {
            bool exist = false;
            string cmd = string.Format("SELECT COUNT({1}) FROM {0} WHERE {1}='{2}'", Texts.DataTableNames.Task, ColumName, Value);
            if (ExecuteScalar(cmd) != 0) exist = true;
            return exist;
        }

        public bool DoesItHave(string GroupIDColumn, string GroupID, string GroupNameColumn, string GroupName)
        {
            bool same = false;
            string cmd = string.Format("SELECT COUNT({1}) FROM {0} WHERE {1}='{2}' AND {3}='{4}'", Texts.DataTableNames.Task,
                GroupIDColumn, GroupID, GroupNameColumn, GroupName);
            if (ExecuteScalar(cmd) != 0) same = true;
            return same;
        }

        #endregion

        #region Holiday.cs

        public DataTable GetPersonalInformationDBForHoliday()
        {
            string command = string.Format("SELECT {0}, {1}, {2}, {3}, {4}, {5}, {6}, {7} FROM {8} WHERE {9}='{10}'",
                Texts.PersonProperties.DateOfBirth,
                Texts.PersonProperties.DateOfStart,
                Texts.PersonProperties.NumberOfChildren,
                Texts.PersonProperties.NumberOfDisabledChildren,
                Texts.PersonProperties.NumberOfNewBornBabies,
                Texts.PersonProperties.HealthDamage,
                Texts.PersonProperties.HolidaysLeftFromPreviousYear,
                Texts.PersonProperties.ExtraHoliday,
                Texts.DataTableNames.Person,
                Texts.PersonProperties.ID,
                GeneralInfo.UserID);
            dataTable = new DataTable();
            dataTable = GetDataTable(command);
            return dataTable;
        }

        public string GetTheSmallestYear()
        {
            string _theSmallestYear = string.Empty;
            string cmd = string.Format("SELECT MIN({0}) FROM {1} WHERE {2}='{3}'",
                Texts.HolidayProperties.StartDate,
                Texts.DataTableNames.Holiday,
                Texts.HolidayProperties.PersonID,
                GeneralInfo.UserID);
            _theSmallestYear = GetString(cmd);
            return _theSmallestYear;
        }

        public DataTable GetHolidaysFromDB(string selectedYear, bool selectedStatus)
        {
            string cmd = string.Empty;
            if (selectedStatus)
            {
                cmd = string.Format("SELECT {0}, {1}, {2}, {3} FROM {4} WHERE {5}='{6}' AND {3} = 1 AND {1} LIKE '{7}%' ORDER BY {1}",
                    Texts.HolidayProperties.RowID,
                    Texts.HolidayProperties.StartDate,
                    Texts.HolidayProperties.EndDate,
                    Texts.HolidayProperties.Status,
                    Texts.DataTableNames.Holiday,
                    Texts.HolidayProperties.PersonID,
                    GeneralInfo.UserID,
                    selectedYear);
            }
            else
            {
                cmd = string.Format("SELECT {0}, {1}, {2}, {3} FROM {4} WHERE {5}='{6}' AND {1} LIKE '{7}%' ORDER BY {1}",
                    Texts.HolidayProperties.RowID,
                    Texts.HolidayProperties.StartDate,
                    Texts.HolidayProperties.EndDate,
                    Texts.HolidayProperties.Status,
                    Texts.DataTableNames.Holiday,
                    Texts.HolidayProperties.PersonID,
                    GeneralInfo.UserID,
                    selectedYear);
            }
            dataTable = new DataTable();
            dataTable = GetDataTable(cmd);
            return dataTable;
        }

        public DataTable GetUsedHolidays(int actualYear)
        {
            string cmd = string.Format("SELECT {0}, {1} FROM {2} WHERE {3} = 1 AND {4} = '{5}' AND {6} LIKE '{7}%'",
                Texts.HolidayProperties.StartDate,
                Texts.HolidayProperties.EndDate,
                Texts.DataTableNames.Holiday,
                Texts.HolidayProperties.Status,
                Texts.HolidayProperties.PersonID,
                GeneralInfo.UserID,
                Texts.HolidayProperties.StartDate,
                actualYear);
            dataTable = new DataTable();
            dataTable = GetDataTable(cmd);
            return dataTable;
        }

        public DataTable GetConflictedDateIDs(string startDate, string endDate)
        {
            string cmd = string.Format("SELECT {0} FROM {1} WHERE {2} = 1 AND {3} BETWEEN '{4}' AND '{5}' AND {6} BETWEEN '{4}' AND '{5}' AND {7}='{8}'",
                Texts.HolidayProperties.RowID,
                Texts.DataTableNames.Holiday,
                Texts.HolidayProperties.Status,
                Texts.HolidayProperties.StartDate,
                startDate,
                endDate,
                Texts.HolidayProperties.EndDate,
                Texts.HolidayProperties.PersonID,
                GeneralInfo.UserID);
            dataTable = new DataTable();
            dataTable = GetDataTable(cmd);
            return dataTable;
        }

        public int AddNewHolidayToDB(int personID, string startDate, string endDate)
        {
            int _result = 0;
            string cmd = string.Format("INSERT INTO {0} ({1}, {2}, {3}, {4}) VALUES ({5}, '{6}', '{7}', 1)",
                Texts.DataTableNames.Holiday,
                Texts.HolidayProperties.PersonID,
                Texts.HolidayProperties.StartDate,
                Texts.HolidayProperties.EndDate,
                Texts.HolidayProperties.Status,
                personID,
                startDate,
                endDate);
            _result = ExecuteNonQuery(cmd);
            return _result;
        }

        public int UpdateHoliday(Dictionary<string, string> data, string Key, string Value, int updatedRow)
        {
            Update(Texts.DataTableNames.Holiday, data, string.Format("{0}='{1}'", Key, Value), ref updatedRow);
            return updatedRow;
        }

        public string GetRowID(string startDate, string endDate)
        {
            string _result = string.Empty;
            string cmd = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}' AND {4}='{5}'",
                Texts.HolidayProperties.RowID,
                Texts.DataTableNames.Holiday,
                Texts.HolidayProperties.StartDate,
                startDate,
                Texts.HolidayProperties.EndDate,
                endDate);
            _result = GetString(cmd);
            return _result;
        }

        #endregion

        #region WorkingHours.cs

        public DataTable GetTask()
        {
            string cmd = string.Format("SELECT * FROM {0} ORDER BY {1}", Texts.DataTableNames.Task, Texts.TaskProperties.TaskGroupID);
            dataTable = new DataTable();
            dataTable = GetDataTable(cmd);
            return dataTable;
        }

        public DataTable GetTasksByMonth(string date)
        {
            string cmd = string.Format("SELECT {0}.{1}, {0}.{2} FROM {0} JOIN {3} USING ({1}) WHERE {3}.{4} LIKE '{5}%'",
                Texts.DataTableNames.Task,
                Texts.TaskProperties.TaskID,
                Texts.TaskProperties.TaskName,
                Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.Date,
                date);
            dataTable = new DataTable();
            dataTable = GetDataTable(cmd);
            return dataTable;
        }

        public DataTable GetSelectedTaskFromDB()
        {
            string cmd = string.Format("SELECT * FROM {0} WHERE {1}='{2}'", Texts.DataTableNames.Task, Texts.TaskProperties.Selected, "True");
            dataTable = new DataTable();
            dataTable = GetDataTable(cmd);
            return dataTable;
        }

        public string GetHoursFromCatalog(string taskID, string date)
        {
            string _result = string.Empty;
            string cmd = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}' AND {4}='{5}' AND {6}='{7}'", Texts.CatalogProperties.NumberOfHours, Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.PersonID, GeneralInfo.UserID, Texts.CatalogProperties.TaskID, taskID, Texts.CatalogProperties.Date, date);
            _result = GetString(cmd);
            return _result;
        }

        public int DeleteWeek(string beginDate, string endDate)
        {
            int _result = 0;
            string cmd = string.Format("DELETE FROM {0} WHERE {1}='{2}' AND {3} BETWEEN '{4}' AND '{5}'", Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.PersonID, GeneralInfo.UserID, Texts.CatalogProperties.Date, beginDate, endDate);
            _result = ExecuteNonQuery(cmd);
            return _result;
        }

        public int IsRecordExist(string taskID, string date)
        {
            int _rowid = 0;
            string cmd = string.Format("SELECT rowid FROM {0} WHERE {1}='{2}' AND {3}='{4}'",
                Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.TaskID,
                taskID,
                Texts.CatalogProperties.Date,
                date);
            _rowid = ExecuteScalar(cmd);

            return _rowid;
        }
        public int SaveHourToCatalog(string taskID, string date, double numberOfHours)
        {
            int _result = 0;
            string cmd = string.Format("INSERT INTO {0} ({1}, {2}, {3}, {4}) VALUES({5}, '{6}', '{7}', '{8}')",
                Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.PersonID,
                Texts.CatalogProperties.TaskID,
                Texts.CatalogProperties.Date,
                Texts.CatalogProperties.NumberOfHours,
                GeneralInfo.UserID,
                taskID,
                date,
                numberOfHours);
            _result = ExecuteNonQuery(cmd);
            return _result;
        }

        public bool ModifyHourInCatalog(Dictionary<string, string> data, string Value, int updatedRow)
        {
            bool isSuccess = false;
            isSuccess = Update(Texts.DataTableNames.Catalog, data, string.Format("{0}='{1}'", "rowid", Value), ref updatedRow);
            return isSuccess;
        }

        public int DeleteHourFromCatalog(string taskID, string date)
        {
            int result = 0;
            string cmd = string.Format("DELETE FROM {0} WHERE {1}='{2}' AND {3}='{4}'",
                Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.TaskID,
                taskID,
                Texts.CatalogProperties.Date,
                date);
            result = ExecuteNonQuery(cmd);
            return result;
        }

        public int DeleteHours(string date, string taskID)
        {
            int result = 0;
            string cmd = string.Format("DELETE FROM {0} WHERE {1} LIKE '{2}%' AND {3}='{4}'",
                Texts.DataTableNames.Catalog,
                Texts.CatalogProperties.Date,
                date,
                Texts.CatalogProperties.TaskID,
                taskID);
            result = ExecuteNonQuery(cmd);
            return result;
        }

        #endregion

    }
}
