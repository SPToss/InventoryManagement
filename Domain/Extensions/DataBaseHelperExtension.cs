using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Extensions
{
    public static class DataBaseHelperExtension
    {
        public static bool ActiveToBool(this int x) => x == 1;
        public static int ActiveToInt(this bool x) => x ? 1 : 0;
    }
}
