using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace manager_form
{
    [DataContract]
    public class ParkingInformation
    {
        [DataMember(Order = 0, Name = "parking_id", IsRequired = true)]
        public string ParkingID { set; get; }

        [DataMember(Order = 1, Name = "parking_describe", IsRequired = true)]
        public string ParkingDescribeName { set; get; }
    }
}
