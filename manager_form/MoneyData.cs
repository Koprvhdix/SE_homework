using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace manager_form
{
    [DataContract]
    public class MoneyData
    {
        [DataMember(Order = 0, Name = "left_money", IsRequired = true)]
        public int money { set; get; }
    }
}
