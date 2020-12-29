
namespace emira.Utilities
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

            public static string ErrorDuringSave = "Hiba történt a mentés sórán, próbálja újra.";

            #endregion

            public const string FieldIsEmpty = "FieldIsEmpty";

            #region PersonalInformation

            public const string UserIDDoesNotExistOrTableIsEmpty = " a táblázat üres vagy a user a megadott ID-val nem létezik!";

            #endregion

            #region PersonalDataChange

            public const string NumericField = " ez egy szám mező.";

            public const string TextField = " ez egy szöveges mező.";

            public const string WorkNotAllowed15 = "Munka nem engedélyezett 15 évesnek vagy annál fiatalabbnak";

            public const string WorkNotAllowed100 = "Munka nem engedélyezett 100 évesnek vagy annál idősebbnek";

            public const string StartOfDateTooSmall = "Kezdődátum nem lehet kisebb, mint a születési dátum.";

            public const string StartOfDateBiggerThanTodayDate = "Kezdődátum nem lehet nagyobb, mint a mai dátum.";

            public const string DisabledChildrenIsNull = "Fogyatékkal élő gyermekek száma nem lehet nulla";

            public const string NumberOfChildren = "A gyermekek száma nem lehet nulla";

            public const string BiggerThan24Hours = "Kevesebbnek kell lennie, mint 24 óra.";

            public const string NumbericCell = "Ez egy szám cella.";

            #endregion

            #region PasswordChange

            public const string WrongOldPassword = "A régi jelszó rossz.";

            public const string NewPasswordIsDefault = "Az új jelszó nem lehet az alapértelemezett.";

            public const string NewPasswordsMismatched = "Az új jelszavak nem egyeznek.";

            public const string NewPasswordSameAsOldPassword = "Az új jelszó nem lehet a régi jelszó.";

            public const string NewPasswordIsNotAllowed = "Az új jelszó nem a szabályoknak megfelelő.\n" +
                                              "További információkért használja az információ ikont.";

            #endregion

            #region EmailChange

            public const string WrongOldEmail = "A régi e-mail cím rossz.";

            public const string NewEmailIsDefault = "Az új e-mail cím nem lehet az alapértelemezett.";

            public const string NewEmailMismatched = "Az új e-mail címek nem egyeznek.";

            public const string NewEmailSameAsOldEmail = "Az új e-mail cím nem lehet a régi e-mail cím.";

            public const string EmailIsNotValid = "Az e-mail cím formátuma hibás.";

            public const string RequiredFieldIsEmpty = "Kötelező mező üres.";

            #endregion

            #region TaskModification

            public static string ComboboxIsEmpty = "A csoportnév mező üres.";

            public static string NothingChangedForUpdate = "Nem történt változtatás!";


            public static string CheckValuesOfFieldsForGroup =
                         "A mező értéke nem megfelelő.\r\n\r\nLehetséges okok:\r\n" +
                         "* A csoport ID már létezik egy másik csoport névben\r\n" +
                         "* A csoport név már létezik egy másik csoport ID-ban";

            public static string CheckValuesOfFieldsForTask =
            "TA mező értéke nem megfelelő.\r\n\r\nLehetséges okok:\r\n" +
            "* A taszk ID már létezik egy másik task névben\r\n" +
            "* A taszk név már létezik egy másik taszk ID-ban";

            public static string ElementsAreNotAllowed = "Az elem(ek) nem felelnek meg a típusnak!";

            public static string GroupIDNullIsNotAllowed = "A csoport ID nem lehet nulla (0), a program által foglalt!";

            public static string GroupNameUnique = "A csoport nevének egyedinek kell lennie!";

            public static string GroupIDUnique = "A csoport ID-nak egyedinek kell lennie!";

            public static string TaskIDUnique = "A feladat ID-jának egyedinek kell lennie a csoport alatt!";

            public static string TaskNameUnique = "A feladat nevének egyedinek kell lennie a csoport alatt!";
            #endregion

            #region WorkingHours

            public static string ErrorDuringLock = "Hiba a zárás közben, próbálja újra.";

            public static string ErrorDuringUnlock = "Hiba a feloldás közben, próbálja újra.";

            #endregion

            #region Holiday

            public static string PublicHoliday = "Nem kell szabadságot kivennie erre az időszakra.";

            public static string PublicHolidayIncluded = "Ebben az időszakban nemzeti ünnep van!";

            public static string SmallerEndDate = "A végdátumnak nagyobbnak kell lenni, mint a kezdő dátumnak.";

            public static string StartDayInActualYear = "A kezdő dátumnak ebben az évben kell lennie.";

            public static string ConflictIDs = "Ezek az azonosítók üzköznek a választott időszakkal: ";

            public static string TooFewRemainingDays = "Nincs elég szabadnapja!";

            public static string ErrorDuringCancellation = "Hiba a lemondás közben, próbálja újra.";

            public static string ErrorLockedHoliday = "Ez az időszak már le van zárva.";

            #endregion

            #region GovernmentHoliday

            public static string PublicHolidaySelected = "A választott dátum egy nemzeti ünnep.";

            public static string ErrorDateExist = "Ez a dátum már hozzá van adva.";

            public static string ErrorExistHoliday = "Ezt a napot már kivette szabadságnak.";

            #endregion
        }

        public static class InformationMessages
        {
            public const string DefaultEmailOrPassword = "Kérem az Ön adatainak védelmében változtassa meg az alapértemezetten kapott felhasználónevet és jelszót!";

            public const string PasswordChanged = "A jelszó sikeresen megváltozott.";

            public const string RulesOfNewPassword = "Az új jelszónak tartalmaznia kell:\n" +
                                                      "- Kis- és nagybetűt\n" +
                                                      "- Legalább egy számot\n" +
                                                      "- Minimum 8 karakter hosszú kell legyen";

            public const string EmailChanged = "E-amil cím sikeresen megváltozott.";

            public const string PersonalInformationChanged = "A személyes adatok sikeresen megváltozott.";

            public const string SuccessfulSave = "Az adat elmentve.";

            public const string SuccessfulLocked = "Az adatok le vannak zárva.";

            public const string SuccessfulUnlocked = "Az adatok feloldva.";

            public const string SuccessfulImported = "Az importálás sikeres volt.";

            public const string SuccessfulExported = "Az exportálás sikeres volt.";

            public const string SuccessfulDocumentCreation = "A dokumentum sikeresen elkészült.";
        }

        public static class WarningMessages
        {
            public static string DeleteTask = "Figyelem\r\n\r\nHa a ki nem választott használatban levő feladatokat törli, akkor beírt órák el fognak veszni.\r\n\r\n" +
                                  "Szeretné folytatni?";

            public static string PersonInformationMissing = "A szabadságok számolásához kérem töltse ki az űrlapot a Személyes Információk alatt.\n"
                                                            + "A beállítások menüpont alatt található.";

            public static string ImportTasks = "Figyelem\r\n\r\nHa beimportálja az új feladatokat, akkor a régiek el fognak veszni\r\n\r\n" +
                                               "és a nem lezárt feladatok a Munkaidő táblázatában törlődni fognak.\r\n\r\n" +
                                               "Szeretné folytatni?";

            public static string DeleteHoliday = "Figyelem\r\n\r\nA ki nem választott szabadságok, amik a Munkaidő táblázatban már használva vannak törlésre kerülnek.\r\n\r\n" +
                                  "Szeretné folytatni?";
        }

        public static class Captions
        {
            public const string Information = "Információ";

            public const string Error = "Hiba";

            public const string Warning = "Figyelmeztetés";



            public const string EmptyRequiredField = "Üres kötelező mező";

            public const string DefaultLoginParameters = "Alapértemezett bejelentkezési adatok";

            public const string PersonalInformationError = "Személyes adatok hiba";

            public const string NumericField = "Szám mező";

            public const string TextField = "Szöveg mező";

            public const string BirthOfDateError = "Születési dátum hiba";

            public const string StartOfDateError = "Munkakezédési dátum hiba";

            public const string NumberOfTheChildrenError = "Gyerek(ek) száma hiba";

            public const string WrongOldValue = "Rossz régi érték";

            public const string MissmatchadPasswords = "Nem eggyező jelszók";

            public const string NewPasswordIsNotAllowed = "Új jelszó nem megfelelő";

            public const string MissmatchadEmails = "Nem eggyező e-mail címek";

            public const string NewEmaildIsNotAllowed = "Új e-mail cím nem megfelelő";

            public const string InvalidEmail = "Nem megfelelő e-mail cím";

            public const string SuccessfulChange = "Sikeres változtatás";

            public static string InvalidValue = "Nem megfelelő érték";

            public static string SuccessfulSave = "Siekres mentés";

            public static string SuccessfulUnlocked = "Sikeres feloldás";

            public static string SuccessLocked = "Sikeres lezárás";

            public static string ErrorSave = "Hiba a mentés során";

            public static string ErrorLock = "Hiba a lezárás során";

            public static string ErrorUnlock = "Hiba a feloldás során";

            public static string LossOfData = "Adatvesztés";
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

