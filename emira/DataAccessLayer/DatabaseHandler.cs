using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Forms;
using emira.BusinessLogicLayer;

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
                _sqlite.Open();
                var obj = cmd.ExecuteScalar();
                if (obj == null) { return 0; }
                _iResult = Convert.ToInt32(obj);
            }
            catch (SQLiteException error)
            {
                MessageBox.Show(error.Message);
                _sqlite.Close();
            }
            _sqlite.Close();
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
                _sqlite.Close();
            }
            _sqlite.Close();
            return _sResult;
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
                _sqlite.Close();
            }
            catch (SQLiteException error)
            {
                MessageBox.Show(error.Message);
                _sqlite.Close();
            }

            if (updatedRows >= 0) returnCode = true;
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
                _sqlite.Close();
            }
            catch (SQLiteException error)
            {
                MessageBox.Show(error.Message);
                _sqlite.Close();
            }
            return _dataTable;
        }


        #region Login.cs

        public bool LoginValidationDB(string Email, string Password)
        {
            bool isSuccess = false;
            string cmd = string.Format("SELECT COUNT({1}) FROM {0} WHERE {1}='{2}' and {3}='{4}'", Texts.DataTableNames.Person,
                Texts.PersonProperties.Email, Email, Texts.PersonProperties.Password, Password);
            if (ExecuteScalar(cmd) != 0) isSuccess = true;
            return isSuccess;
        }

        public int GetUserID(string Email, string Password)
        {
            string cmd = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}' AND {4}='{5}'", Texts.PersonProperties.ID, Texts.DataTableNames.Person,
                 Texts.PersonProperties.Email, Email, Texts.PersonProperties.Password, Password);
            _iResult = ExecuteScalar(cmd);
            return _iResult;
        }

        #endregion

        #region Home.cs

        public string GetPassword(string Email)
        {
            string cmd = string.Format("SELECT {0} FROM {1} WHERE {2}='{3}'", BusinessLogicLayer.Texts.PersonProperties.Password, BusinessLogicLayer.Texts.DataTableNames.Person,
                 BusinessLogicLayer.Texts.PersonProperties.Email, Email);
            _sResult = GetString(cmd);
            return _sResult;
        }

        #endregion

        #region Settings.cs

        public bool OldValueValidationDB(string Key, string Value)
        {
            bool isSuccess = false;
            string cmd = string.Format("SELECT COUNT({1}) FROM {0} WHERE {1}='{2}'", Texts.DataTableNames.Person, Key, Value);
            if (ExecuteScalar(cmd) != 0) isSuccess = true;
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
            string cmd = string.Format("SELECT * FROM {0} WHERE {1}='{2}'", Texts.DataTableNames.Person, Texts.PersonProperties.ID,
                LogInfo.UserID);
            _dataTable = new DataTable();
            _dataTable = GetDataTable(cmd);
            return _dataTable;
        }

        #endregion

    }
}
