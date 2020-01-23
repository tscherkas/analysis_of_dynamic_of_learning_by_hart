using DLH_BusinessLibrary;
using DLH_DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_module.Helpers
{
    public static class StimulusHelper
    {
        public static IEnumerable<Stimulus> ToBusinessObject(this IEnumerable<DLH_Stimulus> s)
        {
            return s.Select(st => new Stimulus
                {
                    ID = st.ID,
                    Value = st.value
                });
        }
        public static DLH_Stimulus ToDataTransferObject(this Stimulus s)
        {
            return new DLH_Stimulus
            {
                ID = s.ID,
                value = s.Value
            };
        }
    }
}
