using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration
{
   class Registration
    {
        string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }


        string _phoneno;

        public string Phoneno
        {
            get { return _phoneno; }
            set
            {
                if (value.Length== 10)
                {
                    _phoneno = value;
                }
                else
                {
                    throw new Exception("Pls Enter only 10 digit");
                }
            }
                
        }

       
        string emailid;

        public string Emailid
        {
            get { return emailid; }
            set { emailid = value; }
        }
       
        string password;

        public string Password
        {
            get { return password; }
            set {
                if (value.Length >= 9)
                {
                    password = value;
                }
                else
                {
                    throw new Exception("Pls enter atleast 9 charachters");
                }
            }

        }

    }
}
