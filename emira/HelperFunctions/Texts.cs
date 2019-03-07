
namespace emira.HelperFunctions
{
    public static class Texts
    {

        public static class DataTableNames
        {
            public const string Person = "Person";
            
        }

        public static class PersonProperties
        {
            public const string ID = "ID";

            public const string Password = "Password";

            public const string Email ="Email";

            public const string Name = "Name";
            
            public const string Gender = "Gender";
            
            public const string RegisterNumber = "RegisterNumber";
            
            public const string Company = "Company";
            
            public const string CostCenter = "CostCenter";
            
            public const string Position = "Position"; 
            
            public const string WorkingHours = "WorkingHours";
            
            public const string DateOfStart = "DateOfStart";
            
            public const string DateOfBirth = "DateOfBirth";
            
            public const string NumberOfChildren = "NumberOfChildren";
            
            public const string NumberOfDisabledChildren = "NumberOfDisabledChildren";
            
            public const string NumberOfNewBornBabies = "NumberOfNewBornBabies";
            
            public const string HealthDamage = "HealthDamage"; 
            
        }

        public static class ErrorMessages
        {

            public const string WrongEmailPassword = "E-mail or password is wrong.";

            public const string FieldIsEmpty = " field is empty.";

            public const string DefaultEmailOrPassword = 
                "You use default e-mail or password, please change it in the Settings.\n" +
                "This message appears until you change the default login parameters.";

            public const string UserIDDoesNotExistOrTableIsEmpty = " table is empty or the user with the ID does not exist!";

            public const string NumericField = " is a numeric field.";

            public const string TextField = " is a text field.";

            public const string WorkNotAllowed15 = "Work is not allowed for 15 years old or younger";

            public const string WorkNotAllowed100 = "Work is not allowed for 100 years old or older";

            public const string StartOfDateTooSmall = "Start of date can not be smaller than the birth of date.";

            public const string StartOfDateBiggerThanTodayDate = "Start of date can not be bigger than the actual date.";

            public const string BiggerNumberThanNumberOfChildren = " can not be bigger number than the number of the children.";

            public const string DiabledAndNewBornBigger = "Sum of the disabled children and new born babies can not be bigger number " +
                                                           "than the number of the children.";

            public const string WrongOldPassword = "Old password is wrong.";

            public const string WrongOldEmail = "Old e-mail is wrong.";

            public const string NewPasswordsMismatched = "The new passwords are mismatched.";

            public const string NewPasswordSameAsOldPassword = "The new password can not be the old password.";

            public const string NewPasswordIsNotAllowed= "The new password does not following the rules of the password.\n" +
                                                          "If you need information from the rules then move your mouse above the information icon.";

            public const string NewEmailMismatched = "The new e-mails are mismatched.";

            public const string NewEmailSameAsOldEmail = "The new e-mail can not be the old e-mail.";

            public const string EmailIsNotValid = "The format of the e-mail address is not proper.";

        }

        public static class InformationMessages
        {

            public const string PasswordChanged = "Password changed successfully.";


            public const string RulesOfNewPassword = "The new password must contain:\n"+
                                                      "- Capital and small letter\n"+
                                                      "- At least one number\n"+
                                                      "- Required long is 8 letters";

            public const string EmailChanged = "E-mail changed successfully.";

            public const string PersonalInformationChanged = "Personal information changed successfully.";

        }

        public static class Captions
        {

            public const string LoginFailed = "Login failed";

            public const string EmptyRequiredField = "Empty reqired field";

            public const string DefaultLoginParameters = "Default login parameters";

            public const string PersonalInformationError = "Personal information error";

            public const string NumericField = "Numeric field";

            public const string TextField = "Text field";

            public const string BirthOfDateError = "Birth of date error";

            public const string StartOfDateError = "Start of date error";

            public const string NumberOfTheChildrenError = "Number of the children error";

            public const string WrongOldValue = "Wrong old value";

            public const string MissmatchadPasswords = "Mismatched passwords";

            public const string NewPasswordIsNotAllowed = "New password is not allowed";

            public const string MissmatchadEmails = "Mismatched e-mails";

            public const string NewEmaildIsNotAllowed = "New e-mail is not allowed";

            public const string InvalidEmail = "Invalid E-mail";

            public const string SuccessfulChange = "Successful action";

        }

    }
}

