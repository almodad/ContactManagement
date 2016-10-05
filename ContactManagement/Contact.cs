using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ContactManagement
{
    public class Contact : INotifyPropertyChanged
    {   
        private string _name;
        public string Name {
            get { return _name; }
            set {
                this.SetProperty(ref this._name, value);
            }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                this.SetProperty(ref this._email, value);
            }
        }
        private string _phone_number;
        public string PhoneNumber
        {
            get { return _phone_number; }
            set
            {
                this.SetProperty(ref this._phone_number, value);
            }
        }
        private string _photo;
        public string Photo
        {
            get { return _photo; }
            set
            {
                this.SetProperty(ref this._photo, value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] String propertyName = null)

        {

            if (object.Equals(storage, value)) return false;

            storage = value;

            this.OnPropertyChanged(propertyName);

            return true;

        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)

        {

            var eventHandler = this.PropertyChanged;

            if (eventHandler != null)

                eventHandler(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
