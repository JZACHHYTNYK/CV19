﻿using CV19WpfApp.Infastructure.Commands;
using CV19WpfApp.Model;
using CV19WpfApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;


namespace CV19WpfApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region A: 
        /// <summary>
        /// Текстовый набор данных для визуализации графиков
        /// </summary>
        private IEnumerable<DataPoint> _TestDataPoints;

        /// <summary>
        /// Текстовый набор данных для визуализации графиков
        /// </summary>
        public IEnumerable<DataPoint> TestDataPoints
        {
            get => _TestDataPoints;
            set => Set(ref _TestDataPoints, value);
        }

        #endregion

        #region Заголовок окна
        private string _Title = "Анализ статистики СV19";
        /// <summary>Заголовок окна</summary>
        public string Title
        {
            get { return _Title; }
            //set 
            //{
            //    //if(Equals(_Title,value)) return;
            //    //_Title = value;
            //    // OnPropertyChanged();

            //    Set(ref _Title, value);
            //}
            set => Set(ref _Title, value);
        }
        #endregion

        #region Status : string - Статус программы

        /// <summary>Статус программы</summary>
        private string _Status = "Готов!";
        /// <summary>Статус программы</summary>
        public string Status
        {
            get { return _Status; }
            set => Set(ref _Status, value);
        }
        #endregion


        #region Команды

        #region CloseApplicationCommand
        public ICommand CloseApplicationCommand { get; }

        //он будет выполняться когда команды выполняяется
        private bool CanCloseApplicationCommandExecute(object p) => true;
        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }
        #endregion

        #endregion
        public MainWindowViewModel()
        {
            #region Команды
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            #endregion

            var data_points=new List<DataPoint>((int)(360/0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);
                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }
            TestDataPoints=data_points;
        }





    }
}
