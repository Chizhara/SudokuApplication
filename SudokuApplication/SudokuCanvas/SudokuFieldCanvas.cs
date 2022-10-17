using SudokuApplication.Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Froms = System.Windows.Forms;

namespace SudokuApplication.SudokuPanel
{
    class SudokuFieldCanvas : Canvas
    {
        private const int fieldSize = 9;

        private const int btnSize = 40;
        private const int btnIndent = 10;
        private const int btnBorderIndent = 15;
        private const int sectionsIndent = 8;

        private ButtonSudokuSquare[,] btnSquareMass;
        private ButtonSudokuSquare btnSelectedSqaure;
        private SudokuGameField gameField;
        private SudokuCompleter sudokuCompleter;
        private SudokuPlayingFieldKeeper sudokuPlayingFieldKeeper;

        public SudokuFieldCanvas()
        {
            btnSquareMass = new ButtonSudokuSquare[fieldSize, fieldSize];
            gameField = new SudokuGameField();

            sudokuCompleter = new SudokuCompleter(gameField);
            sudokuPlayingFieldKeeper = new SudokuPlayingFieldKeeper(gameField);

            RenderCanvas();
        }

        public SudokuFieldCanvas(string filePath)
        {
            btnSquareMass = new ButtonSudokuSquare[fieldSize, fieldSize];
            gameField = new SudokuGameField();

            sudokuCompleter = new SudokuCompleter(gameField);
            
            if (!gameField.TryReadValuesFromFile(filePath))
                throw new Exception();

            RenderCanvas();
        }

        public bool IsGameFieldCanvasCompleted() => sudokuCompleter.IsSudokuCompleted();
        public void SaveGameFieldToFile(string filePath) => sudokuPlayingFieldKeeper.WriteToFilePlayingField(filePath);

        public void SetNewValueToSquare(string value)
        {
            if (btnSelectedSqaure != null)
            {
                int[] coords = btnSelectedSqaure.Coordinates;

                btnSelectedSqaure.Content = value;
                gameField.SetValue(coords[0], coords[1], Convert.ToInt32(value));
            }               
        }     

        private void RenderCanvas()
        {
            Width = fieldSize * (btnSize + btnIndent) - btnIndent + btnBorderIndent * 2;
            Height = fieldSize * (btnSize + btnIndent) - btnIndent + btnBorderIndent * 2;

            Visibility = Visibility.Visible;

            InitializeButtons();
        }

        private void InitializeButtons()
        {
            int fieldValue;

            for (int i = 0; i < fieldSize; i++)
                for(int j = 0; j < fieldSize; j++)
                {
                    btnSquareMass[i, j] = new ButtonSudokuSquare(new int[] {i, j}, btnSize, btnIndent, btnBorderIndent, sectionsIndent);

                    fieldValue = gameField.GetValue(i, j);

                    if (fieldValue != 0) 
                    {
                        btnSquareMass[i, j].IsEnabled = false;
                        btnSquareMass[i, j].Content = fieldValue;
                    }                      

                    Children.Add(btnSquareMass[i, j]);
                    btnSquareMass[i, j].Visibility = Visibility.Visible;
                    btnSquareMass[i, j].Click += new RoutedEventHandler(btnSudokuSelected_Click);
                }                    
        }

        private void btnSudokuSelected_Click(object sender, RoutedEventArgs e)
        {
            if (btnSelectedSqaure != null)
                btnSelectedSqaure.Background = Brushes.Gray;
           
            btnSelectedSqaure = (ButtonSudokuSquare)sender;
            btnSelectedSqaure.Background = Brushes.LightCyan;
        }
    }
}
