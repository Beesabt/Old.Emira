﻿
namespace emira.HelperFunctions
{
    public static class Texts
    {

        public static class DataTableNames
        {
            public const string Person = "Person";

            public const string Task = "Task";

            public const string Holiday = "Holiday";

            public const string Catalog = "Catalog";
        }

        public static class PersonProperties
        {
            public const string ID = "ID";

            public const string Password = "Password";

            public const string Email = "Email";

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

        public static class TaskProperties
        {
            public static string TaskGroupID = "TaskGroupID";

            public static string TaskGroupName = "TaskGroupName";

            public static string TaskID = "TaskID";

            public static string TaskName = "TaskName";

            public static string Selected = "Selected";
        }

        public static class HolidayProperties
        {
            public static string RowID = "rowid";

            public static string PersonID = "PersonID";

            public static string StartDate = "StartDate";

            public static string EndDate = "EndDate";

            public static string Status = "Status";
        }

        public static class CatalogProperties
        {
            public static string PersonID = "PersonID";

            public static string TaskID = "TaskID";

            public static string Date = "Date";

            public static string NumberOfHours = "NumberOfHours";
        }

        public static class ErrorMessages
        {
            #region General

            // TODO : kicserélni a path-ot és dinamikussá tenni!
            public const string SomethingUnexpectedHappened = "Something unexpected happened!\n"+
                                                              @"Please check the log file here: C:\logs\Example.log";

            #endregion

            #region Login
            public const string WrongEmailPassword = "E-mail or password is wrong.";

            public const string FieldIsEmpty = " field is empty.";

            public const string DefaultEmailOrPassword =
                "You use default e-mail or password, please change it in the Settings.\n" +
                "This message appears until you change the default login parameters.";

            #endregion

            #region PersonalInformation

            public const string UserIDDoesNotExistOrTableIsEmpty = " table is empty or the user with the ID does not exist!";

            #endregion

            #region PersonalDataChange

            public const string NumericField = " is a numeric field.";

            public const string TextField = " is a text field.";

            public const string WorkNotAllowed15 = "Work is not allowed for 15 years old or younger";

            public const string WorkNotAllowed100 = "Work is not allowed for 100 years old or older";

            public const string StartOfDateTooSmall = "Start of date can not be smaller than the birth of date.";

            public const string StartOfDateBiggerThanTodayDate = "Start of date can not be bigger than the actual date.";

            public const string DisabledChildrenIsNull = "The number of the disabled children can not be null if the 'Yes' is checked";

            public const string NumberOfChildren = "The 'Yes' can not be check for the question of 'Do you have children?' if you don't add any";

            public const string BiggerThan24Hours = "It has to be lower than 24 hours.";

            public const string NumbericCell = "It is a numeric cell.";

            #endregion

            #region PasswordChange

            public const string WrongOldPassword = "Old password is wrong.";

            public const string WrongOldEmail = "Old e-mail is wrong.";

            public const string NewPasswordsMismatched = "The new passwords are mismatched.";

            public const string NewPasswordSameAsOldPassword = "The new password can not be the old password.";

            public const string NewPasswordIsNotAllowed = "The new password does not following the rules of the password.\n" +
                                                          "If you need information from the rules then move your mouse above the information icon.";

            #endregion

            #region EmailChange

            public const string NewEmailMismatched = "The new e-mails are mismatched.";

            public const string NewEmailSameAsOldEmail = "The new e-mail can not be the old e-mail.";

            public const string EmailIsNotValid = "The format of the e-mail address is not proper.";

            public const string RequiredFieldIsEmpty = "Required field is empty.";

            #endregion

            #region TaskModification

            public static string CheckValuesOfFields =
                         "The value of the field is not proper.\r\n\r\nPossible reasons:\r\n" +
                         "* The Group name already exists with another Group ID\r\n" +
                         "* The Group ID already exists with another Group name\r\n" +
                         "* The Task ID already exists\r\n" +
                         "* The Task name alraedy exists with another Task ID";

            #endregion

            #region Holiday

            public static string SmallerEndDate = "The end date has to be bigger than the start date";

            public static string StartDayInActualYear = "Start date can be only in this year.";

            public static string ConflictIDs = "These IDs are conflicting with the choosen interval: ";

            public static string TooFewRemainingDays = "Not enough days left to take vacation days";

            #endregion

            #region WorkingHours

            public static string ErrorDuringSave = "There was an error during save, try again.";

            #endregion
        }

        public static class InformationMessages
        {
            public const string PasswordChanged = "Password changed successfully.";


            public const string RulesOfNewPassword = "The new password must contain:\n" +
                                                      "- Capital and small letter\n" +
                                                      "- At least one number\n" +
                                                      "- Required long is 8 letters";

            public const string EmailChanged = "E-mail changed successfully.";

            public const string PersonalInformationChanged = "Personal information changed successfully.";

            public static string SuccessfulSave = "Data has been saved.";
        }

        public static class WarningMessages
        {
            public static string DeleteTask = "Warning\r\n\r\nThere are some unchecked task which are used already, if you delete them then the already setted values will be lost.\r\n\r\n" +
                                              "Do you continue the action?";

        }

        public static class Captions
        {
            public const string Error = "Error";

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

            public static string InvalidValue = "Invalid value";

            public static string SuccessfulSave = "Successful save";

            public static string ErrorSave = "An error during save";

            public static string LossOfData = "Loss of datas";
        }

    }
}
