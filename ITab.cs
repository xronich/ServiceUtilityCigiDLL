using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceUtilityCigiDLL
{
    public abstract class ITab
    {
        public virtual float checkValue(string value)
        {
            string oldValue = value.Replace('.', ',');
            float parseValue;
            if (float.TryParse(oldValue, out parseValue))
                return (parseValue > 0) ? parseValue : 0;
            else
                return 0;
        }

        public abstract void EnableControl(bool enable);
    }
}
