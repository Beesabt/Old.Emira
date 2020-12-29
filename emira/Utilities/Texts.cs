
namespace emira.HelperFunctions
{
    public static class Texts
    {
        public static class DataTableNames
        {
            public const string Person = "Person";

            public const string Task = "Task";

            public const string TaskGroup = "TaskGroup";

            public const string Holiday = "Holiday";

            public const string Catalog = "Catalog";

            public const string GovernmentHolidays = "GovernmentHolidays";
        }

        public static class PersonProperties
        {
            public const string RowID = "rowid";

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

            public const string HolidaysLeftFromPreviousYear = "HolidaysLeftFromPreviousYear";

            public const string ExtraHoliday = "ExtraHoliday";
        }

        public static class TaskProperties
        {
            public static string GroupID = "GroupID";

            public static string TaskGroupName = "TaskGroupName";

            public static string TaskID = "TaskID";

            public static string TaskName = "TaskName";

            public static string Selected = "Selected";
        }

        public static class TaskGropuProperties
        {
            public static string GroupID = "GroupID";

            public static string GroupName = "GroupName";
        }

        public static class HolidayProperties
        {
            public static string RowID = "rowid";

            public static string ID = "ID";

            public static string StartDate = "StartDate";

            public static string StartDateHeaderText = "Start date";

            public static string EndDate = "EndDate";

            public static string EndDateHeaderText = "End data";

            public static string Status = "Status";
        }

        public static class CatalogProperties
        {
            public static string GroupID = "GroupID";

            public static string TaskID = "TaskID";

            public static string TaskName = "TaskName";

            public static string Date = "Date";

            public static string NumberOfHours = "NumberOfHours";

            public static string Locked = "Locked";
        }

        public static class GovernmentHolidaysProperties
        {
            public static string Date = "Date";
        }

        public static class ErrorMessages
        {
            #region General

            // TODO : kicserélni a path-ot és dinamikussá tenni!
            public const string SomethingUnexpectedHappened = "Valami váratlan történt!\n" +
                                                  @"Nézze meg a hibanaplót: C:\logs\Example.log";


            //public const string SomethingUnexpectedHappened = "Something unexpected happened!\n" +
            //                                                  @"Please check the log file here: C:\logs\Example.log";

            public static string ErrorDuringSave = "Hiba történt a mentés sórán, próbálja újra."; //"There was an error during save, try again.";

            #endregion

            public const string FieldIsEmpty = "FieldIsEmpty";

            #region PersonalInformation

            public const string UserIDDoesNotExistOrTableIsEmpty = " a táblázat üres vagy a user a megadott ID-val nem létezik!"; //" table is empty or the user with the ID does not exist!";

            #endregion

            #region PersonalDataChange

            public const string NumericField = " ez egy szám mező."; //" is a numeric field.";

            public const string TextField = " ez egy szöveges mező."; //" is a text field.";

            public const string WorkNotAllowed15 = "Munka nem engedélyezett 15 évesnek vagy annál fiatalabbnak"; //"Work is not allowed for 15 years old or younger";

            public const string WorkNotAllowed100 = "Munka nem engedélyezett 100 évesnek vagy annál idősebbnek"; //"Work is not allowed for 100 years old or older";

            public const string StartOfDateTooSmall = "Kezdődátum nem lehet kisebb, mint a születési dátum."; //"Start of date can not be smaller than the birth of date.";

            public const string StartOfDateBiggerThanTodayDate = "Kezdődátum nem lehet nagyobb, mint a mai dátum."; //"Start of date can not be bigger than the actual date.";

            public const string DisabledChildrenIsNull = "Fogyatékkal élő gyermekek száma nem lehet nulla"; //"The number of the disabled children can not be null if the 'Yes' is checked";

            public const string NumberOfChildren = "A gyermekek száma nem lehet nulla"; //"The 'Yes' can not be check for the question of 'Do you have children?' if you don't add any";

            public const string BiggerThan24Hours = "Kevesebbnek kell lennie, mint 24 óra."; //"It has to be lower than 24 hours.";

            public const string NumbericCell = "Ez egy szám cella."; //"It is a numeric cell.";

            #endregion

            #region PasswordChange

            public const string WrongOldPassword = "A régi jelszó rossz."; //"Old password is wrong.";

            public const string NewPasswordsMismatched = "Az új jelszavak nem egyeznek."; //"The new passwords are mismatched.";

            public const string NewPasswordSameAsOldPassword = "Az új jelszó nem lehet a régi jelszó."; //"The new password can not be the old password.";

            public const string NewPasswordIsNotAllowed = "Az új jelszó nem a szabályoknak megfelelő.\n" +
                                              "További információkért használja az információ ikont.";

