using Microsoft.Win32;
using SudokuApplication.Windows;
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
using Forms = System.Windows.Forms;

namespace SudokuApplication.windows
{
    /// <summary>
    /// Логика взаимодействия для MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
       

        public MenuWindow()
        {
            InitializeComponent();            
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnCreateMap_Click(object sender, RoutedEventArgs e)
        {
            CreateSudokuWindow win = new CreateSudokuWindow();
            win.Show();
            Close();
        }

        private void btnLoadMap_Click(object sender, RoutedEventArgs e)
        {
            string filePath = null;

            IsEnabled = false;

            using (Forms.OpenFileDialog fileDialog = new Forms.OpenFileDialog())
            {
                if (fileDialog.ShowDialog() == Forms.DialogResult.OK)
                {
                    filePath = fileDialog.FileName;

                    GameWindow window = new GameWindow(filePath);

                    window.Show();
                    Close();
                }
                else
                    IsEnabled = true;
            }           
        }
    }
}
