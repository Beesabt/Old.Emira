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

        #endregion

        /// <summary>
        /// Constructor of the People table in the Database.
        /// </summary>
        /// <param name="ID">ID of the user.</param>
        /// <param name="Password">Password of the user.</param>
        /// <param name="Email">Email address of the user.</param>
        /// <param name="Name">Name of the user.</param>
        /// <param name="Gender">Gender of the user. 0 - female, 1 - male </param>
        /// <param name="RegisterNumber">Register number of the user.</param>
        /// <param name="Company">Compay name where the user works.</param>
        /// <param name="CostCenter">Cost center of the user.</param>
        /// <param name="Position">Position of the user at his/her company.</param>
        /// <param name="WorkingHours">Hours what the employee has to takes in the office.</param>
        /// <param name="DateOfStart">First date of work.</param>
        /// <param name="DateOfBirth">Birth date of the user.</param>
        /// <param name="NumberOfChildren">Number of the user's children.</param>
        /// <param name="NumberOfDisabledChildren">Number of the user's disabled children.</param>
        /// <param name="NumberOfNewBornBabies">If the user is male then he gets extra holidays after new born babies.</param>
        public Person(int ID, string Email, string Password, string Name, bool Gender, int RegisterNumber, string Company,
            string CostCenter, string Position, int WorkingHours, DateTime DateOfStart, DateTime DateOfBirth,
            int NumberOfChildren, int NumberOfDisabledChildren, int NumberOfNewBornBabies)
        {
            _ID = ID;
            _Email = Email;
            _Password = Password;
            _Name = Name;
            _Gender = Gender;
            _RegisterNumber = RegisterNumber;
            _Company = Company;
            _CostCenter = CostCenter;
            _Position = Position;
            _WorkingHours = WorkingHours;
            _DateOfStart = DateOfStart;
            _DateOfBirth = DateOfBirth;
            _NumberOfChildren = NumberOfChildren;
            _NumberOfDisabledChildren = NumberOfDisabledChildren;
            _NumberOfNewBornBabies = NumberOfNewBornBabies;
        }

        /// <summary>
        /// Constructor of the People table in the Database without parameters.
        /// </summary>
        public Person(){ }

    }
}
