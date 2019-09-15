using Caliburn.Micro;
using LTSProject.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LTSProject
{
    public class Bootstrapper : BootstrapperBase
    {
        #region Constructor
        public Bootstrapper()
        {
            Initialize();
        }
        #endregion

        #region Overrides
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            // DisplayRootViewFor<IShell>();
             DisplayRootViewFor<MainViewModel>();
        }
        #endregion
    }
}
