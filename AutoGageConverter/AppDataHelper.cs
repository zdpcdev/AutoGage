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
        public static string AD(string defaultadf)
        {
            return (Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), defaultadf));
        }
        public static string ADH(string pathtoappend)
        {
            string combo = Path.Combine("AutoGage", pathtoappend);
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), combo);
        }
    }
}
