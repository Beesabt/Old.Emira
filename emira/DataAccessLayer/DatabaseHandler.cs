using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using emira.HelperFunctions;

namespace emira.DataAccessLayer
{
    class DatabaseHandler
    {
        private SQLiteConnection _sqlite;
        DataTable _dataTable;
        SQLiteDataAdapter _dataAdapter;
        string _sResult = string.Empty;
        int _iResult = 0;

        public DatabaseHandler()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            _sqlite = new SQLiteConnection(@"Data Source = |DataDirectory|\ApplicationFiles\DataBase\Emira_Database.db; Version = 3;");
        }


        private int ExecuteScalar(string command)
        {
            try
            {
                SQLiteCommand cmd;
                cmd = _sqlite.CreateCommand();
                cmd.CommandText = command;
                cmd.Connection = _sqlite;
                _sqlite.Open();
                var obj = cmd.ExecuteScalar();
                if (obj == null) { return 0; }
                _iResult = Convert.ToInt32(obj);                               
            }
            catch (SQLiteException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                _sqlite.Close();
            }
            return _iResult;
        }

        private string GetString(string command)
        {
            try
            {
                SQLiteCommand cmd;
                cmd = _sqlite.CreateCommand();
                cmd.CommandText = command;
                _sqlite.Open();
                var obj = cmd.ExecuteScalar();
                if (obj == null || string.IsNullOrEmpty(obj.ToString()))
                {
                    return string.Empty;
                }
                else
                {
                    _sResult = obj.ToString();
                }
            }
            catch (SQLiteException error)
            {
                MessageBox.Show(error.Message);                           
            }
            finally
            {
                _sqlite.Close();
            }
            return _sResult;
        }

        private int ExecuteNonQuery(string command)
        {
            try
            {
                SQLiteCommand cmd;
                cmd = _sqlite.CreateCommand();
                cmd.CommandText = command;
                _sqlite.Open();
                _iResult = cmd.ExecuteNonQuery();
            }
            catch(SQLiteException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                _sqlite.Close();
            }
            return _iResult;         
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
                cmd = _sqlite.CreateCommand();
                cmd.CommandText = command;
                _sqlite.Open();
                updatedRows = cmd.ExecuteNonQuery();
                if (updatedRows >= 0) returnCode = true;               
            }
            catch (SQLiteException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                _sqlite.Close();
            }
            return returnCode;
        }

        private DataTable GetDataTable(string command)
        {
            try
            {
                SQLiteCommand cmd;
                cmd = _sqlite.CreateCommand();
                cmd.CommandText = command;
                _sqlite.Open();
                _dataAdapter = new SQLiteDataAdapter(cmd);
                _dataTable = new DataTable();
                _dataAdapter.Fill(_dataTable);               
            }
            catch (SQLiteException error)
            {
                MessageBox.Show(error.Message);
            }
            finally
            {
                _sqlite.Close();               
            }
            return _dataTable;
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
            _iResult = ExecuteScalar(command);
            return _iResult;
        }

        #endregion

        #region Home.cs

        public string GetPassword(string Email)
        {
            string cmd = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}'", Texts.PersonProperties.Password, Texts.DataTableNames.Person,
                 Texts.PersonProperties.Email, Email);
            _sResult = GetString(cmd);
            return _sResult;
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

        public bool SetNewValueDB(Dictionary<string, string> data, string Key, string Value, int updatedRow)
        {
            bool isSuccess = false;
            isSuccess = Update(Texts.DataTableNames.Person, data, string.Format("{0}='{1}'", Key, Value), ref updatedRow);
            return isSuccess;
        }
        #endregion

        #region Settings.cs and Holiday.cs

        public DataTable GetPersonalInformationDB()
        {
            string command = string.Format("SELECT * FROM {0} WHERE {1}='{2}'", Texts.DataTableNames.Person, Texts.PersonProperties.ID,
                LogInfo.UserID);
            _dataTable = new DataTable();
            _dataTable = GetDataTable(command);
            return _dataTable;
        }

        #endregion

        #region TaskModification.cs 

        public DataTable GetTask(string command)
        {
            //string cmd = string.Format("SELECT * FROM {0} ORDER BY {1}", Texts.DataTableNames.Task, Texts.TaskProperties.TaskGroupID);
            _dataTable = new DataTable();
            _dataTable = GetDataTable(command);
            return _dataTable;
        }

        public int InsertNewTask(string taskGroupID, string taskGroup, string taskID, string taskName)
        {
            int result = 0;
            string cmd = string.Format("INSERT INTO {0} ({1}, {2}, {3}, {4}, {5}) VALUES ('{6}', '{7}', '{8}', '{9}', {10})",
                Texts.DataTableNames.Task, Texts.TaskProperties.TaskGroupID, Texts.TaskProperties.TaskGroup,
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
                Texts.DataTableNames.Task, Texts.TaskProperties.TaskGroupID, taskGroupID, Texts.TaskProperties.TaskGroup,
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

    }
}
