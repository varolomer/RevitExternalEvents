using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace RevitModelessWinForm
{
    public class BatchWallsExEventHandler : IExternalEventHandler
    {
        public void Execute(UIApplication app)
        {
            //Get the document
            Document doc = app.ActiveUIDocument.Document;

            //Collect a wall type
            WallType wallType = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Walls)
                .WhereElementIsElementType()
                .Cast<WallType>()
                .FirstOrDefault();

            //Get a level
            Level level = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType()
                .Cast<Level>()
                .FirstOrDefault();

            //Make sure the wall type is not null
            if (wallType == null) throw new Exception("No wall type");

            //Create a random instance
            Random random = new Random();

            //Define a bound
            int bound = (int)UnitUtils.ConvertToInternalUnits(15, UnitTypeId.Meters);

            for(int i = 0; i < 100; i++)
            {
                //Get some random points within bound
                XYZ p1 = new XYZ(random.Next(0, bound), random.Next(0, bound), 0);
                XYZ p2 = new XYZ(random.Next(0, bound), random.Next(0, bound), 0);

                //Create a line
                Line line = Line.CreateBound(p1, p2);

                //Create the wall
                using (Transaction trans = new Transaction(doc, $"Create Wall-{i.ToString()}"))
                {
                    trans.Start();
                    Wall.Create(doc, line, level.Id, false);
                    trans.Commit();
                }
            }

        }

        public string GetName()
        {
            return "Batch Walls ExternalEventHandler";
        }
    }
}
