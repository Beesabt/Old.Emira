using System;

namespace emira.ValueObjects
{
    class Person
    {

        #region Members

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        private bool _Gender;

        public bool Gender
        {
            get { return _Gender; }
            set { _Gender = value; }
        }

        private int _RegisterNumber;

        public int RegisterNumber
        {
            get { return _RegisterNumber; }
            set { _RegisterNumber = value; }
        }

        private string _Company;

        public string Company
        {
            get { return _Company; }
            set { _Company = value; }
        }

        private string _CostCenter;

        public string CostCenter
        {
            get { return _CostCenter; }
            set { _CostCenter = value; }
        }

        private string _Position;

        public string Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        private int _WorkingHours;

        public int WorkingHours
        {
            get { return _WorkingHours; }
            set { _WorkingHours = value; }
        }

        private DateTime _DateOfStart;

        public DateTime DateOfStart
        {
            get { return _DateOfStart; }
            set { _DateOfStart = value; }
        }

        private DateTime _DateOfBirth;

        public DateTime DateOfBirth
        {
            get { return _DateOfBirth; }
            set { _DateOfBirth = value; }
        }

        private int _NumberOfChildren;

        public int NumberOfChildren
        {
            get { return _NumberOfChildren; }
            set { _NumberOfChildren = value; }
        }

        private int _NumberOfDisabledChildren;

        public int NumberOfDisabledChildren
        {
            get { return _NumberOfDisabledChildren; }
            set { _NumberOfDisabledChildren = value; }
        }

        private int _NumberOfNewBornBabies;

        public int NumberOfNewBornBabies
        {
            get { return _NumberOfNewBornBabies; }
            set { _NumberOfNewBornBabies = value; }
        }

        private bool _HealthDamage;

        public bool HealthDamage
        {
            get { return _HealthDamage; }
            set { _HealthDamage = value; }
        }

        private int _HolidaysLeftFromPreviousYear;

        public int HolidaysLeftFromPreviousYear
        {
            get { return _HolidaysLeftFromPreviousYear; }
            set { _HolidaysLeftFromPreviousYear = value; }
        }

        private int _ExtraHoliday;

        public int ExtraHoliday
        {
            get { return _ExtraHoliday; }
            set { _ExtraHoliday = value; }
        }

        #endregion

        /// <summary>
        /// Constructor of the People table in the Database without parameters.
        /// </summary>
        public Person(){ }

    }
}
