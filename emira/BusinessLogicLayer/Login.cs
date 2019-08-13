using emira.DataAccessLayer;
using emira.HelperFunctions;

namespace emira.BusinessLogicLayer
{
    class Login
    {
        DatabaseHandler _DBHandler;

        private bool LoginValidation(string Email, string Password)
        {
            bool isSuccess = false;
            _DBHandler = new DatabaseHandler();
            isSuccess = _DBHandler.LoginValidationDB(Email, Password);
            if (isSuccess)
            {
                LogInfo.UserID = _DBHandler.GetUserID(Email, Password);
                LogInfo.Email = Email;
                if (Email == LogInfo.DefaultEmail || Password == LogInfo.DefaultPassword)
                {
                    LogInfo.AnnoyingMessage = true;
                }
                else
                {
                    LogInfo.AnnoyingMessage = false;
                }
            }
            return isSuccess;
        }

    }
}
