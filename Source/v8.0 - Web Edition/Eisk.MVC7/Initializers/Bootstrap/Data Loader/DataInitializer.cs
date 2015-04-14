using System.Web;
namespace Eisk
{
    public partial class DataInitializer
    {
        public static void Init()
        {
            if (HttpContext.Current.IsDebuggingEnabled)
                TestDataHelper.InitializeSchemaAndData(HttpContext.Current.Server.MapPath("~/App_Data/TestData.xml"));
        }
    }
}