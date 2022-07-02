using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ISP_Project
{
    class AirLinkADO
    {
        SqlConnection conn = DBConnection.GetConnection();

        public bool SignUP(User obj)
        {
            bool flag = false;
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into SignUpAndLogin(name,fatherName,mobileNumber,emailId,password,dob,_address) values(@name,@fatherName,@mobileNumber,@emailId,@password,@dob,@_address)", conn);
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@fatherName",obj.FatherName);
            cmd.Parameters.AddWithValue("@mobileNumber",obj.Mobile);
            cmd.Parameters.AddWithValue("@emailId", obj.Email);
            cmd.Parameters.AddWithValue("@password", obj.Password);
            cmd.Parameters.AddWithValue("@dob", obj.Date);
            cmd.Parameters.AddWithValue("@_address", obj.Address);
            
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                flag = true;
            }
            conn.Close();
            return flag;
        }
        
        public bool ValidateMobile(long mobile)
        {
            bool flag = false;
            conn.Open();
            SqlCommand cmd = new SqlCommand("ValidateMobile", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@mobile", mobile);
            int Result = (int)cmd.ExecuteScalar();
            if (Result > 0)
            {
                flag = true;
            }
            conn.Close();
            return flag;
        }
        public bool ValidatePass(long mobile, string password)
        {
            bool flag = false;
            conn.Open();
            SqlCommand cmd = new SqlCommand("ValidatePass", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@mobile", mobile);            
            int Result = (int)cmd.ExecuteScalar();
            if (Result > 0)
            {
                flag = true;
            }
            conn.Close();
            return flag;
        }

        public bool ValidateEmail(string emailId)
        {
            bool flag = false;
            conn.Open();
            SqlCommand cmd = new SqlCommand("ValidateEmail", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@emailID", emailId);
            int Result = (int)cmd.ExecuteScalar();
            if (Result > 0)
            {
                flag = true;
            }
            conn.Close();
            return flag;
        }
        public bool ValidatePassword(string password, string emailId)
        {
            bool flag = false;
            conn.Open();
            SqlCommand cmd = new SqlCommand("ValidatePassword", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@email", emailId);
            int Result = (int)cmd.ExecuteScalar();
            if (Result > 0)
            {
                flag = true;
            }
            conn.Close();
            return flag;
        }

        public bool CheckUser(string governmentID)
        {
            bool flag = false;
            conn.Open();
            SqlCommand cmd = new SqlCommand("checkUser",conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@idNumber", governmentID);
            int Result = (int)cmd.ExecuteScalar();
            if (Result > 0)
            {
                flag = true;
            }
            conn.Close();
            return flag;
        }

        public List<User> Plans()
        {
            List<User> li = new List<User>();
            conn.Open();
            SqlCommand selCmd = new SqlCommand("select planType,cost,validity,details from Plans", conn);
            SqlDataReader dr = selCmd.ExecuteReader();

            while (dr.Read())
            {
                User obj = new User(dr.GetString(0), Convert.ToDouble(dr[1]), Convert.ToInt32(dr[2]), dr.GetString(3));
                li.Add(obj);
            }
            conn.Close();
            return li;
        }
        public bool ValidatePlan(int plan)
        {
            bool flag = false;
            conn.Open();
            SqlCommand cmd = new SqlCommand("ValidatePlan", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@plan", plan);
            int Result = (int)cmd.ExecuteScalar();
            if (Result > 0)
            {
                flag = true;
            }
            conn.Close();
            return flag;
        }

        public User GetName(long mobile)
        {
            conn.Open();
            SqlCommand selCmd = new SqlCommand("select name,mobileNumber,emailId from SignUpAndLogin where mobileNumber = @mobile", conn);
            selCmd.Parameters.AddWithValue("@mobile", mobile);
            SqlDataReader dr = selCmd.ExecuteReader();

            dr.Read();
            User obj = new User(dr.GetString(0), Convert.ToInt64(dr[1]), dr.GetString(2));
            conn.Close();
            return obj;
        }
        public User GetName(string email)
        {
            conn.Open();
            SqlCommand selCmd = new SqlCommand("select name,mobileNumber from SignUpAndLogin where emailId = @email", conn);
            selCmd.Parameters.AddWithValue("@email", email);
            SqlDataReader dr = selCmd.ExecuteReader();

            dr.Read();
            User obj = new User(dr.GetString(0), Convert.ToInt64(dr[1]), email);
            conn.Close();
            return obj;
        }
        
        public bool InsertCurrentPlan(User obj)
        {            
            bool flag = false;
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into CurrentPlan(name,planType,mobile,cost,validity,details,_date,email,ExpiryDate) values(@name,@planType,@mobile,@cost,@validity,@details,@date,@email,@expiry)", conn);
            cmd.Parameters.AddWithValue("@name", obj.Name);
            cmd.Parameters.AddWithValue("@mobile", obj.Mobile);
            cmd.Parameters.AddWithValue("@planType", obj.PlanType);
            cmd.Parameters.AddWithValue("@cost", obj.Cost);
            cmd.Parameters.AddWithValue("@validity", obj.Validity);
            cmd.Parameters.AddWithValue("@details", obj.Details);
            cmd.Parameters.AddWithValue("@date", obj.DateNow);
            cmd.Parameters.AddWithValue("@email", obj.Email);
            cmd.Parameters.AddWithValue("@expiry", obj.DateNow.AddDays(obj.Validity));
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                flag = true;
            }
            conn.Close();
            return flag;
        }
        public List<User> CurrentPlan(long mobile)
        {
            List<User> li = new List<User>();
            conn.Open();
            SqlCommand selCmd = new SqlCommand("select planType,cost,validity,details,ExpiryDate from CurrentPlan", conn);
            SqlDataReader dr = selCmd.ExecuteReader();

            while (dr.Read())
            {
                User obj = new User(dr.GetString(0), Convert.ToDouble(dr[1]), dr.GetInt32(2), dr.GetString(3), dr.GetDateTime(4));
                li.Add(obj);
            }
            conn.Close();
            return li;
        }
        public List<User> CurrentPlan(string email)
        {
            List<User> li = new List<User>();
            conn.Open();
            SqlCommand selCmd = new SqlCommand("select planType,cost,validity,details,ExpiryDate from CurrentPlan", conn);
            SqlDataReader dr = selCmd.ExecuteReader();

            while (dr.Read())
            {
                User obj = new User(dr.GetString(0), Convert.ToDouble(dr[1]), dr.GetInt32(2), dr.GetString(3), dr.GetDateTime(4));
                li.Add(obj);
            }
            conn.Close();
            return li;
        }
    }
}