            //public const string NewPasswordIsNotAllowed = "The new password does not following the rules of the password.\n" +
            //                                              "If you need information from the rules then move your mouse above the information icon.";

            #endregion

            #region EmailChange

            public const string WrongOldEmail = "A régi e-mail cím rossz."; //"Old e-mail is wrong.";

            public const string NewEmailMismatched = "Az új e-mail címek nem egyeznek."; //"The new e-mails are mismatched.";

            public const string NewEmailSameAsOldEmail = "Az új e-mail cím nem lehet a régi e-mail cím."; //"The new e-mail can not be the old e-mail.";

            public const string EmailIsNotValid = "Az e-mail cím formátuma hibás."; //"The format of the e-mail address is not proper.";

            public const string RequiredFieldIsEmpty = "Kötelező mező üres."; //"Required field is empty.";

            #endregion

            #region TaskModification

            public static string ComboboxIsEmpty = "A csoportnév mező üres."; //"The group name combox is empty, please choose a group before add!";

            public static string NothingChangedForUpdate = "Nem történt változtatás!"; //"Nothing changed for update!";


            public static string CheckValuesOfFieldsForGroup =
                         "A mező értéke nem megfelelő.\r\n\r\nLehetséges okok:\r\n" +
                         "* A csoport ID már létezik egy másik csoport névben\r\n" +
                         "* A csoport név már létezik egy másik csoport ID-ban";

            //public static string CheckValuesOfFieldsForGroup =
            //             "The value of the field is not proper.\r\n\r\nPossible reasons:\r\n" +
            //             "* The Group ID already exists with another Group name\r\n" +
            //             "* The Group name already exists with another Group ID or with the same";

            public static string CheckValuesOfFieldsForTask =
            "TA mező értéke nem megfelelő.\r\n\r\nLehetséges okok:\r\n" +
            "* A taszk ID már létezik egy másik task névben\r\n" +
            "* A taszk név már létezik egy másik taszk ID-ban";

            //public static string CheckValuesOfFieldsForTask =
            //            "The value of the field is not proper.\r\n\r\nPossible reasons:\r\n" +
            //            "* The Task ID already exists with another Task name\r\n" +
            //            "* The Task name alraedy exists with another Task ID or with the same";

            public static string ElementsAreNotAllowed = "Az elem(ek) nem felelnek meg a típusnak!";

            public static string GroupIDNullIsNotAllowed = "A csoport ID nem lehet nulla (0), a program által foglalt!";

            public static string GroupNameUnique = "A csoport nevének egyedinek kell lennie!";

            public static string GroupIDUnique = "A csoport ID-nak egyedinek kell lennie!";

            public static string TaskIDUnique = "A feladat ID-jának egyedinek kell lennie a csoport alatt!";

            public static string TaskNameUnique = "A feladat nevének egyedinek kell lennie a csoport alatt!";
            #endregion

            #region WorkingHours

            public static string ErrorDuringLock = "Hiba a zárás közben, próbálja újra."; //"There was an error during lock, try again.";

            public static string ErrorDuringUnlock = "Hiba a feloldás közben, próbálja újra."; //"There was an error during unlock, try again.";

            #endregion

            #region Holiday

            public static string PublicHoliday = "Nem kell szabadságot kivennie erre az időszakra."; //"There is no need to request holiday for this period.";

            public static string PublicHolidayIncluded = "Ebben az időszakban nemzeti ünnep van!"; //"The period of the holiday contains public holiday!";

            public static string SmallerEndDate = "A végdátumnak nagyobbnak kell lenni, mint a kezdő dátumnak."; //"The end date has to be bigger than the start date.";

            public static string StartDayInActualYear = "A kezdő dátumnak ebben az évben kell lennie."; //"Start date can be only in this year.";

            public static string ConflictIDs = "Ezek az azonosítók üzköznek a választott időszakkal: "; //"These IDs are conflicting with the choosen interval: ";

            public static string TooFewRemainingDays = "Nincs elég szabadnapja!"; //"Not enough days left to take vacation days!";

            public static string ErrorDuringCancellation = "Hiba a lemondás közben, próbálja újra."; //"There was an error during cancellation, try again.";

            public static string ErrorLockedHoliday = "Ez az időszak már le van zárva."; //"The period of the holiday is locked in Working Hours.";

            #endregion

            #region GovernmentHoliday

            public static string PublicHolidaySelected = "A választott dátum egy nemzeti ünnep."; //"The selected date is public holiday";

            public static string ErrorDateExist = "Ez a dátum már hozzá van adva."; //"The selected date is already exist.";

            public static string ErrorExistHoliday = "Ezt a napot már kivette szabadságnak."; //"The selected date is holiday already.";

            #endregion
        }

        public static class InformationMessages
        {
            public const string PasswordChanged = "A jelszó sikeresen megváltozott.";//"Password changed successfully.";


