using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace In_out_form
{
    [DataContract]
    public class ReturnData
    {
        [DataMember(Order = 2, Name = "card_quality", IsRequired = true)]
        public string CardQuality { set; get; }

        [DataMember(Order = 3, Name = "parking_position", IsRequired = true)]
        public string ParkingPosition { set; get; }

        [DataMember(Order = 1, Name = "session", IsRequired = true)]
        public string Session { set; get; }

        [DataMember(Order = 0, Name = "enter_time", IsRequired = true)]
        public string EnterTime { set; get; }

        [DataMember(Order = 4, Name = "leave_time", IsRequired = false)]
        public string LeaveTime { get; set; }

        [DataMember(Order = 5, Name = "money", IsRequired = false)]
        public string GetMoney { get; set; }

        [DataMember(Order = 6, Name = "car_num", IsRequired = false)]
        public string CarNum { get; set; }
    }
}
