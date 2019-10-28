using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Project.Control;
using Project.Model;
using Project.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Project.ViewModel
{
    public class DebugViewModel : ViewModelBase
    {
        public DebugViewModel()
        {
            debugModel = new DebugModel();
            debugModel.PropertyChanged += DebugModel_PropertyChanged;
            Items3 = CreateData();
        }
        private DebugModel debugModel;
        public string TxtDebug1{get => debugModel.Text1;set { debugModel.Text1 = value;RaisePropertyChanged(nameof(TxtDebug1)); } }
        public string TxtDebug2{get => debugModel.Text2;set { debugModel.Text2 = value;RaisePropertyChanged(nameof(TxtDebug2)); } }
        public string TxtDebug3{get => debugModel.Text3;set { debugModel.Text3 = value;RaisePropertyChanged(nameof(TxtDebug3)); } }
        

        #region "Command"
        private RelayCommand btnDebug1Command;
        private RelayCommand btnDebug2Command;
        private RelayCommand btnDebug3Command;
        private RelayCommand btnDebug4Command;
        private RelayCommand btnDebug5Command;
        private RelayCommand btnDebug6Command;
        public RelayCommand BtnDebug1Command{get => btnDebug1Command ?? (btnDebug1Command = new RelayCommand(debugModel.Command1)); set => btnDebug1Command = value;}
        public RelayCommand BtnDebug2Command{get => btnDebug2Command ?? (btnDebug2Command = new RelayCommand(debugModel.Command2)); set => btnDebug2Command = value;}
        public RelayCommand BtnDebug3Command{get => btnDebug3Command ?? (btnDebug3Command = new RelayCommand(debugModel.Command3)); set => btnDebug3Command = value;}
        public RelayCommand BtnDebug4Command{get => btnDebug4Command ?? (btnDebug4Command = new RelayCommand(debugModel.Command4)); set => btnDebug4Command = value;}
        public RelayCommand BtnDebug5Command{get => btnDebug5Command ?? (btnDebug5Command = new RelayCommand(debugModel.Command5)); set => btnDebug5Command = value;}
        public RelayCommand BtnDebug6Command{get => btnDebug6Command ?? (btnDebug6Command = new RelayCommand(debugModel.Command6)); set => btnDebug6Command = value;}
        #endregion
        #region "Model to ViewModel"
        private void DebugModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch(e.PropertyName)
            {
                case "Text1": RaisePropertyChanged(nameof(TxtDebug1));break;
                case "Text2": RaisePropertyChanged(nameof(TxtDebug2));break;
                case "Text3": RaisePropertyChanged(nameof(TxtDebug3));break;
                default: break;
            }
        }
        #endregion

        private static ObservableCollection<SelectableViewModel> CreateData()
        {
            return new ObservableCollection<SelectableViewModel>
            {
                new SelectableViewModel
                {
                    Code = 'M',
                    Name = "Material Design",
                    Description = "Material Design in XAML Toolkit"
                },
                new SelectableViewModel
                {
                    Code = 'D',
                    Name = "Dragablz",
                    Description = "Dragablz Tab Control",
                    Food = "Fries"
                },
                new SelectableViewModel
                {
                    Code = 'P',
                    Name = "Predator",
                    Description = "If it bleeds, we can kill it"
                }
            };
        }
        public ObservableCollection<SelectableViewModel> Items3;
    }
    public class SelectableViewModel : INotifyPropertyChanged
    {
        private bool _isSelected;
        private string _name;
        private string _description;
        private char _code;
        private double _numeric;
        private string _food;

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected == value) return;
                _isSelected = value;
                OnPropertyChanged();
            }
        }

        public char Code
        {
            get { return _code; }
            set
            {
                if (_code == value) return;
                _code = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                if (_description == value) return;
                _description = value;
                OnPropertyChanged();
            }
        }

        public double Numeric
        {
            get { return _numeric; }
            set
            {
                if (_numeric == value) return;
                _numeric = value;
                OnPropertyChanged();
            }
        }

        public string Food
        {
            get { return _food; }
            set
            {
                if (_food == value) return;
                _food = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
