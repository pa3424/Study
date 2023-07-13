using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace BindingUpdateSourceTrigger.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {

        public ICommand ChangeTextCommand { get; private set; }

        public MainWindowViewModel()
        {
            ChangeTextCommand = new DelegateCommand<object>(ChangeText);
        }

        private void ChangeText(object obj)
        {
            var item = obj as TextBox;
            if (item is null) return;

            var be = item.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource();
        }

        private string lostFocusText;
        private string _title = "UpdateSourceTrigger example";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

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
