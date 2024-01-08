using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGageConverter
{
    // This structure is used to map the CSV file into the correct datatypes
    // If you are using more than 2 user feilds (UF_##), this code must be modified
    public struct RzgConverter
    {
        public int AutoNumber;
        public string FILENAME;
        public int SEQ_NUMBER;
        public int QUANTITY;
        public string PART;
        public string MATERIAL;
        public double WIDTH;
        public double LENGTH;
        public double THICKNESS;
        public string SCRIBES;
        public string SPACEBALLS;
        public bool POCKETHOLES;
        public bool PANEL;
        public bool B_GRADE;
        public string UF_1;
        public string UF_2;
        // Extra user fields we don't use
        //public string UF_3;
        //public string UF_4;
        //public string UF_5;
        //public string UF_6;
        //public string UF_7;
        //public string UF_8;
        //public string UF_9;
        //public string UF_10;
        //public string UF_11;
        //public string UF_12;
        //public string UF_13;
        //public string UF_14;
        //public string UF_15;
        //public string UF_16;
        //public string UF_17;
        //public string UF_18;
        //public string UF_19;
        //public string UF_20;
        public RzgConverter(int autoNumber, string fileName, int seqNumber, int quantity, string part, string material, double width, double length, double thickness, string scribes, string spaceballs, bool pocketHoles, bool panel, bool bGrade, string uf1, string uf2)
        {
            AutoNumber = autoNumber;
            FILENAME = fileName;
            SEQ_NUMBER = seqNumber;
            QUANTITY = quantity;
            PART = part;
            MATERIAL = material;
            WIDTH = width;
            LENGTH = length;
            THICKNESS = thickness;
            SCRIBES = scribes;
            SPACEBALLS = spaceballs;
            POCKETHOLES = pocketHoles;
            PANEL = panel;
            B_GRADE = bGrade;
            UF_1 = uf1;
            UF_2 = uf2;
            //UF_3 = uf3;
            //UF_4 = uf4;
            //UF_5 = uf5;
            //UF_6 = uf6;
            //UF_7 = uf7;
            //UF_8 = uf8;
            //UF_9 = uf9;
            //UF_10 = uf10;
            //UF_11 = uf11;
            //UF_12 = uf12;
            //UF_13 = uf13;
            //UF_14 = uf14;
            //UF_15 = uf15;
            //UF_16 = uf16;
            //UF_17 = uf17;
            //UF_18 = uf18;
            //UF_19 = uf19;
            //UF_20 = uf20;
        }
    }
}
