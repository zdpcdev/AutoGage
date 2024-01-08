using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGageConverter
{
    public static class AppDataHelper
    {
        public static string ADH(string pathtoappend)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), pathtoappend);
        }
    }
}
