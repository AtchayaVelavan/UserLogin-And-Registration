using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace UserRegistration
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("A.Register");
            Console.WriteLine("B.Login");

            Registration r = new Registration();

            Console.Write("Select An Option:");
            string choice = Console.ReadLine();
           
             if (choice == "A")
            {
                 register( );   
            }

             else if (choice == "B")
             {
                 login();
             }
            else
            {
                Console.WriteLine("Enter Correct Option");


            }
             
           
        }

        public static void register( )
        {
             Registration reg = new Registration();

                Console.Write("Name:");
                string name = Console.ReadLine();
                reg.Name = name;

                Console.Write("PhNo:");
                string phno = Console.ReadLine();
                reg.Phoneno = phno;

                Console.Write("EmailId:");
                string emailid = Console.ReadLine();
                reg.Emailid = emailid;

                Console.Write("PassWord:");
                string password = Console.ReadLine();
                reg.Password = password;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=DESKTOP-S9M63N0\\SQLEXPRESS;Database=UserRegistration;integrated security=true;";
            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                throw new Exception("connection is not proper");
            }

            SqlCommand comm = new SqlCommand();
            comm.Connection = con;
            comm.CommandText = "insert into registration values('" + name + "','" + phno + "','" + emailid + "','" + password + "')";
            comm.ExecuteNonQuery();

            Console.WriteLine("Register Successfully");

            Console.WriteLine("Choose an option");
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Exit");
            int ans = int.Parse(Console.ReadLine());
            if (ans == 1)
            {
                login();
            }
            else
            {
                
            }

        }
        


            
        public static void login()
          {
              Console.Write("EmailId:");
              string emailid = Console.ReadLine();
              Console.Write("PassWord:");
              string password = Console.ReadLine();
              bool success = false;
              do
              {

                  string password2 = password;
                  SqlConnection con = new SqlConnection();
                  con.ConnectionString = "Server=DESKTOP-S9M63N0\\SQLEXPRESS;Database=UserRegistration;integrated security=true;";
                  try
                  {
                      con.Open();
                  }
                  catch (Exception e)
                  {
                      throw new Exception("connection is not proper");
                  }
                  SqlCommand comm = new SqlCommand();
                  comm.Connection = con;
                  comm.CommandText = "select Emailid from registration where Emailid='" + emailid + "'";
                  string Emailid = (string)comm.ExecuteScalar();
                  if (Emailid != emailid)
                  {
                      Console.WriteLine("Ur Email id is Not in the list Pls Register");
                      register();
                  }
                  comm.CommandText = "select  Passcode from registration where Emailid='" + emailid + "'";
                  string passcode = (string)comm.ExecuteScalar();
                  if (password2 == passcode)
                  {
                      Console.WriteLine("Login Successfully");
                      success = true;
                      break;
                  }
                  else if (passcode != password2)
                  {

                      Console.WriteLine("Password is wrong");
                      Console.WriteLine("Choose An Option");

                      Console.WriteLine("1.Re Enter The PassWord");
                      Console.WriteLine("2.Forgot Password");
                      Console.Write("Enter Ur Choice:");
                      int a = int.Parse(Console.ReadLine());
                      if (a == 1)
                      {
                          Console.Write("Password:");
                          string repassword = Console.ReadLine();

                          password = repassword;

                      }
                      if (a == 2)
                      {
                          Console.WriteLine("Enter Ur New Password");
                          string newpassword = Console.ReadLine();
                          //Registration r = new Registration();
                          //r.Password = newpassword;
                          comm.CommandText = "update registration SET passcode='" + newpassword + "' where Emailid='" + emailid + "'";
                          comm.ExecuteNonQuery();

                          Console.WriteLine("Changed");


                          login();

                      }
                  }
                  else
                  {
                      Console.WriteLine("Not register pls Register");

                      register();
                  }
              } while (success == true);


         }
       
        
        
        


    }
}