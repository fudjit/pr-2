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
using LibMas;
using Lib_7;

namespace pr_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[] _array;
        SimpleArray simpleArray = new SimpleArray();
        CalculateModule calculate = new CalculateModule();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FileOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _array = simpleArray.Open();
                MainDataGrid.ItemsSource = VisualArray.ToDataTable(_array).DefaultView;
            }
            catch (ArgumentNullException)
            {

                MessageBox.Show("");
            }
        }

        private void FileSave_Click(object sender, RoutedEventArgs e)
        {
            simpleArray.Save();
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            InputN.Clear();
            ResOutput.Clear();
            simpleArray.Initialize(0, 0);
            MainDataGrid.ItemsSource = VisualArray.ToDataTable(_array).DefaultView;
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Практическая работа №2\n" +
               "Даанов Шахмар ИСП - 34\n" +
               "Ввести n целых чисел. Вычислить для чисел < 0 функцию x2. Результат обработки каждого числа вывести на экран.", "О программе", MessageBoxButton.OK);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void GenerateTab_Click(object sender, RoutedEventArgs e)
        {
            bool isInputEmpty = int.TryParse(InputN.Text, out int length);
            if (isInputEmpty && length > 0)
            {
                _array = simpleArray.GenerateRandom(length);
                MainDataGrid.ItemsSource = VisualArray.ToDataTable(_array).DefaultView;
            }
            else MessageBox.Show("Введите длину(положительное целое число)", "Ошибка");
        }

        private void Calc_Click(object sender, RoutedEventArgs e)
        {
            if (_array != null)
                ResOutput.Text = calculate.Calc(_array);
            else MessageBox.Show("Сгенерируйте таблицу", "Ошибка");
        }
    }
}
