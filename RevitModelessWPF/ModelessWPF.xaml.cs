using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitModelessWPF
{
    /// <summary>
    /// Interaction logic for ModelessWPF.xaml
    /// </summary>
    public partial class ModelessWPF : Window
    {
        private ExternalEvent m_ExEvent;
        private BasicExEventHandler m_Handler;

        private ExternalEvent m_ExEvent_CreateWalls;
        private CreateWallsExEventHandler m_Handler_CreateWalls;

        private ExternalEvent m_ExEvent_BatchWalls;
        private BatchWallsExEventHandler m_Handler_BatchWalls;

        public ModelessWPF(ExternalEvent exEvent, BasicExEventHandler handler,
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

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
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
            base.OnClosing(e);
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            m_ExEvent.Raise();
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            m_ExEvent_CreateWalls.Raise();
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            m_ExEvent_BatchWalls.Raise();
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
