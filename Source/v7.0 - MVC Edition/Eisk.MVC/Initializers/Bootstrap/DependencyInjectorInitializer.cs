using Eisk.Helpers;
using System.Diagnostics.CodeAnalysis;
namespace Eisk
{
    public partial class DependencyInjectorInitializer
    {
        [SuppressMessage("Microsoft.Reliability",
          "CA2000:Dispose objects before losing scope",
          Justification = "This should survive the lifetime of the application.")]
        public static void Init()
        {
            DependencyHelper.Initialize();
        }
    }
}