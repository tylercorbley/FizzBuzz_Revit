#region Namespaces
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

            foreach (var i in amount)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    FizzBuzz;
                }
                else if (i % 3 == 0)
                {
                    Fizz;
                }
                else if (i % 5 == 0)
                {
                    Buzz;
                }
                else
                {
                    i;
                }
            }

            return Result.Succeeded;
        }

        public static String GetMethod()
        {
            var method = MethodBase.GetCurrentMethod().DeclaringType?.FullName;
            return method;
        }
    }
}
