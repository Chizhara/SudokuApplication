using SudokuApplication.Sudoku;
using SudokuApplication.SudokuPanel;
using SudokuApplication.windows;
using System;
using System.Collections.Generic;
using System.IO;
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
using Forms = System.Windows.Forms;

namespace SudokuApplication.Windows
{
    /// <summary>
    /// Логика взаимодействия для CreateSudokuWindow.xaml
    /// </summary>
    public partial class CreateSudokuWindow : Window
    {
        SudokuFieldCanvas sudokuCanvas;

        public CreateSudokuWindow()
        {
            InitializeComponent();

            sudokuCanvas = new SudokuFieldCanvas();
            grGameField.Children.Add(sudokuCanvas);

            for (int i = 1; i <= 9; i++)
                wpValues.Children.Add(CreateValueButton(i));
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
            sudokuCanvas.SetNewValueToSquare((string)((Button)sender).Content);
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string filePath = null;

            using (Forms.SaveFileDialog fileDialog = new Forms.SaveFileDialog())
            {
                fileDialog.Filter = "Текстовые файлы (*.txt)|*.txt";

                if (fileDialog.ShowDialog() == Forms.DialogResult.OK)
                {
                    filePath = fileDialog.FileName;

                    sudokuCanvas.SaveGameFieldToFile(filePath);

                    MenuWindow win = new MenuWindow();
                    win.Show();
                    Close();
                }                    
            }          
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow win = new MenuWindow();
            win.Show();
            Close();
        }
    }
}
