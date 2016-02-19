using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace manager_form
{
    [DataContract]
    public class ComboData
    {
        [DataMember(Order = 0, Name = "combo_id", IsRequired = true)]
        public string ComboID { set; get; }
        
        [DataMember(Order = 1, Name = "combo_name", IsRequired = true)]
        public string ComboName { set; get; }

        [DataMember(Order = 2, Name = "free_hour", IsRequired = true)]
        public string FreeHour { set; get; }

        [DataMember(Order = 3, Name = "combo_money", IsRequired = true)]
        public string ComboMoney { set; get; }

        [DataMember(Order = 4, Name = "money_per_hour", IsRequired = true)]
        public string MoneyPerHour { set; get; }
    }
}
