using GalaSoft.MvvmLight;
using Project.Control.Monitor.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Control.Monitor
{
    public class IOMonitorViewModel : ViewModelBase
    {
        public IOMonitorViewModel()
        {
            _name = "IOMonitor";
            iOGroupList = new ObservableCollection<IOGroup>();
            iOGroupList.Add(iogroup = new IOGroup("IOGroup1"));
            iogroup.IOCells.Add(iocell = new IOCell("IOCell1"));
            iogroup.IOCells.Add(iocell = new IOCell("IOCell2"));
            iogroup.IOCells.Add(iocell = new IOCell("IOCell3"));
            iogroup.IOCells.Add(iocell = new IOCell("IOCell4"));
            iOGroupList.Add(iogroup = new IOGroup("IOGroup2"));
            iogroup.IOCells.Add(iocell = new IOCell("IOCell1"));
            iogroup.IOCells.Add(iocell = new IOCell("IOCell2"));
            iogroup.IOCells.Add(iocell = new IOCell("IOCell3"));
            iogroup.IOCells.Add(iocell = new IOCell("IOCell4"));
            iOGroupList.Add(iogroup = new IOGroup("IOGroup3"));
            iogroup.IOCells.Add(iocell = new IOCell("IOCell1"));
            iogroup.IOCells.Add(iocell = new IOCell("IOCell2"));
            iogroup.IOCells.Add(iocell = new IOCell("IOCell3"));
            iogroup.IOCells.Add(iocell = new IOCell("IOCell4"));
        }
        ObservableCollection<IOGroup> iOGroupList;
        ObservableCollection<IOCell> iOCells;
        IOGroup iogroup;
        IOCell iocell;
        string _name;

        public string Name { get => _name; set => Set(ref _name, value); }
        public ObservableCollection<IOGroup> IOGroupList { get => iOGroupList; set => iOGroupList = value; }
        public ObservableCollection<IOCell> IOCells { get => iOCells; set => iOCells = value; }
    }
}
