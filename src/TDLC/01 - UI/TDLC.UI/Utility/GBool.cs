using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDLC.UI.Utility
{

    public class GBool
    {
        public bool Value { get; set; }
        public GBool(bool? _value)
        {
            Value = Convert.ToBoolean(_value);
        }
    }



}
