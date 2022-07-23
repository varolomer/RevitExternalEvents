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
        private BasicExEventHandler m_Handler;

        private ExternalEvent m_ExEvent_CreateWalls;
        private CreateWallsExEventHandler m_Handler_CreateWalls;

        private ExternalEvent m_ExEvent_BatchWalls;
        private BatchWallsExEventHandler m_Handler_BatchWalls;

        public ModelessWinForm(ExternalEvent exEvent, BasicExEventHandler handler, 
            ExternalEvent exEvent_CreateWalls, CreateWallsExEventHandler handler_CreateWalls,
            ExternalEvent exEvent_BatchWalls, BatchWallsExEventHandler handler_BatchWalls)
        {
            InitializeComponent();

            m_ExEvent = exEvent;
            m_Handler = handler;

            m_ExEvent_CreateWalls = exEvent_CreateWalls;
            m_Handler_CreateWalls = handler_CreateWalls;

            m_ExEvent_BatchWalls = exEvent_BatchWalls;
            m_Handler_BatchWalls = handler_BatchWalls;
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

            m_ExEvent_CreateWalls.Dispose();
            m_ExEvent_CreateWalls = null;
            m_Handler_CreateWalls = null;

            m_ExEvent_BatchWalls.Dispose();
            m_ExEvent_BatchWalls = null;
            m_Handler_BatchWalls = null;

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

        private void button2_Click(object sender, EventArgs e)
        {
            m_ExEvent_CreateWalls.Raise();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            m_ExEvent_BatchWalls.Raise();

        }
    }
}
