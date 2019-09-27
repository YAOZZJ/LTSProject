using Project.Model;
using System;
using System.Collections.ObjectModel;

namespace Project.Service
{
    public interface INLogGridViewService
    {
        void GetLogItems(Action<ObservableCollection<NLogItem>, Exception> callback);
        void Add();
    }
}
