using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MP_to_Ground_v2
{
    class Class2
    {
        public static void Main(string[] args)
        {
            if (!File.Exists(@"D:\nxopen Projects\MP_to_Ground_v2\JsonFile\jsonData.json"))
            {
                Params myParams = new Params();
                myParams.writeJson();
            }
            Class1 class1 = new Class1();
            Class1.GetUnloadOption("");
        }
    }
}
