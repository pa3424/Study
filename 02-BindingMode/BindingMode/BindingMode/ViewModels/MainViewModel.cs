using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BindingMode.ViewModels
{
    public class MainViewModel : ObservableRecipient
    {
        public ICommand SetRandomTextCommand { get; private set; }

        public MainViewModel()
        {
            SetRandomTextCommand = new RelayCommand<string>(async (text) => await SetRandomText(text));
        }

        private async Task SetRandomText(string text)
        {
            var randomText = RandomString(new Random().Next(1, 15));
            switch (text)
            {
                case "TwoWayText":
                    TwoWayText = randomText;
                    break;
                case "OneWayText":
                    OneWayText = randomText;
                    break;
                case "OneTimeText":
                    OneTimeText = randomText;
                    break;
                case "OneWayToSourceText":
                    OneWayToSourceText = randomText;
                    break;
                case "DefaultText":
                    DefaultText = randomText;
                    break;
            }
            await Task.CompletedTask;
        }

        private string RandomString(int length)
        {
            var random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private string twoWayText = "TwoWay_Example";
        public string TwoWayText
        {
            get { return twoWayText; }
            set { SetProperty(ref twoWayText, value); }
        }

        private string oneWayText = "OneWay_Example";
        public string OneWayText
        {
            get { return oneWayText; }
            set { SetProperty(ref oneWayText, value); }
        }

        private string oneTimeText = "OneTime_Example";
        public string OneTimeText
        {
            get { return oneTimeText; }
            set { SetProperty(ref oneTimeText, value); }
        }

        private string oneWayToSourceText = "OneWayToSource_Example";
        public string OneWayToSourceText
        {
            get { return oneWayToSourceText; }
            set { SetProperty(ref oneWayToSourceText, value); }
        }

        private string defaultText = "Default_Example";
        public string DefaultText
        {
            get { return defaultText; }
            set { SetProperty(ref defaultText, value); }
        }
    }
}
