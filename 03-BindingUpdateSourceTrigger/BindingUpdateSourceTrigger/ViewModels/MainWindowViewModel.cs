using Prism.Mvvm;

namespace BindingUpdateSourceTrigger.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "UpdateSourceTrigger example";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {
        }

        private string lostFocusText;
        public string LostFocusText
        {
            get { return lostFocusText; }
            set { SetProperty(ref lostFocusText, value); }
        }

        private string propertyChangedText;
        public string PropertyChangedText
        {
            get { return propertyChangedText; }
            set { SetProperty(ref propertyChangedText, value); }
        }

        private string explicitText;
        public string ExplicitText
        {
            get { return explicitText; }
            set { SetProperty(ref explicitText, value); }
        }

        private string defaultText;
        public string DefaultText
        {
            get { return defaultText; }
            set { SetProperty(ref defaultText, value); }
        }

    }
}
