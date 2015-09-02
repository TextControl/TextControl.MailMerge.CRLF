using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TXTextControl;

namespace tx_reporting_crlf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml("data.xml");

            mailMerge1.Merge(ds.Tables[0]);
        }

        private void mailMerge1_FieldMerged(object sender, TXTextControl.DocumentServer.MailMerge.FieldMergedEventArgs e)
        {
            ApplicationField field = e.MailMergeFieldAdapter.ApplicationField;
            field.Text = field.Text.Replace(@"\r\n", "\r\n");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadTemplate();
        }

        private void loadTemplate()
        {
            TXTextControl.LoadSettings ls = new LoadSettings();
            ls.ApplicationFieldFormat = ApplicationFieldFormat.MSWord;
            textControl1.Load("template.docx", StreamType.WordprocessingML, ls);

            webBrowser1.DocumentText = File.ReadAllText("data.xml");
        }

        private void reloadTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadTemplate();
        }
    }
}
