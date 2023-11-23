using BoardApp.Services.Interfaces;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MonefyProjects.Messages;
using MonefyProjects.Models;
using MonefyProjects.Services.Classes;
using MonefyProjects.Services.Interfaces;
using MonefyProjects.Views;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MonefyProjects.ViewModels
{
    internal class HomeScreenViewModel : ViewModelBase
    {
        private string _sum = "0";

        

        public string Sum
        {
            get => _sum;
            set => Set(ref _sum, value);
        }
        public string Operation { get; set; }
        private DataModel _data;

        private readonly IProjectNavigationService _navigationService;
        private readonly IDataService _dataService;
        private readonly IMessenger _messenger;

        public DataModel MyCommand { get; private set; }



        public HomeScreenViewModel(IProjectNavigationService navigationService, IDataService dataService, IMessenger messenger)
        {

            _navigationService = navigationService;
            _dataService = dataService;
            _messenger = messenger;

            _messenger.Register<DataMessage>(this, message =>
            {
                if (message != null)
                {
                    _data = message.Data as DataModel;
                    if (Operation == "+") Sum = (Convert.ToDouble(_data.Money) + Convert.ToDouble(Sum)).ToString();
                    if (Operation == "-") Sum = (Convert.ToDouble(_data.Money) + Convert.ToDouble(Sum)).ToString();
                    if (Operation == ".") Sum = (Convert.ToDouble(_data.Money) + Convert.ToDouble(Sum)).ToString();
                }
            });
        }



        public RelayCommand<string> OpenCalcCommand
        {
            get => new((param) =>
            {
                Operation = param;
                if (param == "+")
                {
                    _navigationService.NavigateTo<CalcPlussViewModel>();
                }
                else if (param == "-")
                {
                    _navigationService.NavigateTo<CalcMinusViewModel>();
                }
                else
                {
                    _navigationService.NavigateTo<CalcViewModel>();
                }
            });
        }

       

        public RelayCommand<string> ShowBalace
        {
            get => new((Messages) =>
            {
                MessageBox.Show(Messages);
            });
        }



    }
}
