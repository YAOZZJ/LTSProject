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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Project.Control.Others
{
    /// <summary>
    /// Color.xaml 的交互逻辑
    /// </summary>
    public partial class Color : UserControl
    {
        public Color()
        {
            InitializeComponent();
            this.ColorSelector = new ObservableCollection<ColorSelect>();
            var properties = typeof(Colors).GetProperties();
            foreach (System.Reflection.PropertyInfo info in properties)
            {
                ColorSelector.Add(new ColorSelect { Color = info.Name, Name = info.Name });

            }
            ListView1.ItemsSource = ColorSelector;
        }
        public ObservableCollection<ColorSelect> ColorSelector { get; set; }
    }
    public class ColorSelect
    {
        public String Color { get; set; }
        public String Name { get; set; }
    }
}
