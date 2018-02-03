using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Restaurant.Model.Tables;

namespace Restaurant
{
    public class ShellModel : INotifyPropertyChanged
    {

        private bool isRegistered = false;

        private string fullName = "     Нерегистровани";
        private int type = User.TYPE_ORDERER;

        public string FullName
        {
            get => fullName;
            set { fullName = value; this.OnPropertyChanged();}
        }

        public int Type
        {
            get => type;
            set { type = value; this.OnPropertyChanged();}
        }

        public bool IsRegistered
        {
            get { return isRegistered; }
            set {
                    this.isRegistered = value;
                    this.OnPropertyChanged();    
                }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}