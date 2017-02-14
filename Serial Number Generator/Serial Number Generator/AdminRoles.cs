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
         - Get todays' date + product code + month + year + factory code + serial number
         - Check all the variables and their daa type and match with the database schema
         - Check for all message boxes and write to logs.


TESTING  - if max serial numbers are created this month or not.
        
TOMORROW - if serial already exist     

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
                MySqlCommand command = new MySqlCommand("select FactoryID from factoryids where AppriseCodes != '';", connection);
                myreader = command.ExecuteReader();
                if (myreader.HasRows)
                {
                    FactoryIDComboBox.Text = "Select Factory ID";
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
            //try
            //{
            //    if (GetFormData())
            //    {
            //        string lastserialnumberquery = "SELECT SerialNumber FROM serialnumbers where ProductCode=" + AdminClass.ProductCode + " Order by serialNumberID desc limit 1;";
            //        Int64 serialnumberreturned = GetSerialNumberQuery(lastserialnumberquery);

            //        //Length is 13. Not first time serial number for this product code
            //        if (serialnumberreturned.ToString().Length == Constants.SERIAL_NUMBER_LENTH)
            //        {
            //            //check the serial as per business reqs before incrementing and inserting into db.
            //            //parse the returned serial number and get the serial number, month and product code.
            //            //string s_fc = (serialnumberreturned.ToString()).Substring(0, 2);

            //            //check the above serial number , so that it should not exist in db and incremenet it and insert it in db
            //            //if month is different then increment uncless its MAXIMUM_SERIAL_NUMBER_LIMIT then 00001

            //            string last_serial_number_created = (serialnumberreturned.ToString()).Substring(8, 5); 
            //            string last_serial_number_created_month = (serialnumberreturned.ToString()).Substring(4, 5);
            //            string last_serial_number_created_year = (serialnumberreturned.ToString()).Substring(2, 2);
            //            int sn = 0;      
                                         
            //            //increment the serial number
            //            Int32.TryParse(last_serial_number_created, out sn);
            //            //99999
            //            if(sn < Constants.MAXIMUM_SERIAL_NUMBER_LIMIT)
            //            {
                            
                            
                            
                                                 
            //                //for every increment check if the limit has been reached.

            //                string count_serialnumbers_in_same_month_year_query = "SELECT count(SerialNumber) as total FROM zeronext.serialnumbers where ProductCode = " + AdminClass.ProductCode + " and year( SerialCreationDate ) = " + DateTime.Today.Year + " and month(SerialCreationDate) = " + DateTime.Today.Month + ";";
            //                int count_serialnumbers_in_same_month_year = CountSerialNumbersInMonth(count_serialnumbers_in_same_month_year_query);

            //                if (count_serialnumbers_in_same_month_year > 0)
            //                {
            //                    if (count_serialnumbers_in_same_month_year <= Constants.MAXIMUM_SERIAL_NUMBER_LIMIT)
            //                    {

            //                    }
            //                    else
            //                    {
            //                        MessageBox.Show("Maximum Limit (99999) within a month reached.");
            //                    }
            //                }





            //                sn++;
            //                //insert the new serial number
            //                FormatSerialNumber(sn);
            //            }
            //            else if( sn>= Constants.MAXIMUM_SERIAL_NUMBER_LIMIT )
            //            {
            //                //check the last serial month+year and today month+year, if same then get first row of the same month, other wise start from 00001

            //                //same month and year
            //                if (last_serial_number_created_month == DateTime.Today.Month.ToString("00") && last_serial_number_created_year == DateTime.Today.Year.ToString("yyyy"))
            //                {
            //                    //get first row created in that product category in that month.
            //                    string first_serial_number_query = "SELECT SerialNumber FROM serialnumbers where ProductCode=" + AdminClass.ProductCode + " Order by serialNumberID asc limit 1;";
            //                    Int64 first_serial_number_returned = GetSerialNumberQuery(first_serial_number_query);

            //                    //string s_year = (first_serial_number_returned.ToString()).Substring(2, 2);
            //                    //string s_month = (first_serial_number_returned.ToString()).Substring(4, 2);
            //                    //string s_pc = (first_serial_number_returned.ToString()).Substring(6, 2);
            //                    string first_serial_number_created = (first_serial_number_returned.ToString()).Substring(8, 5);

                                

            //                    //increment till first serial number, if greater then show an error message you reached a limit

            //                    //show an error message to check if 99999 serial numbers are generated this month
            //                }
            //                //different month, start from 00001
            //                else
            //                {
            //                    //then start from beginnning
            //                }
            //            }
            //        }
            //        //first time serial number for this product code 
            //        else
            //        {
            //            //first serial number for this product code
            //            //create first time serial number for this category
            //            FormatSerialNumber(1);
            //        }
                    
            //    }
            //}catch(Exception ex)
            //{
            //    MessageBox.Show("Error in creating serial number.");
            //}
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
                    Int32.TryParse(FactoryIDComboBox.SelectedItem.ToString(), out AdminClass.FactoryID);
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


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static Int64 GetSerialNumberQuery(string query)
        {
            //get last serial number created in a product category

            Int64 serial_number_of_productcategory = 0;

            //get last serial number of each product category
            MySqlConnection connection = null;
            try
            {
                MySqlDataReader myreader = null;
                connection = new MySqlConnection("Server=localhost;Database=zeronext;UID=root;Password=admin");
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);

                myreader = command.ExecuteReader();
                if (myreader.HasRows)
                {
                    while (myreader.Read())
                    {
                        serial_number_of_productcategory = myreader.GetInt64(0);
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
            return serial_number_of_productcategory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sn"></param>
        private void FormatSerialNumber( int sn)
        {
            string serial_number = "";
            Int64 snumber = 0;

            serial_number += AdminClass.FactoryID;

            int year = DateTime.Today.Year % 100;
            serial_number += year.ToString();

            string smonth = DateTime.Today.Month.ToString("00");
            serial_number += smonth.ToString();

            serial_number += AdminClass.ProductCode;

            string ssn = sn.ToString("00000");
            serial_number += ssn;


            Int64.TryParse(serial_number, out snumber);

            SerialNumberCreatedLabel.Text = snumber.ToString();

            //pass product code , month , year, factory code and serial number
            string query = "INSERT INTO serialnumbers (serialnumbers.SerialNumber,serialnumbers.ProductCode,serialnumbers.FactoryID,serialnumbers.SerialCreationDate, CreatedBy) values(" + (snumber) + ", " + AdminClass.ProductCode + "," + AdminClass.FactoryID + ",'" + DateTime.Today.ToString("yyyy-MM-dd") + "'," + AdminClass.CurrentUserid + "); ";
            InsertSerialNumber(query);
        }

        private bool InsertSerialNumber(string query)
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=zeronext;UID=root;Password=admin");
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private int CountSerialNumbersInMonth(string query)
        {
            MySqlConnection connection = null;
            int number_of_rows = 0;
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=zeronext;UID=root;Password=admin");
                connection.Open();

                MySqlCommand command = new MySqlCommand(query, connection);

                object result = null;
                result = command.ExecuteScalar();
                if (result != null)
                {
                    number_of_rows = Convert.ToInt32(result);                   
                }
                else
                {
                    MessageBox.Show("Cannot count the number of serial numbers.");
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
            return number_of_rows;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Create_Click(object sender, EventArgs e)
        {
            int last_serial_number = 0;
            string last_serial_number_created_factory_id = string.Empty;
            string last_serial_number_created_year = string.Empty;
            string last_serial_number_created_month = string.Empty;
            string last_serial_number_created = string.Empty;


            Int64 new_serial_number = 0;
            string create_new_serial_number = string.Empty;
            try
            {
                if (GetFormData())
                {
                    string lastserialnumberquery = "SELECT SerialNumber FROM serialnumbers where ProductCode=" + AdminClass.ProductCode + " Order by serialNumberID desc limit 1;";
                    Int64 serialnumberreturned = GetSerialNumberQuery(lastserialnumberquery);

                    //Length is 13. Not first time serial number for this product code
                    if (serialnumberreturned.ToString().Length == Constants.SERIAL_NUMBER_LENTH)
                    {
                        //last_serial_number_created_factory_id = (serialnumberreturned.ToString()).Substring(0, 2);
                        //last_serial_number_created_year = (serialnumberreturned.ToString()).Substring(2, 2);
                        //last_serial_number_created_month = (serialnumberreturned.ToString()).Substring(4, 2);
                        last_serial_number_created = (serialnumberreturned.ToString()).Substring(8, 5);                        
                        Int32.TryParse(last_serial_number_created, out last_serial_number);

                        //increment the serial number
                        if(last_serial_number<Constants.MAXIMUM_SERIAL_NUMBER_LIMIT)
                        {
                            //then increment
                            //serialnumberreturned++;
                            create_new_serial_number += AdminClass.FactoryID;
                            create_new_serial_number += DateTime.Today.Year % 100;
                            create_new_serial_number += DateTime.Today.Month.ToString("00");
                            create_new_serial_number += AdminClass.ProductCode;
                            create_new_serial_number += (last_serial_number + 1).ToString("00000");
                            Int64.TryParse(create_new_serial_number, out new_serial_number);
                            if (CheckNewSerialNumber(new_serial_number) ==0)
                            {
                                FormatSerialNumber(last_serial_number+1);
                            }
                            else
                            {
                                MessageBox.Show("Serial Number already exists");
                                //Check if max limit has been reached for a product category in a month
                                string count_serialnumbers_in_same_month_year_factoryID_query = "SELECT count(SerialNumber) as total FROM zeronext.serialnumbers where ProductCode = " + AdminClass.ProductCode + " and FactoryID= "  + AdminClass.FactoryID + " and year( SerialCreationDate ) = " + DateTime.Today.Year + " and month(SerialCreationDate) = " + DateTime.Today.Month + ";";
                                int count_serialnumbers_in_same_month_year_factoryID = CountSerialNumbersInMonth(count_serialnumbers_in_same_month_year_factoryID_query);
                                if(count_serialnumbers_in_same_month_year_factoryID>=Constants.MAXIMUM_SERIAL_NUMBER_LIMIT)
                                {
                                    MessageBox.Show("99,999 Serial Numbers have already been created for product category : " + AdminClass.ProductCode + " at FactoryID : " + AdminClass.FactoryID + " in " + DateTime.Today.ToString("yyyy-MM") +"(yyyy-mm)." );
                                }
                            }
                        }
                        else if(last_serial_number >= Constants.MAXIMUM_SERIAL_NUMBER_LIMIT)
                        {
                            //start from 0 for this month.
                            create_new_serial_number += AdminClass.FactoryID;
                            create_new_serial_number += DateTime.Today.Year % 100;
                            create_new_serial_number += DateTime.Today.Month.ToString("00");
                            create_new_serial_number += AdminClass.ProductCode;
                            create_new_serial_number += 1.ToString("00000");
                            Int64.TryParse(create_new_serial_number, out new_serial_number);
                            if (CheckNewSerialNumber(new_serial_number)==0)
                            {
                                FormatSerialNumber(1);
                            }
                            else
                            {
                                MessageBox.Show("Serial Number already exists");
                            }
                        }                                               
                    }
                    else
                    {
                        //first serial number for this product code
                        //create first time serial number for this category
                        FormatSerialNumber(1);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in creating serial number.");
            }
        }


        private static int CheckNewSerialNumber(Int64 serialnumber)
        {
            MySqlConnection connection = null;
            try
            {
                connection = new MySqlConnection("Server=localhost;Database=zeronext;UID=root;Password=admin");
                connection.Open();

                MySqlCommand command = new MySqlCommand("SELECT count(SerialNumber) as totalrows FROM zeronext.serialnumbers where SerialNumber = " + serialnumber + ";", connection);

                object result = null;
                result = command.ExecuteScalar();
                if (result != null)
                {
                    return Convert.ToInt32( result);
                }
            }
            catch (MySqlException ex)
            {
                //-//Log exception 
                MessageBox.Show(ex.Message.ToString());
                return -1;
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
            return 0;
        }


        void run99999serials()
        {
            int i = 0;
            while(i<1000000)
            {
                Create.PerformClick();
                i++;
            }
        }

        private void PrintLabelBtn_Click(object sender, EventArgs e)
        {
            run99999serials();
        }
    }

    public static class AdminClass
    {
        public static Form RefToLoginForm = null;
        public static Int32 CurrentUserid = 0;
        public static Int32 ProductCode = 0;
        public static Int32 FactoryID = 0;
    }
}
