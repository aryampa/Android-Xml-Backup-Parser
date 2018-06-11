using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Spire.Doc;
using System.Xml;

namespace Android_XML_SMS_BACKUP_PARSER
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        string textblock = "";
        List<string> fileLines = new List<string> { };

        struct smsStructure {
            public string Date;
            public string address;
            public string contactName;
            public string Sent_Recieved;
            public string openStatus;
            public string ServiceCenterNumber;
            public string Message;
        }

        enum openStatus { 
            Opened,
            Not_Opened,
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnParse.Enabled = false;
            tbxParsePrev.Enabled = false;
            btnCreate.Enabled = true;
            lblStats.Text = "";
            
        }

        private void btnLoadXML_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openXmlFile = new OpenFileDialog();
                openXmlFile.Filter = "XML File (*.XML)|*.xml";
                openXmlFile.Title = "Open SMS XML FILE";
                openXmlFile.ShowDialog();

                if (openXmlFile.FileName != "")
                {
                    StringBuilder sb = new StringBuilder();
                    StreamReader sReader = new StreamReader(openXmlFile.FileName, true);

                    string fileLine = sReader.ReadLine();
                    while (fileLine != null) {

                        fileLine =  fileLine.TrimStart(new char[] {'\t' });
                        fileLines.Add(fileLine);
                        fileLine = sReader.ReadLine();
                    }

                    for (int i = 0; i < fileLines.Count; i++) { 
                        sb .AppendLine(fileLines[i]);
                    }


                    tbxPrevXml .Text = sb.ToString();
                   // sb.AppendLine("Total Bytes: " + sReader.CurrentEncoding.GetByteCount(readString.ToCharArray()));
                    
                    //textblock = tbxPrevXml.Text;

                    if (fileLines.Count  > 0)
                    {
                        btnParse.Enabled = true;
                    }
                    else btnParse.Enabled = false;
                }
                else { throw new Exception("No File Selected!!!"); }
            }

            catch (Exception ex) {
                MessageBox.Show("Error Openning XML File: " + ex.Message.ToString());
            }
        }

        private void btnParse_Click(object sender, EventArgs e)
        {
            List<smsStructure> smsStructList = new List<smsStructure>();

            try
            {

                if (fileLines[0][0] == '<' & fileLines[0][fileLines[0].Length - 1] == '>')
                {
                    if (!fileLines[0] .Contains("?xml")) throw new Exception("Invalid XML formating: ?xml attribute not found in root tag!");

                }
                else throw new Exception("Invalid XML formating: Check root Tag");

                for (int i = 2; i < fileLines.Count ; i++)
                {
                    string line2process = fileLines[i].TrimStart(new char[] {'<' });
                    line2process = line2process.TrimEnd(new char[] {'>' });

                    if(line2process.StartsWith("sms")){
                        line2process = line2process.Remove(0, "sms ".Length);
                    }
                    else if (line2process.StartsWith("allsms")) {
                        line2process = line2process.Remove(0, "allsms ".Length);
                       // MessageBox.Show("allsms"); 
                    }
                    //line2process = line2process.StartsWith("sms")

                    smsStructure smsItem = parseSMSbody(line2process);

                    if (smsItem.address != null) {
                        smsStructList.Add(smsItem);
                    }

                }

                MessageBox.Show(smsStructList.Count.ToString());

                StringBuilder sbFinal = new StringBuilder();

                Dictionary<string, List<smsStructure>> sms_groupingDictionary = new Dictionary<string, List<smsStructure>> { };

                foreach (smsStructure sms_in_list in smsStructList) {

                    if (sms_groupingDictionary.Keys.Contains(sms_in_list.address))
                    {

                        sms_groupingDictionary[sms_in_list.address].Add(sms_in_list);

                    }

                    else {
                        sms_groupingDictionary.Add(sms_in_list.address, new List<smsStructure> {sms_in_list});
                    }


                }

                foreach (string keys in sms_groupingDictionary.Keys) {
                    List<smsStructure> smsList = sms_groupingDictionary[keys];
                    

                    sbFinal.AppendLine("__________ Conversations With:  "+keys+" ["+smsList[0].contactName +"] ____________________");
                    
                    foreach (smsStructure smsFinalItem in smsList) {

                        sbFinal.AppendLine("- - - - - - - - - - - - - - - - - - - - ");
                        sbFinal.AppendLine("Date: " + smsFinalItem.Date);
                        sbFinal.AppendLine("Type: " + smsFinalItem.Sent_Recieved);
                        sbFinal.AppendLine("Service Center Number: " + smsFinalItem.ServiceCenterNumber);
                        sbFinal.AppendLine("Message:.---- ");
                        sbFinal.AppendLine(smsFinalItem.Message);
                    }

                    sbFinal.AppendLine("");
                }

               
                if (smsStructList.Count > 0) tbxParsePrev.Enabled = true;
                else tbxParsePrev.Enabled = false;

                tbxParsePrev.Text = sbFinal.ToString();

       
            }

            catch (Exception ex) {
                MessageBox.Show("Error Parsing XML String: " + ex.Message.ToString ());
            }


            


        }

        private string HumanReadable(string time) {

            double   millssss = double .Parse(time);

            DateTime startTimes = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            TimeSpan timedd = TimeSpan.FromMilliseconds(millssss);

           return startTimes.AddMilliseconds(millssss ).ToLongDateString(); 
        }

        private smsStructure parseSMSbody(string rawSMS_string)
        {
            smsStructure smsObj = new smsStructure();
            int quoteCounter = 0;
            bool OpenQuoteSeen = false ;
            bool CloseQuoteseen = false ;
            string dataString = "";
            for (int j = 0; j < rawSMS_string.Length; j++) {

                char currentChar = rawSMS_string[j];
                if (rawSMS_string[j] == '"' & quoteCounter == 0) { OpenQuoteSeen = true; }
                if (rawSMS_string[j] == '"' & quoteCounter == 1) CloseQuoteseen = true;

                if (OpenQuoteSeen & quoteCounter == 0) quoteCounter++;

                if (OpenQuoteSeen & CloseQuoteseen)
                {
                    dataString = dataString + rawSMS_string[j].ToString();
                    string[] attr_Val_array = dataString.Split(new char[] { '=' });
                    if (attr_Val_array.Length != 2) { 

                        if(attr_Val_array .Length <2){
                            throw new Exception("Invalid attribute-value pair on string [" + dataString + "] in  line: " + rawSMS_string);
                        }

                        if (attr_Val_array.Length > 2) {
                            string temp_str  = "";
                            for (int k = 1; k < attr_Val_array.Length; k++) {
                                temp_str = temp_str + attr_Val_array[k];
                            }

                            attr_Val_array[1] = temp_str;
                        }

                        
                    }
                    else
                    {
                        
                        if (attr_Val_array[0].Trim().ToLower() == "date") {
                            string newData = attr_Val_array[1].TrimStart(new char[] {'"' });
                            newData = newData.TrimEnd(new char[] {'"' });
                            smsObj.Date = HumanReadable(newData);
                        }
                        if (attr_Val_array[0].Trim().ToLower() == "address") smsObj.address = attr_Val_array[1];

                        if (attr_Val_array[0].Trim().ToLower() == "type") {
                            string newType = attr_Val_array[1].TrimEnd(new char[] {'"'});
                            newType = newType.TrimStart(new char[] {'"' });

                            if (newType == "1") smsObj.Sent_Recieved = "Received";
                            else if (newType == "2") smsObj.Sent_Recieved = "Sent";
                        }

                        if (attr_Val_array[0].Trim().ToLower() == "body") smsObj.Message = attr_Val_array[1];
                        if (attr_Val_array[0].Trim().ToLower() == "read") smsObj.openStatus = attr_Val_array[1];
                        if (attr_Val_array[0].Trim().ToLower() == "service_center") smsObj.ServiceCenterNumber = attr_Val_array[1];
                        if (attr_Val_array[0].Trim().ToLower() == "name") smsObj.contactName = attr_Val_array[1];

                        OpenQuoteSeen = false;
                        CloseQuoteseen = false;
                        quoteCounter = 0;
                        dataString = "";
                    }



                }
                else {
                    dataString = dataString + rawSMS_string[j].ToString();
                }
            }
            
            return smsObj;

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            FileStream sStream = new FileStream("SMS_OUT.txt", FileMode.CreateNew);
            StreamWriter smsWriter = new StreamWriter(sStream);

            smsWriter.Write(tbxParsePrev.Text);


            smsWriter.Close();

            MessageBox.Show("dONE!!");

            
        }
    }
}
