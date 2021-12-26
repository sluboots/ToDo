using Xamarin.Forms;
using ToDo.ViewModels;


namespace ToDo.Models
{
    public class Task : BindableObject
    {
        private string _descr;
        public string Descr
        {
            get => _descr;
            set
            {
                _descr = value;
                OnPropertyChanged(nameof(Descr));
            }
        }

        private bool _checkready;
        public bool CheckReady
        {
            get => _checkready;
            set
            {
                _checkready = value;
                OnPropertyChanged(nameof(CheckReady));
            }
        }
    }
}
