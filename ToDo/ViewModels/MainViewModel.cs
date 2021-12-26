using Newtonsoft.Json;
using System.Collections.ObjectModel;
using Xamarin.Essentials;
using Xamarin.Forms;
using List = ToDo.Models.Task;

namespace ToDo.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private readonly MainPage _page;

        public MainViewModel(ContentPage page)
        {
            _page = (MainPage)page;
        }

        private Command _AddCollection;
        public Command AddCollection => _AddCollection ?? (_AddCollection = new Command(() =>
        {
            if (ToDoName.Length != 0)
            {
                TodoCollection.Insert(0, new List() { Descr = ToDoName, CheckReady = false });
                ToDoName = "";
            }
        }));

        private Command _DeleteCollection;
        public Command DeleteCollection => _DeleteCollection ?? (_DeleteCollection = new Command<List>(item =>
        {
            TodoCollection.Remove(item);


        }));

        private ObservableCollection<List> _todoCollection { get; set; }

        public ObservableCollection<List> TodoCollection
        {
            get => _todoCollection;
            set
            {
                _todoCollection = value;
                OnPropertyChanged(nameof(TodoCollection));
            }
        }

        private string _ToDoName { get; set; }

        public string ToDoName
        {
            get => _ToDoName;
            set
            {
                _ToDoName = value;
                OnPropertyChanged(nameof(ToDoName));
            }
        }

        public void SaveJSON()
        {
            Preferences.Set("Todo", JsonConvert.SerializeObject(TodoCollection));
        }

        public void LoadJSON()
        {
            var itemJson = Preferences.Get("Todo", "[]");
            TodoCollection = JsonConvert.DeserializeObject<ObservableCollection<List>>(itemJson);
        }
    }
}
