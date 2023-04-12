#region Namespaces
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Reflection;

#endregion

namespace FizzBuzz_Revit
{
    [Transaction(TransactionMode.Manual)]
    public class Module01Challenge : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // this is a variable for the Revit application
            UIApplication uiapp = commandData.Application;

            // this is a variable for the current Revit model
            Document doc = uiapp.ActiveUIDocument.Document;

            // Your code goes here
            var amount = 250;

            //FizzBuzz Formula
            for (int i = 0; i < amount; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    //FizzBuzz;
                }
                else if (i % 3 == 0)
                {
                    //Fizz;
                }
                else if (i % 5 == 0)
                {
                    //Buzz;
                }
                else
                {
                    //i;
                }
            }

            //create a transaction
            Transaction t = new Transaction(doc);
            t.Start("Doing something in Revit");

            //create a level
            Level newLevel = Level.Create(doc, 10);
            newLevel.Name = "My new level";

            //create a plan
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            collector1.OfClass(typeof(ViewFamilyType));

            ViewFamilyType floorPlanVFT = null;
            foreach (ViewFamilyType curVFT in collector1)
            {
                if (curVFT.ViewFamily == ViewFamily.FloorPlan)
                {
                    floorPlanVFT = curVFT;
                    break;
                }
            }
            ViewPlan newPlan = ViewPlan.Create(doc, floorPlanVFT.Id, newLevel.Id);
            newPlan.Name = "my new floor plan";
            //create a sheet
            FilteredElementCollector collector2 = new FilteredElementCollector(doc);
            collector2.OfCategory(BuiltInCategory.OST_TitleBlocks);

            ViewSheet newSheet = ViewSheet.Create(doc, collector2.FirstElement().Id);
            newSheet.Name = "My New Sheet";
            newSheet.SheetNumber = "A103";

            //add view to sheet; create a viewport object
            XYZ insPoint = new XYZ(1, 0.5, 0); //create a point
            Viewport newViewport = Viewport.Create(doc, newSheet.Id, newPlan.Id, insPoint);



            //finish  transaction
            t.Commit();
            t.Dispose();

            return Result.Succeeded;
        }

        public static String GetMethod()
        {
            var method = MethodBase.GetCurrentMethod().DeclaringType?.FullName;
            return method;
        }
    }
}
