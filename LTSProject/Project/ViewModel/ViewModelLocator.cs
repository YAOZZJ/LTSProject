using Autofac;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
namespace Project.ViewModel
{
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            //容器builder
            ContainerBuilder builder = new ContainerBuilder();
            //IDataService映射对象
            if (ViewModelBase.IsInDesignModeStatic)
            {
                // Create design time view services and models
            }
            else
            {
                // Create run time view services and models
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<DebugViewModel>();
            //builder.RegisterType<NLogGridViewService>().As<INLogGridViewService>().SingleInstance();//单实例

            NLogGridViewContainer = builder.Build();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public DebugViewModel Debug => ServiceLocator.Current.GetInstance<DebugViewModel>();
        //public NLogGridViewViewModel NLogGridVIew => new NLogGridViewViewModel(NLogGridViewContainer.BeginLifetimeScope().Resolve<INLogGridViewService>());
        //容器接口
        private static IContainer NLogGridViewContainer { get; set; }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}