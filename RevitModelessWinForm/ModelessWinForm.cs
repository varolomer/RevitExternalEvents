using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitModelessWinForm
{
    public partial class ModelessWinForm : System.Windows.Forms.Form
    {
        private ExternalEvent m_ExEvent;
        private BasicExternalEvent m_Handler;

        public ModelessWinForm(ExternalEvent exEvent, BasicExternalEvent handler)
        {
            InitializeComponent();
            m_ExEvent = exEvent;
            m_Handler = handler;
        }

        private void ModelessWinForm_Load(object sender, EventArgs e)
        {

        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            //Before the form is closed, everything must be disposed properly
            m_ExEvent.Dispose();
            m_ExEvent = null;
            m_Handler = null;

            //You have to call the base class
            base.OnFormClosed(e);
        }


        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_ExEvent.Raise();
        }
    }
}
