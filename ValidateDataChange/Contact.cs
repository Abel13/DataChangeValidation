using System.ComponentModel;

namespace ValidateDataChange
{
    internal class Contact : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string info)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged("Name"); }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; NotifyPropertyChanged("Email"); }
        }
        private string facebook;
        public string Facebook
        {
            get { return facebook; }
            set { facebook = value; NotifyPropertyChanged("Facebook"); }
        }

        public Contact(string name, string email, string facebook)
        {
            this.name = name;
            this.email = email;
            this.facebook = facebook;
        }

        public override int GetHashCode()
        {
            return (name+email+facebook).GetHashCode();
        }

    }
}