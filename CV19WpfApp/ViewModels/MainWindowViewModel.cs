﻿using CV19WpfApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace CV19WpfApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
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







    }
}
