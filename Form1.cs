using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CartonBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SldWorks swApp;

        private async void LaunchSW_Click(object sender, EventArgs e)
        {
            swApp = await LauncherSW.getApplication();
        }

        private void MacroLauncher_Click(object sender, EventArgs e)
        {
            CartonCreate pm = new CartonCreate();
            pm.parameterL = Convert.ToDouble(parameterL.Text) / 1000;
            pm.parameterH = Convert.ToDouble(parameterH.Text) / 1000;
            pm.parameterB = Convert.ToDouble(parameterB.Text) / 1000;
            pm.parameterThick = Convert.ToDouble(parameterThick.Text) / 1000;

            pm.CartonCreator();
        }
    }
}
