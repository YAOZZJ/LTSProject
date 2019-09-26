using Fluent;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Project.View
{
    public partial class MainView : RibbonWindow
    {
        public Collection<NLogItem> LogItems { get; set; }
        private void BtnDebug1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //if (LogItems == null)
            //{
            //    LogItems = new Collection<NLogItem>();
            //}
            //LogItems.Add(new NLogItem { CallSite = "CallSite", Exception = "Excetion", Level = "Level", Logger = "Logger", Message = "Message", MessageID = 16, Source = "Source" });
        }

        private void BtnDebug2_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            //if (GridViewDeubg.DataContext != null) GridViewDeubg.DataContext = null;
            //GridViewDeubg.DataContext = LogItems;
        }

        private void BtnDebug3_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            
        }

        private void BtnDebug4_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

        private void BtnDebug5_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
        private void BtnDebug6_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }

    }
}
