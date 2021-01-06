using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using ContextMenu.HelperClass;

namespace ContextMenu
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Dll для получения иконки программы
        [DllImport("gdi32")]
        static extern int DeleteObject(IntPtr o);

        // Коллекция с исторей подключения к УТМ
        private ObservableCollection<RegistryData> contextMenuCollection;

        // Ресурс выбранной иконки программы для загрузки в image
        private BitmapSource iconBitmapSource;

        // Путь до программы
        private string pathToPrograms;

        public MainWindow()
        {
            InitializeComponent();
        }

        // При нажатии на кнопку добавить контекстное меню
        private void addToolbarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // При нажатии на кнопку удалить контекстное меню
        private void delToolbarButton_Click(object sender, RoutedEventArgs e)
        {

        }

        // Метод для приобразования иконки в ресурс для image
        public static BitmapSource getBitmapSource(string fileName)
        {
            // Получение иконки фйла
            var icon = System.Drawing.Icon.ExtractAssociatedIcon(fileName);
            // Приобразование в Bitmap
            IntPtr ip = icon.ToBitmap().GetHbitmap();
            
            BitmapSource bitmapSource;

            // Приобразование в ресурс
            try
            {
                bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(ip,
                IntPtr.Zero, Int32Rect.Empty,
                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(ip);
            }

            return bitmapSource;
        }

        // При нажатии на кнопку выбраать файл
        private void getPathMenuButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == true)
            {
                pathToPrograms = openFileDialog.FileName;

                iconBitmapSource = getBitmapSource(pathToPrograms);
                iconImage.Source = iconBitmapSource;
                pathMenuTextBox.Text = pathToPrograms;
            }
        }

        // При нажатии на кнопку Добавить
        private void addMenuButton_Click(object sender, RoutedEventArgs e)
        {            
            // Получение Отображения
            bool display;
            if (displayCheckBox.IsChecked == true) display = true;
            else
                display = false;

            // Добавление в данных пункта меню в коллекцию 
            contextMenuCollection.Add(new RegistryData(
                iconBitmapSource,
                nameMenuTextBox.Text,
                positionMenuComboBox.SelectedItem.ToString(),
                (bool)displayCheckBox.IsChecked,
                pathToPrograms
            ));

            menuListBox.ItemsSource = contextMenuCollection;
        }

        // При загрузке формы
        private void mainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Инициализация коллекции пунктов меню
            contextMenuCollection = new ObservableCollection<RegistryData>();
        }
    }
}
