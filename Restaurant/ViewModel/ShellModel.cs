using System.ComponentModel;
using System.Runtime.CompilerServices;
using Restaurant.Model.Tables;

namespace Restaurant.ViewModel
{
    public class ShellModel : INotifyPropertyChanged
    {

        private bool isRegistered = false;

        private static string UNREGISTERED = "     Нерегистровани";
        private string fullName = UNREGISTERED;
        private int type = User.TYPE_ORDERER;
        private string userName;

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

        public string UserName
        {
            get => userName;
            set => userName = value;
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Unregister()
        {
            this.FullName = UNREGISTERED;
            this.Type = User.TYPE_ORDERER;
            this.UserName = null;
            this.IsRegistered = false;

        }
    }
}