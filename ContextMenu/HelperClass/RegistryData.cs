using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ContextMenu.HelperClass
{
    // Класс описывающий поля для работы с реестром 

    public class RegistryData
    {
        // Иконка приложения в виде ресурса для image
        public BitmapSource icon { get; set; }

        // Имя пункта меню
        public string name { get; set; }

        // Позиция пункта меню
        public string position { get; set; }

        // Отображение (с sift'ом или без)
        public string display { get; set; }

        // Путь до программы
        public string pathToPrograms { get; set; }

        // Конструктор
        public RegistryData(BitmapSource icon, string name, int position, bool display, string pathToPrograms)
        {
            this.icon = icon;
            this.name = name;

            // Путь до картинки, для отображения позиции пункта меню
            string positionPath = "Resources/";

            switch (position)
            {
                case 0:
                    positionPath += "top.png";
                    break;
                case 1:
                    positionPath += "center.png";
                    break;
                case 2:
                    positionPath += "bottom.png";
                    break;
            }

            this.position = positionPath;

            // Путь до картинки, для отображения пункта меню с shift'ом или без
            string displayPath = "Resources/";
            if (display) displayPath += "shift.png";
            else
                displayPath += "noShift.png";


            this.display = displayPath;
            this.pathToPrograms = pathToPrograms;
        }


    }
}
