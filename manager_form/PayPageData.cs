using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace manager_form
{
    [DataContract]
    public class PayPageData
    {
        [DataMember(Order = 0, Name = "car_num", IsRequired = true)]
        public string CarNum { set; get; }

        [DataMember(Order = 1, Name = "arrive_time", IsRequired = true)]
        public string ArriveTime { set; get; }

        [DataMember(Order = 2, Name = "leave_time", IsRequired = true)]
        public string LeaveTime { set; get; }

        [DataMember(Order = 3, Name = "using_time", IsRequired = true)]
        public string UsingTime { set; get; }

        [DataMember(Order = 4, Name = "get_money", IsRequired = true)]
        public string GetMoney { set; get; }

        [DataMember(Order = 5, Name = "card_num", IsRequired = false)]
        public string CardNum { set; get; }
    }
}
