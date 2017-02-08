using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Number_Generator
{
    public partial class Form1 : Form
    {

        private string[,] ProductCodes = new string[4,2] 
        {
            {"30","Refrigerator - Compact, under 7.75 cu ft"},
            {"31","Refrigerator - Mid-Size, 7.75 - 12.3 cu ft"},
            {"32","Refrigerator - Large, greater than 12.3 cu ft"},
            {"33","Freezer - Chest"},

        };



        //Format is  : APPRISE CODES , NAME , LOCATION, FACTORY I.D
        private string[,] FactoryID = new string[4, 4]
        {
            {"GALANZ2","Galanz New Plant","Zhongshan","40"},
            {"HEFEIHL","Hefei Hualing,Jinxiu Ave","Hefei,Juixiu Ave","41"},
            {"XINGXI","XingXing","Taizhou","42"},
            {"XINGXIFOS2","XingXing","Foshan","43"}
        };

        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
