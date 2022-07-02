using System;

namespace ISP_Project
{
    class User
    {
        //Signup and Login
        private string _name;
        private string _fatherName;
        private long _mobile;
        private string _email;
        private string _password;
        private string _confirm;
        private DateTime _date; //DOB
        private string _address;        

        //Government ID
        private string _governmentID;

        //Plans        
        string planType;        
        double cost;
        int validity;
        string details;
        DateTime dateNow = DateTime.Now;
        DateTime dateTime;
        

        public User(string name, string fatherName, long mobile, string email, string password, string confirm, DateTime date, string address)
        {
            _name = name;
            _fatherName = fatherName;
            _mobile = mobile;
            _email = email;
            _password = password;
            _confirm = confirm;
            _date = date;
            _address = address;
        }

        public User(string planType, double cost, int validity, string details)
        {
            this.PlanType = planType;
            this.Cost = cost;
            this.Validity = validity;
            this.Details = details;
        }
        public User(string name, long mobile,string email, string planType, double cost, int validity, string details)
        {
            this.Name = name;
            this.Mobile = mobile;
            this.PlanType = planType;
            this.Cost = cost;
            this.Validity = validity;
            this.Details = details;
            this.Email = email;
        }

        public User(string name, long mobile, string email)
        {
            _name = name;
            _mobile = mobile;
            _email = email;
        }

        public User(long mobile)
        {
            _mobile = mobile;           
        }

        public User(string email)
        {
            _email = email;
        }

        public User(string planType, double cost, int validity, string details, DateTime dateTime)
        {           
            this.planType = planType;           
            this.cost = cost;
            this.validity = validity;
            this.details = details;
            this.dateTime = dateTime;
        }

        public string Name { get => _name; set => _name = value; }
        public string FatherName { get => _fatherName; set => _fatherName = value; }
        public long Mobile { get => _mobile; set => _mobile = value; }
        public string Email { get => _email; set => _email = value; }
        public string Password { get => _password; set => _password = value; }
        public string Confirm { get => _confirm; set => _confirm = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public string Address { get => _address; set => _address = value; }
        public string GovernmentID { get => _governmentID; set => _governmentID = value; }
        public string PlanType { get => planType; set => planType = value; }
        public double Cost { get => cost; set => cost = value; }
        public int Validity { get => validity; set => validity = value; }
        public string Details { get => details; set => details = value; }
        public DateTime DateNow { get => dateNow; set => dateNow = value; }
        public DateTime DateTime { get => dateTime; set => dateTime = value; }
    }
}
