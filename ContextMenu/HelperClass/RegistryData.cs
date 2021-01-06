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
        public bool dispaly { get; set; }

        // Путь до программы
        public string pathToPrograms { get; set; }

        // Конструктор
        public RegistryData(BitmapSource icon, string name, string position, bool dispaly, string pathToPrograms)
        {
            this.icon = icon;
            this.name = name;
            this.position = position;
            this.dispaly = dispaly;
            this.pathToPrograms = pathToPrograms;
        }


    }
}
