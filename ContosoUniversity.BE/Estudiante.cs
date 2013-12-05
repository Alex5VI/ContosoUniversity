using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ContosoUniversity.BE
{
    [DataContract]
    public class Estudiante
    {
        private int _StudentID;
        private string _LastName;
        private string _FirstName;
        private string _EnrollmentDate;

        [DataMember]
        public int StudentID
        {
            get
            {
                return _StudentID;
            }
            set
            {
                _StudentID = value;
            }
        }

        [DataMember]
        public string LastName
        {
            get
            {
                return _LastName;
            }
            set
            {
                _LastName = value;
            }
        }

        [DataMember]
        public string FirstName
        {
            get
            {
                return _FirstName;
            }
            set
            {
                _FirstName = value;
            }
        }

        [DataMember]
        public string EnrollmentDate
        {
            get
            {
                return _EnrollmentDate;
            }
            set
            {
                _EnrollmentDate = value;
            }
        }
    }
}
