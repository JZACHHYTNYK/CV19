using CV19WpfApp.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace CV19WpfApp.ViewModels
{
    internal partial class MainWindowViewModel
    {


        #region Prop

        #region Password: string - DESCRIPTON 
        /// <summary>
        /// Вывод пароля 
        /// </summary>
        private string _PasswordOutput;

        /// <summary>
        /// Вывод пароля
        /// </summary>
        public string PasswordOutput
        {
            get => _PasswordOutput;
            set => Set(ref _PasswordOutput, value);
        }

        #endregion Password

        #region LenghtString: int - DESCRIPTON 
        /// <summary>
        /// Вывод пароля 
        /// </summary>
        private int _LenghtString=4;

        /// <summary>
        /// Вывод пароля
        /// </summary>
        public int LenghtString
        {
            get => _LenghtString;
            set => Set(ref _LenghtString, value);
        }

        #endregion LenghtString

        #region IsCheckBox_EngBig: bool - DESCRIPTON 
        /// <summary>
        /// Большие Английские буквы 
        /// </summary>
        private bool _EngBig;
        /// <summary>
        /// Большие Английские буквы
        /// </summary>
        public bool EngBig
        {
            get => _EngBig;
            set => Set(ref _EngBig, value);
        }
        #endregion IsCheckBox

        #region IsCheckBox_EngSmall: bool - DESCRIPTON 
        /// <summary>
        /// Маленькие Английские буквы 
        /// </summary>
        private bool _EngSmall;
        /// <summary>
        /// Маленькие Английские буквы
        /// </summary>
        public bool EngSmall
        {
            get => _EngSmall;
            set => Set(ref _EngSmall, value);
        }
        #endregion IsCheckBox_EngSmall

        #region IsCheckBox_RuSmall: bool - DESCRIPTON 
        /// <summary>
        /// Маленькие Английские буквы 
        /// </summary>
        private bool _RuSmall;
        /// <summary>
        /// Маленькие Английские буквы
        /// </summary>
        public bool RuSmall
        {
            get => _RuSmall;
            set => Set(ref _RuSmall, value);
        }
        #endregion IsCheckBox_RuSmall

        #region IsCheckBox_RuBig: bool - DESCRIPTON 
        /// <summary>
        /// Большие Рус буквы 
        /// </summary>
        private bool _RuBig;
        /// <summary>
        /// Большие Рус буквы
        /// </summary>
        public bool RuBig
        {
            get => _RuBig;
            set => Set(ref _RuBig, value);
        }
        #endregion IsCheckBox_RuBig

        #region IsCheckBox_SpacialCharacters: bool - DESCRIPTON 
        /// <summary>
        /// Спец символы 
        /// </summary>
        private bool _SpacialCharacters;
        /// <summary>
        /// Спец символы
        /// </summary>
        public bool SpacialCharacters
        {
            get => _SpacialCharacters;
            set => Set(ref _SpacialCharacters, value);
        }
        #endregion IsCheckBox_SpacialCharacters

        #region IsCheckBox_Numbers: bool - DESCRIPTON 
        /// <summary>
        /// Цифры 
        /// </summary>
        private bool _Numbers;
        /// <summary>
        /// Цифры
        /// </summary>
        public bool Numbers
        {
            get => _Numbers;
            set => Set(ref _Numbers, value);
        }
        #endregion IsCheckBox_Numbers

        #endregion




        #region Command
        public ICommand GeneratePassword { get; }

        private bool CanGeneratePasswordExecute(object p) => true;

        private void OnGeneratePasswordExecute(object p)
        {
            string str = "Test";
            string result="";

            //string[] smallEnglish = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "r", "s", "t", "u", "v", "w", "x", "y", "z" };
            string smallEnglish = "abcdefghijklmnoprstuvwxyz";
            string bigEnglish = smallEnglish.ToUpper();
            string smallRu = "абвгдежзийклмнопрстуфхцчшщъыьэюя";
            string bigRu=smallRu.ToUpper();
            string NumbersStr = "1234567890";
            string specSimvol="!@#$%^&*()_-=+?";

            if (_EngSmall)
            {
                str += smallEnglish;
            }
            if (_EngBig)
            {
                str += bigEnglish;
            }
            if (_RuBig)
            {
                str += bigRu;
            }
            if (_RuSmall)
            {
                str += smallRu;
            }
            if (_Numbers)
            {
                str += NumbersStr;
            }
            if (_SpacialCharacters)
            {
                str += specSimvol;
            }
            Random random = new Random();

            for (int i = 0; i < LenghtString; i++)
            {
                result+=str[random.Next(str.Length-1)].ToString();
            }



            PasswordOutput = result;
        }
        #endregion









    }
}
