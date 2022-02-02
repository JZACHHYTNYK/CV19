using CV19WpfApp.Infastructure.Commands;
using CV19WpfApp.Model;
using CV19WpfApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;
using CV19WpfApp.Model.Decanat;
using System.Linq;

namespace CV19WpfApp.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {

        /*--------------------------------------------------------------------------------------------------------------------------*/

        public ObservableCollection<Group> Groups { get; }


        #region SelectedGroup
        /// <summary>
        /// Выбранная группа
        /// </summary>
        private Group _SelectedGroup;
        /// <summary>
        /// Выбранная группа
        /// </summary>
        public Group SelectedGroup
        {
            get => _SelectedGroup;
            set => Set(ref _SelectedGroup, value);
        }

        #endregion



        #region SelectedPageIndex: int - DESCRIPTON 
        /// <summary>
        /// Номер выбранной вкладки
        /// </summary>
        private int _SelectedPageIndex;

        /// <summary>
        /// Номер выбранной вкладки
        /// </summary>
        public int SelectedPageIndex
        {
            get => _SelectedPageIndex;
            set => Set(ref _SelectedPageIndex, value);
        }

        #endregion


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

        /*--------------------------------------------------------------------------------------------------------------------------------*/
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

        #region SelectTabIndex

        public ICommand ChangeTabIndexCommand { get; }

        private bool CanChangeTabIndexCommandExecute(object p) => _SelectedPageIndex >= 0;

        private void OnChangeTabIndexCommandExecute(object p)
        {
            if (p is null) return;
            SelectedPageIndex += Convert.ToInt32(p);
        }

        #endregion



        #endregion

        /*--------------------------------------------------------------------------------------------------------------------------------*/

        public MainWindowViewModel()
        {
            #region Команды
            CloseApplicationCommand = new LambdaCommand(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            ChangeTabIndexCommand = new LambdaCommand(OnChangeTabIndexCommandExecute, CanChangeTabIndexCommandExecute);

            #endregion

            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                var y = Math.Sin(x * to_rad);
                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }
            TestDataPoints = data_points;

            var student_index = 1;


            var students = Enumerable.Range(1, 10).Select(i => new Student()
            {
                Name = $"Name{student_index}",
                Surname = $"Surname {student_index}",
                Patronymic = $"Patronymic {student_index++}",
                Birthday = DateTime.Now,
                Rating = 0
            });

            var groups = Enumerable.Range(1, 20).Select(i => new Group()
            {
                Name = $"Группа{i}",
                Students = new ObservableCollection<Student>(students)
            });

            Groups = new ObservableCollection<Group>(groups);

        }





    }
}
