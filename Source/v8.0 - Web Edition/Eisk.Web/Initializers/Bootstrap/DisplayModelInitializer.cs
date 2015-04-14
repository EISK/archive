using System;
using System.Web.WebPages;
namespace Eisk
{
    public class DisplayModelInitializer
    {
        public static void Init()
        {
            InsertDisplayMode("Mobile");
            InsertDisplayMode("iPhone");
            InsertDisplayMode("Tablet");
            InsertDisplayMode("AndroidTablet");
        }

        static void InsertDisplayMode(string device)
        {
            //support for specific browser
            DisplayModeProvider.Instance.Modes.Insert(0, new DefaultDisplayMode(device)
            {
                ContextCondition = (context => context.GetOverriddenUserAgent().IndexOf
                    (device, StringComparison.OrdinalIgnoreCase) >= 0)
            });
        }

        
    }
}