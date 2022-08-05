using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.DL;
using UAMS.UI;

namespace UAMS.BL
{
    internal class Subject
    {
        public string subjectCode { get; set; }
        public int subjectCreditHours { get; set; }
        public string subjectType { get; set; }
        public int subjectFee { get; set; }
        public Subject(string subjectCode, int subjectCreditHours, string subjectType, int subjectFee)
        {
            this.subjectCode = subjectCode;
            this.subjectCreditHours = subjectCreditHours;
            this.subjectType = subjectType;
            this.subjectFee = subjectFee;
        }
    }
}
