using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace MP_to_Ground_v2
{
    public class Params
    {
        private static dParam dparam = null;
        private static dOffset doffset = null;

        public Params()
        {
            dparam = new dParam(25.0, 95.0);
            doffset = new dOffset(5.0, 2.0);
        }
        class dParam
        {
            //double point1 = 25;
            //double point2 = 95;
            public  double point1 { get; set; }
            public  double point2 { get; set; }

            public dParam(double _pt1, double _pt2)
            {
                point1 = _pt1;
                point2 = _pt2;
            }
        }
        
        class dOffset
        {
            public double oPt1 { get; set; }
            public double oPt2 { get; set; }

            public dOffset(double _Offset1, double _Offset2)
            {
                oPt1 = _Offset1;
                oPt2 = _Offset2;
            }
        }

        public void writeJson()
        {
            List<string> jsonData = new List<string>();
            jsonData.Add(JsonConvert.SerializeObject(dparam));
            jsonData.Add(JsonConvert.SerializeObject(doffset));

            File.AppendAllLines(@"D:\nxopen Projects\MP_to_Ground_v2\JsonFile\jsonData.json", jsonData);
        }

        public void ReadJson(out double[] points, out double[] offsetValues)
        {
            string[] jsonData = File.ReadAllLines(@"D:\nxopen Projects\MP_to_Ground_v2\JsonFile\jsonData.json");

            dParam temp1 = JsonConvert.DeserializeObject<dParam>(jsonData[0]);
            dOffset temp2 = JsonConvert.DeserializeObject<dOffset>(jsonData[1]);

            points = new double[] { temp1.point1 , temp1.point2};
            offsetValues = new double[] { temp2.oPt1, temp2.oPt2 };
        }
    }
}
