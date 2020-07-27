using emira.DataAccessLayer;
using emira.HelperFunctions;

namespace emira.BusinessLogicLayer
{
    class Login
    {
        DatabaseHandler _DBHandler;

        public bool LoginValidation(string Email, string Password)
        {
            bool isSuccess = false;
            _DBHandler = new DatabaseHandler();
            isSuccess = _DBHandler.LoginValidationDB(Email, Password);
            if (isSuccess)
            {
                GeneralInfo.UserID = _DBHandler.GetUserID(Email, Password);
                GeneralInfo.DefaultEmail = Email;
                if (Email == GeneralInfo.DefaultEmail || Password == GeneralInfo.DefaultPassword)
                {
                    GeneralInfo.AnnoyingMessage = true;
                }
                else
                {
                    GeneralInfo.AnnoyingMessage = false;
                }
            }
            return isSuccess;
        }

    }
}
