
namespace emira.BusinessLogicLayer
{
    public static class Texts
    {

        public static class DataTableNames
        {
            public static string Person
            {
                get { return "Person"; }
            }
        }

        public static class PersonProperties
        {
            public static string ID
            {
                get { return "ID"; }
            }

            public static string Password
            {
                get { return "Password"; }
            }

            public static string Email
            {
                get { return "Email"; }
            }
            public static string Name
            {
                get { return "Name"; }
            }
            public static string Gender
            {
                get { return "Gender"; }
            }
            public static string RegisterNumber
            {
                get { return "RegisterNumber"; }
            }
            public static string Company
            {
                get { return "Company"; }
            }
            public static string CostCenter
            {
                get { return "CostCenter"; }
            }
            public static string Position
            {
                get { return "Position"; }
            }

            public static string WorkingHours
            {
                get { return "WorkingHours"; }
            }
            public static string DateOfStart
            {
                get { return "DateOfStart"; }
            }
            public static string DateOfBirth
            {
                get { return "DateOfBirth"; }
            }
            public static string NumberOfChildren
            {
                get { return "NumberOfChildren"; }
            }
            public static string NumberOfDisabledChildren
            {
                get { return "NumberOfDisabledChildren"; }
            }

            public static string NumberOfNewBornBabies
            {
                get { return "NumberOfNewBornBabies"; }
            }

            public static string HealthDamage
            {
                get { return "HealthDamage"; }
            }
        }

        public static class ErrorMessages
        {

            public static string WrongEmailPassword
            {
                get
                {
                    return "E-mail or password is wrong.";
                }
            }

            public static string FieldIsEmpty
            {
                get
                {
                    return " field is empty.";
                }
            }

            public static string DefaultEmailOrPassword
            {
                get
                {
                    return "You use default e-mail or password, please change it in the Settings.\nThis message appears until you change the default login parameters.";
                }
            }

            public static string UserIDDoesNotExistOrTableIsEmpty
            {
                get
                {
                    return " table is empty or the user with the ID does not exist!";
                }
            }

            public static string NumericField
            {
                get
                {
                    return " is a numeric field.";
                }
            }

            public static string WorkNotAllowed15
            {
                get
                {
                    return "Work is not allowed for 15 years old or younger";
                }
            }

            public static string WorkNotAllowed100
            {
                get
                {
                    return "Work is not allowed for 100 years old or older";
                }
            }

            public static string StartOfDateTooSmall
            {
                get
                {
                    return "Start of date can not be smaller than the birth of date.";
                }
            }

            public static string BiggerNumberThanNumberOfChildren
            {
                get
                {
                    return " can not be bigger number than the number of the children.";
                }
            }

            public static string DiabledAndNewBornBigger
            {
                get
                {
                    return "Sum of the disabled children and new born babies can not be bigger number than the number of the children.";
                }
            }

            public static string WrongOldPassword
            {
                get
                {
                    return "Old password is wrong.";
                }
            }

            public static string WrongOldEmail
            {
                get
                {
                    return "Old e-mail is wrong.";
                }
            }

            public static string NewPasswordsMismatched
            {
                get
                {
                    return "The new passwords are mismatched.";
                }
            }

            public static string NewPasswordSameAsOldPassword
            {
                get
                {
                    return "The new password can not be the old password.";
                }
            }

            public static string NewPasswordIsNotAllowed
            {
                get
                {
                    return "The new password does not following the rules of the password.\n" +
                           "If you need information from the rules then move your mouse above the information icon.";
                }
            }

            public static string NewEmailMismatched
            {
                get
                {
                    return "The new e-mails are mismatched.";
                }
            }

            public static string NewEmailSameAsOldEmail
            {
                get
                {
                    return "The new e-mail can not be the old e-mail.";
                }
            }

            public static string EmailIsNotValid
            {
                get
                {
                    return "The format of the e-mail address is not proper.";
                }
            }
        }

        public static class InformationMessages
        {
            public static string PasswordChanged
            {
                get
                {
                    return "Password changed successfully.";
                }
            }

            public static string RulesOfNewPassword
            {
                get
                {
                    return "The new password must contain:\n- Capital and small letter\n- At least one number\n- Required long is 8 letters";
                }
            }

            public static string EmailChanged
            {
                get
                {
                    return "E-mail changed successfully.";
                }
            }

            public static string PersonalInformationChanged
            {
                get
                {
                    return "Personal information changed successfully.";
                }
            }
        }

        public static class Captions
        {

            public static string LoginFailed
            {
                get
                {
                    return "Login failed";
                }
            }

            public static string EmptyRequiredField
            {
                get
                {
                    return "Empty reqired field";
                }
            }

            public static string DefaultLoginParameters
            {
                get
                {
                    return "Default login parameters";
                }
            }

            public static string PersonalInformationError
            {
                get
                {
                    return "Personal information error";
                }
            }

            public static string NumericField
            {
                get
                {
                    return "Numeric field";
                }
            }

            public static string BirthOfDateError
            {
                get
                {
                    return "Birth of date error";
                }
            }

            public static string StartOfDateError
            {
                get
                {
                    return "Start of date error";
                }
            }

            public static string NumberOfTheChildrenError
            {
                get
                {
                    return "Number of the children error";
                }
            }

            public static string WrongOldValue
            {
                get
                {
                    return "Wrong old value";
                }
            }

            public static string MissmatchadPasswords
            {
                get
                {
                    return "Mismatched passwords";
                }
            }

            public static string NewPasswordIsNotAllowed
            {
                get
                {
                    return "New password is not allowed";
                }
            }

            public static string MissmatchadEmails
            {
                get
                {
                    return "Mismatched e-mails";
                }
            }

            public static string NewEmaildIsNotAllowed
            {
                get
                {
                    return "New e-mail is not allowed";
                }
            }

            public static string InvalidEmail
            {
                get
                {
                    return "Invalid E-mail";
                }
            }

            public static string SuccessfulChange
            {
                get
                {
                    return "Successful action";
                }
            }
        }

    }
}

