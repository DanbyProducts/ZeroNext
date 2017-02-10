/*
 
 TO-DO : - Close LoginWindow form in case of exceptions.
         - What if user close this windows by clicking red cross button, then paren windwow (login) will still be there.  
         - Create serial Number, add in DB, show print label button, print the label, 
         - Check exception messages, and handle exceptions 
         - Log all exceptions.

         - DateTime format to store in db is YYYY-MM-DD
         - Perform some sort of check on all functions - bool check
         - Check duplicate serial numbers
         - Create a function to keep mysql connection, dont connect everytime in a new function ( try putting in admin static class).
         - Check for custom exceptions
         - check for all values ( class members )  their values before using it. like if it null/0/empty
         - check if serial numbers table is empty or not, to insert first row
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

            //checking
            if (form != null && currentuserid != 0)
            {
                //assign LoginWindow
                AdminClass.RefToLoginForm = form;

                //currentuserID is using the admin screen
                AdminClass.CurrentUserid = currentuserid;

                //load all factory codes and product codes
                if(GetAllAppriseCodesForFactory())
                    GetAllProductCodes();
            }
            else
            {
                //something went wrong from login window to adminwindow
                MessageBox.Show("Something went wrong. Try Again");
            }
        }

       

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {        
            MessageBox.Show("Logged Out");
            AdminClass.RefToLoginForm.Show();
            Close();
        }

        private void AdminRoles_FormClosing(object sender, FormClosingEventArgs e)
        {
            AdminClass.RefToLoginForm.Show();
        }


        private bool GetAllAppriseCodesForFactory()
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
                //-//Log exception 
                MessageBox.Show("Getting Apprise Codes Error.");
                return false;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return true;
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
                //-//Log exception 
                MessageBox.Show("Getting Product Codes Error.");                
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }            
        }

        private void CreateSerialNumberButton_Click(object sender, EventArgs e)
        {
            if (GetFormData())
            {
                Int64 serialnumber = SerialNumberQuery();

                //Length is 13. Not first time serial number for this product code
                if (serialnumber.ToString().Length == Constants.SERIALNUMBERLENTH)
                {
                    //check the serial as per business reqs before incrementing and inserting into db.
                              
                                
                }
                //first time serial number for this product code 
                else
                {
                    //first serial number for this product code
                    //create first time serial number for this category
                    
                    

                }

                InsertSerialNumberToDb(serialnumber);
            }
        }


        private bool GetFormData()
        {
            try
            {
                if (FactoryIDComboBox.SelectedIndex == -1)
                {
                    FactoryIDErrorLabel.Text = "*";
                }
                else
                {
                    FactoryIDErrorLabel.Text = "";
                    AdminClass.FactoryAppriseCode = FactoryIDComboBox.SelectedItem.ToString();
                }

                if (ProductIDComboBox.SelectedIndex == -1)
                {
                    ProductIDErrorLabel.Text = "*";
                }
                else
                {
                    ProductIDErrorLabel.Text = "";
                    Int32.TryParse(ProductIDComboBox.SelectedItem.ToString(), out AdminClass.ProductCode);
                }
                if (FactoryIDComboBox.SelectedIndex == -1 || ProductIDComboBox.SelectedIndex == -1)
                    return false;
            }
            catch(Exception ex)
            {
                //-//Log exception
                MessageBox.Show("Something went wrong. Try Again!"); 
            }
            return true;
        }

        private static Int64 SerialNumberQuery()
        {
            //get last serial number created in a product category

            Int64 lastserialnumberofproductcategory = 0;

            //get last serial number of each product category
            MySqlConnection connection = null;
            try
            {
                MySqlDataReader myreader = null;
                connection = new MySqlConnection("Server=localhost;Database=zeronext;UID=root;Password=admin");
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT SerialNumber FROM serialnumbers where ProductCode=" + AdminClass.ProductCode + " Order by serialNumberID desc limit 1;", connection);

                myreader = command.ExecuteReader();
                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        lastserialnumberofproductcategory = myreader.GetInt64(0);
                    }
                }
                else
                {
                    return 1;
                }
            }
            catch (MySqlException ex)
            {
                //-//Log exception 
                MessageBox.Show(ex.Message.ToString());
                return 0;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return lastserialnumberofproductcategory;
        }


        //make it static
        private bool InsertSerialNumberToDb(Int64 serialnumber)
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=zeronext;UID=root;Password=admin");
                connection.Open();

                MySqlCommand command = new MySqlCommand("INSERT INTO serialnumbers (serialnumbers.SerialNumber,serialnumbers.ProductCode,serialnumbers.FactoryID,serialnumbers.SerialCreationDate, CreatedBy) values(" + (serialnumber++) + ", " + AdminClass.ProductCode + ", 43, '2017/02/08'," + AdminClass.CurrentUserid + "); ", connection);
                int a = command.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                //-//Log exception 
                MessageBox.Show(ex.Message.ToString());
                return false;
             
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return true;
        }
    }

    public static class AdminClass
    {
        public static Form RefToLoginForm = null;
        public static Int32 CurrentUserid = 0;
        public static Int32 ProductCode = 0;
        public static string FactoryAppriseCode = string.Empty;
    }
}
