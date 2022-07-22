using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;


namespace RevitModelessWinForm
{
    public class BasicExternalEvent : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {

            Document doc = app.ActiveUIDocument.Document;

            var elements = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Walls)
                .WhereElementIsNotElementType()
                .ToList();
            
            TaskDialog.Show("Basic External Event", $"{elements.Count.ToString()} wall instances exist in the documents.");
        }

        public string GetName()
        {
            return "Basic External Event";
        }
    }
}
