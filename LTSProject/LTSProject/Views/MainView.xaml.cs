using Fluent;

namespace LTSProject.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : RibbonWindow
    {
        public MainView()
        {
            InitializeComponent();
        }

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    XmlLayoutSerializer serializer = new XmlLayoutSerializer(DockManager);
        //    using (var stream = new StreamWriter("Layout.xml"))
        //    {
        //        serializer.Serialize(stream);
        //    }
        //}
    }
}
