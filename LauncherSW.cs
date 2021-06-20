using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartonBox
{
    class LauncherSW
    {
        private static SldWorks swApp;

        private LauncherSW()
        {

        }

        internal async static Task<SldWorks> getApplication()
        {
            if (swApp == null)
            {
                return await Task<SldWorks>.Run(() =>
                {
                    swApp = Activator.CreateInstance(Type.GetTypeFromProgID("Sldworks.Application")) as SldWorks;
                    swApp.Visible = true;
                    return swApp;
                });
            }
            return swApp;
        }

        internal static void Dipose()
        {
            if (swApp != null)
            {
                swApp.ExitApp();
                swApp = null;
            }
        }
    }
}