using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactApplication.Models
{
    internal class ContactDetail
    {
        public int ContactDetailId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public ContactDetail(int contactDetailId, string type, string value)
        {
            ContactDetailId = contactDetailId;
            Type = type;
            Value = value;
        }

      
        public override string ToString()
        {
           
            return $"     Contact DetailId : {ContactDetailId}\n" +
                $"     {Type} : {Value}\n";
        }
    }
}
