using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Configuration;
using System.Text.RegularExpressions;

namespace SQLOperation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            DataTypes();
            pnlTable.Visible = false;

            txtlength1.Visible = false;
            txtlength2.Visible = false;


            cmbDatatype.ValueMember = "id";
            cmbDatatype.DisplayMember = "datatype";
            cmbDatatype.DataSource = DataTypes().Tables[0];

        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pnlTable.Visible = true;
        }


        //private void cmbDatatype_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string typeArray = System.Configuration.ConfigurationManager.AppSettings["chartype1"];
        //    string[] type = typeArray.Split(',');
        //    string value = cmbDatatype.SelectedText;

        //    if (type.Contains(value))
        //  {
        //      txtlength1.Visible = true;
        //  }
        //}


        public DataSet DataTypes()
        {
            string fileName = System.Configuration.ConfigurationManager.AppSettings["DataTypeXmlFilepth"];
            XmlReader xmlFile;
            xmlFile = XmlReader.Create(fileName, new XmlReaderSettings());
            DataSet ds = new DataSet();
            ds.ReadXml(xmlFile);
            return ds;
        }

        private void cmbDatatype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string typeArray1 = System.Configuration.ConfigurationManager.AppSettings["chartype1"];
            string typeArray2 = System.Configuration.ConfigurationManager.AppSettings["chartype2"];
            string[] type1 = typeArray1.Split(',');
            string[] type2 = typeArray1.Split(',');
            string value = Regex.Replace(cmbDatatype.SelectedValue.ToString(), @"\t|\n|\r", ""); ;
          

            if (type1.Contains(value.Trim(' ')))
            {
                txtlength1.Visible = true;
            }
            else
            {
                txtlength1.Visible = false;
            }

            if (type2.Contains(value.Trim(' ')))
            {
                txtlength1.Visible = true;
                txtlength2.Visible = true;
            }
            else
            {
                txtlength1.Visible = true;
                txtlength2.Visible = false;
            }
        }
    }
}
