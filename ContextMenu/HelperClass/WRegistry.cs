using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ContextMenu.HelperClass
{
    // Работа с реестром
    class WRegistry
    {
        // Путь до контекстного меню
        public string pathRegistry { set; get; }

        // Кнструктор
        public WRegistry(int pathRegistryIndex)
        {
            switch (pathRegistryIndex)
            {
                // Контекстное меню файлов
                case 0: pathRegistry = @"HKEY_CLASSES_ROOT\\*\\shell";
                    break;
                // Контекстное меню папок
                case 1: pathRegistry = @"HKEY_CLASSES_ROOT\\Folder\\shell";
                    break;
                // Контекстное меню запоминающих устройств (диски, флешки и др.) 
                case 2: pathRegistry = @"HKEY_CLASSES_ROOT\\Drive\\shell";
                    break;
                // Контекстное меню значка "Компьютер"
                case 3: pathRegistry = @"HKEY_CLASSES_ROOT\\CLSID\\{20D04FE0-3AEA-1069-A2D8-08002B30309D}\\shell";
                    break;
                // Контекстное меню Рабочего стола
                case 4: pathRegistry = @"HKEY_CLASSES_ROOT\\DesktopBackground\\Shell";
                    break;
                // Контекстное меню значка "Корзина"
                case 5: pathRegistry = @"HKEY_CLASSES_ROOT\\CLSID\\{645FF040-5081-101B-9F08-00AA002F954E}\\shell";
                    break;
            }
        }

        // Запись в реестр, по ключу и значению
        public void writeRegistry(string key, string value)
        {
            Registry.SetValue(pathRegistry, key, value);
        }

    }
}
