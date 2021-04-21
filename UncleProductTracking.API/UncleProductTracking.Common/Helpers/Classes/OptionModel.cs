using System;
using System.Collections.Generic;
using System.Text;

namespace UncleProductTracking.Common.Helpers.Classes
{
    public class OptionModel<T>
    {
        public string Label { get; set; }

        public T Value { get; set; }
    }
}
