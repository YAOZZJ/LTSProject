using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Project.Model;
using Project.Service;
using System.Collections.ObjectModel;

namespace Project.ViewModel
{
    public class NLogGridViewViewModel :ViewModelBase
    {
        public NLogGridViewViewModel(INLogGridViewService nLogGridView)
        {
            gridViewService = nLogGridView;
            gridViewService.GetLogItems(
                (items,error) =>
                {
                    LogItems = items;
                });
        }
        private ObservableCollection<NLogItem> _logItems;
        private INLogGridViewService gridViewService;

        public ObservableCollection<NLogItem> LogItems { get => _logItems; set => Set(ref _logItems,value); }
        public RelayCommand Add 
        {
            get 
            {
                //if (add == null) add = new RelayCommand(gridViewService.Add);
                return add ?? (new RelayCommand(gridViewService.Add));
            } 
            set => add = value; 
        }
        #region "Command"
        private RelayCommand add;
        #endregion
    }
}