            //public const string RulesOfNewPassword = "The new password must contain:\n" +
            //                                          "- Capital and small letter\n" +
            //                                          "- At least one number\n" +
            //                                          "- Required long is 8 letters";

            public const string RulesOfNewPassword = "Az új jelszónak tartalmaznia kell:\n" +
                                                      "- Kis- és nagybetűt\n" +
                                                      "- Legalább egy számot\n" +
                                                      "- Minimum 8 karakter hosszú kell legyen";

            public const string EmailChanged = "E-amil cím sikeresen megváltozott."; //"E-mail changed successfully.";

            public const string PersonalInformationChanged = "A személyes adatok sikeresen megváltozott."; //"Personal information changed successfully.";

            public static string SuccessfulSave = "Az adat elmentve."; //"Data has been saved.";

            public static string SuccessfulLocked = "Az adatok le vannak zárva."; //"Data has been locked.";

            public static string SuccessfulUnlocked = "Az adatok feloldva."; //"Data has been unlocked.";

            public static string SuccessfulImported = "Az importálás sikeres volt.";

            public static string SuccessfulExported = "Az exportálás sikeres volt.";
        }

        public static class WarningMessages
        {
            public static string DeleteTask = "Warning\r\n\r\nThere are some unchecked task which are used already, if you delete them then the already setted values will be lost.\r\n\r\n" +
                                              "Do you continue the action?";

            public static string PersonInformationMissing = "For holiday calculation please fill out the 'Personal Information'.\n"
                                                            + "You can find it under 'Settings'.";

            public static string ImportTasks = "Warning\r\n\r\nIf you import the new tasks them the old ones will be deleted\r\n\r\n" +
                                               "and the already used task which ara not locked in the Workitime sheet will be deleted.\r\n\r\n" +
                                               "Do you continue the action?";

            public static string DeleteHoliday = "Warning\r\n\r\nThere are some unchecked holidays which are used in Working Hours already, if you delete them then the already setted values will be lost.\r\n\r\n" +
                                  "Do you continue the action?";
        }

        public static class Captions
        {
            public const string Information = "Információ"; //"Information";

            public const string Error = "Hiba"; //"Error";

            public const string Warning = "Figyelmeztetés"; //"Warning";



            public const string EmptyRequiredField = "Üres kötelező mező"; //"Empty reqired field";

            public const string DefaultLoginParameters = "Alapértemezett bejelentkezési adatok"; //"Default login parameters";

            public const string PersonalInformationError = "Személyes adatok hiba"; //"Personal information error";

            public const string NumericField = "Szám mező"; //"Numeric field";

            public const string TextField = "Szöveg mező"; //"Text field";

            public const string BirthOfDateError = "Születési dátum hiba"; //"Birth of date error";

            public const string StartOfDateError = "Munkakezédési dátum hiba"; //"Start of date error";

            public const string NumberOfTheChildrenError = "Gyerek(ek) száma hiba"; //"Number of the children error";

            public const string WrongOldValue = "Rossz régi érték"; //"Wrong old value";

            public const string MissmatchadPasswords = "Nem eggyező jelszók"; //"Mismatched passwords";

            public const string NewPasswordIsNotAllowed = "Új jelszó nem megfelelő"; //"New password is not allowed";

            public const string MissmatchadEmails = "Nem eggyező e-mail címek"; //"Mismatched e-mails";

            public const string NewEmaildIsNotAllowed = "Új e-mail cím nem megfelelő"; //"New e-mail is not allowed";

            public const string InvalidEmail = "Nem megfelelő e-mail cím"; //"Invalid E-mail";

            public const string SuccessfulChange = "Sikeres változtatás"; //"Successful action";

            public static string InvalidValue = "Nem megfelelő érték"; //"Invalid value";

            public static string SuccessfulSave = "Siekres mentés"; //"Successful save";

            public static string SuccessfulUnlocked = "Sikeres feloldás"; //"Successful unlocked";

            public static string SuccessLocked = "Sikeres lezárás"; //"Successful locked";

            public static string ErrorSave = "Hiba a mentés során"; //"An error during save";

            public static string ErrorLock = "Hiba a lezárás során"; //"An error during lock";

            public static string ErrorUnlock = "Hiba a feloldás során"; //"An error during unlock";

            public static string LossOfData = "Adatvesztés"; //"Loss of data";
        }

        public static class Button
        {
            public static string Add = "Hozzáad";

            public static string Update = "Módosít";

            public static string Lock = "Lezárás";

            public static string Unlock = "Feloldás";
        }

        public static class Label
        {
            public static string Add = "Csoport hozááadása";

            public static string Update = "Csoport módosítása";
        }

        public static class Text
        {
            public static string NormalHoliday = "0_0 Normál szabadság";
        }
    }
}

