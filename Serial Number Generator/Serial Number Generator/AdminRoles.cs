/*
 
 TO-DO : - Close LoginWindow form in case of exceptions.
         - What if user close this windows by clicking red cross button, then paren windwow (login) will still be there.  
         - Create serial Number, add in DB, show print label button, print the label, 
         - Check exception messages, and handle exceptions 
         - Log all exceptions

         - DateTime format to store in db is YYYY-MM-DD
         - Perform some sort of check on all functions - bool check
         - Check duplicate serial numbers
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using MySql.Data.MySqlClient;

namespace Serial_Number_Generator
{
    public partial class AdminRoles : Form
    {

        private static Form RefToLoginForm;
        private static Int32 CurrentUserid;


        ////Product Codes Format :  Product Code & Product Category
        //private string[,] ProductCodes = new string[28, 2]
        //{
        //    {"30","Refrigerator - Compact, under 7.75 cu ft"},
        //    {"31","Refrigerator - Mid-Size, 7.75 - 12.3 cu ft"},
        //    {"32","Refrigerator - Large, greater than 12.3 cu ft"},
        //    {"33","Freezer - Chest"},
        //    {"34","Freezer Upright" },
        //    {"35","Wine Cooler" },
        //    {"36","Beverage Center and Party Center" },
        //    {"37","Keg Cooler" },
        //    {"38","Ice Maker" },
        //    {"39","Dishwasher - Countertop" },
        //    {"40","Dishwasher - 18\"" },
        //    {"41","Waher - Twin Tub" },
        //    {"42","Washer - Top Landing" },
        //    {"43","Microwaves - 0 to 0.7 cubic ft" },
        //    {"44","Microwaves - 0.71 cubic ft and greater" },
        //    {"45","Air Conditioner - Portable, 1 to 9999 btu" },
        //    {"46","Air Conditioner - Portable, 10000 and 11999" },
        //    {"47","Air Conditioner - Portable, 12000 and greater" },
        //    {"48","Air Conditioner - Room, 1 to 5999 btu" },
        //    {"49","Air Conditioner - Room, 6000 to 9999 btu" },
        //    {"50","Air Conditioner - Room, 10000 btu and greater" },
        //    {"51","Dehumidifier - 1 to 50 pints" },
        //    {"52","Dehumidifier - 51 pints and greater" },
        //    {"53","Assembled Frig/Microwave" },
        //    {"54","Niche" },
        //    {"55","Small Appliances" },
        //    {"56","Pedestal" },
        //    {"57","Safe" }
        //};



        ////Factory Supplier Codes Format is  : APPRISE CODES , NAME , LOCATION, FACTORY I.D
        //private string[,] FactoryIDs = new string[32, 4]
        //{
        //    {"GALANZ2","Galanz New Plant","Zhongshan","40"}, {"HEFEIHL","Hefei Hualing,Jinxiu Ave","Hefei,Juixiu Ave","41"}, {"","","","42" },
        //    {"XINGXI","XingXing","Taizhou","43"}, {"XINGXIFOS2","XingXing","Foshan","44"},
        //    {"MDDOME","Midea AC","Shunde","45"}, {"MDDOME2","Mideo Dishawasher","Foshan","46" },
        //    {"MDDOME3","Mideo Microwave","Shunde","47" }, {"MDDOME5","Midea AC","Wuhu","48" },
        //    {"NEWWIDET","New Widetech","Kaiping City","49" }, {"MEILING","Meiling","Hefei","50" },
        //    {"HEIFEIHL","Hefei Hualing, Yulan Ave","Hefei, Yulan Ave","51" }, {"HOMAAPPL","Homa","Zhongshan","52" },
        //    {"MEIHE","Meihe","Dongguan","53" }, {"SHUNXI","Shunxiang","Zhongshan","54" },
        //    {"JINLIN","Jingling","Jiangmen","55" },{"MINEA","Minea","Zhongshan","56" },
        //    {"JINTONG","Jintong","Ningbo","57" },{"EUROASIA","Euroasia","Zhongshan","58" },
        //    {"GALANZ","Galanz Main Location","","59" },{"GREEELEC","Gree","Zhuhai","61" },
        //    {"TCL","TCL","Zhongshan","62" }, {"HOMESU","Shunde Homesun","Shunde","63" },
        //    {"CANDOR","Zhongshan Candor","Zhongshan","64" }, {"YOAO","Youao","Changzhou","65" },
        //    {"LMD01M","Assembly Location","Rancho California","08" },{"MDDOME4","Midea Hualing Refrigerator CO.,LTD","Guangzhou","66" },
        //    {"8000129","Panasonic","San Diego","67" },{"XINBAO","Xinbao","Foshan","68" },
        //    {"QNN","QNN Safe Manufacturing Co LTD","Foshan, Guandong","69" },{"JHS","Dongguan JHS Electrical Co LTD","Dongguan, China","70" }, {"DANBYLTD","Danby Products Ltd","Guelph, Ontario","71" }
        //};


        public AdminRoles(Form form = null, Int32 currentuserid = 0)
        {
            InitializeComponent();

            //assign LoginWindow
            RefToLoginForm = form;

            //currentuserID is using the admin screen
            CurrentUserid = currentuserid;

            //load all factory codes and product codes
            GetAllAppriseCodesForFactory();
            GetAllProductCodes();    
        }

       

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {        
            MessageBox.Show("Logged Out");
            RefToLoginForm.Show();
            Close();
        }

        private void AdminRoles_FormClosing(object sender, FormClosingEventArgs e)
        {
            RefToLoginForm.Show();
        }


        private void GetAllAppriseCodesForFactory()
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=zeronext;UID=root;Password=admin");
                connection.Open();

                MySqlDataReader myreader = null;
                MySqlCommand command = new MySqlCommand("select apprisecodes from factoryids where AppriseCodes != '';", connection);
                myreader = command.ExecuteReader();
                if (myreader.HasRows)
                {
                    FactoryIDComboBox.Text = "Select Apprise Code";
                    while(myreader.Read())
                    FactoryIDComboBox.Items.Add(myreader.GetString(0));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("");
                //TO-DO
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void GetAllProductCodes()
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=zeronext;UID=root;Password=admin");
                connection.Open();

                MySqlDataReader myreader = null;
                MySqlCommand command = new MySqlCommand("SELECT productcode FROM zeronext.productcodes where ProductCode != '';", connection);
                myreader = command.ExecuteReader();
                if (myreader.HasRows)
                {
                    ProductIDComboBox.Text = "Select Product Code";
                    while (myreader.Read())
                        ProductIDComboBox.Items.Add(myreader.GetString(0));
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("");
                //TO-DO
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void CreateSerialNumberButton_Click(object sender, EventArgs e)
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=zeronext;UID=root;Password=admin");
                connection.Open();
                               
                MySqlCommand command = new MySqlCommand("INSERT INTO serialnumbers (serialnumbers.SerialNumber,serialnumbers.ProductCode,serialnumbers.ProductCategory,serialnumbers.FactoryID,serialnumbers.FactoryAppriseCodes,serialnumbers.SerialCreationDate, CreatedBy) values(1234567891234, 34, 'Freezer Chest', 43, 'XINGXI', '2017/02/08'," + CurrentUserid + "); ", connection);
                int a = command.ExecuteNonQuery();
                
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message.ToString());
                //TO-DO
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }
    }
}
