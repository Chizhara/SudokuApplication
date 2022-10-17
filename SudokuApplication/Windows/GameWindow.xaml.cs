using SudokuApplication.SudokuPanel;
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
using System.Windows.Shapes;

namespace SudokuApplication.windows
{
    public partial class GameWindow : Window
    {
        SudokuFieldCanvas sudokuPanel;

        public GameWindow(string filePath)
        {
            InitializeComponent();

            sudokuPanel = new SudokuFieldCanvas(filePath);
            grGameField.Children.Add(sudokuPanel);

            for (int i = 1; i <= 9; i++)
                wpValues.Children.Add(CreateValueButton(i));
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            if(sudokuPanel.IsGameFieldCanvasCompleted())
            {
                MessageBox.Show("Вы верно решили судоку", "Поздравляем!", MessageBoxButton.OK, MessageBoxImage.Information);
                MenuWindow win = new MenuWindow();
                win.Show();
                Close();
            }    
            else
                MessageBox.Show("Вы неверно решили судоку. Проверьте ещё раз", "Ой!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private Button CreateValueButton(int value)
        {
            Button btnValue = new Button()
            {
                Content = Convert.ToString(value),
                Height = 50,
                Width = 50,
                Background = Brushes.Gray,
            };

            btnValue.Click += new RoutedEventHandler(btnSetValue_Click);

            return btnValue;
        }

        private void btnSetValue_Click(object sender, RoutedEventArgs e)
        {
            sudokuPanel.SetNewValueToSquare((string)((Button)sender).Content);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow win = new MenuWindow();
            win.Show();
            Close();
        }
    }
}
