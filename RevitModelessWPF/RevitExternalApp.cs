using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace RevitModelessWPF
{
    public class RevitExternalApp : IExternalApplication
    {
        //External application instance
        public static RevitExternalApp thisApp = null;

        //Form instance
        private ModelessWPF m_ModelessWinForm;

        public Result OnShutdown(UIControlledApplication application)
        {
            if(m_ModelessWinForm != null && m_ModelessWinForm.Visibility == Visibility.Visible)
            {
                m_ModelessWinForm.Close();
            }

            return Result.Succeeded;

        }

        public Result OnStartup(UIControlledApplication application)
        {
            m_ModelessWinForm = null; //The command itself bring the form later on
            thisApp = this; //Static access must be given to reach the instance everywhere   

            //Create Ribbon Tab
            application.CreateRibbonTab("ModelessWPF");
            RibbonPanel panelHelper = application.CreateRibbonPanel("ModelessWPF", "ModelessWPF");

            string path = Assembly.GetExecutingAssembly().Location;

            PushButtonData buttonModelessForm = new PushButtonData("ModelessWPFForm", "ModelessWPFForm", path, "RevitModelessWPF.RevitExternalCommand");
            BitmapImage iconModelessForm = new BitmapImage(new Uri("pack://application:,,,/RevitModelessWPF;component/Assets/iconModelessForm.png"));
            PushButton pushButton_ModelessForm = panelHelper.AddItem(buttonModelessForm) as PushButton;
            pushButton_ModelessForm.LargeImage = iconModelessForm;

            return Result.Succeeded;

        }

        public void ShowModelessWinForm(UIApplication uiapp)
        {
            //If there is no UI instance yet, initialize and instance and show it
            //var presSource_Window = PresentationSource.FromVisual(m_ModelessWinForm);
            if (m_ModelessWinForm == null || PresentationSource.FromVisual(m_ModelessWinForm) == null)
            {
                //Create a new event handler to handle the request that will be sent from UI (ExternalEvent.Raise())
                BasicExEventHandler handler = new BasicExEventHandler();
                CreateWallsExEventHandler handler_CreateWalls = new CreateWallsExEventHandler();
                BatchWallsExEventHandler handler_BatchWalls = new BatchWallsExEventHandler();


                //Initialize an External Event to pass it to the UI
                ExternalEvent exEvent = ExternalEvent.Create(handler);
                ExternalEvent exEvent_CreateWalls = ExternalEvent.Create(handler_CreateWalls);
                ExternalEvent exEvent_BatchWalls = ExternalEvent.Create(handler_BatchWalls);


                //Pass the instances to UI -- It is extremely important that UI is in charge of disposing these objects while closing
                m_ModelessWinForm = new ModelessWPF(exEvent, handler, 
                    exEvent_CreateWalls, handler_CreateWalls, 
                    exEvent_BatchWalls, handler_BatchWalls);

                m_ModelessWinForm.Show();
            }
        }


    }
}
