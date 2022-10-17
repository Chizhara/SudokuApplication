using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace SudokuApplication.Sudoku
{
    public class SudokuGameField
    {
        private const int gameFieldSize = 9;

        private int[,] gameFieldValues;

        public SudokuGameField()
        {
            gameFieldValues = new int[gameFieldSize, gameFieldSize];

            InitializeValues();
        }

        public bool TryReadValuesFromFile(string filePath)
        {
            bool answer = true;

            SudokuFileReader sudokuFileReader = new SudokuFileReader(filePath);

            if (sudokuFileReader.CheckFileCompliance())
                PlaceValues(sudokuFileReader.ReadValuesFromFile());
            else
                answer = false;

            return answer;
        }

        public void SaveGameFieldToFile(string filePath)
        {
            bool answer = true;

            SudokuFileReader sudokuFileReader = new SudokuFileReader(filePath);

            if (sudokuFileReader.CheckFileCompliance())
                PlaceValues(sudokuFileReader.ReadValuesFromFile());
            else
                answer = false;
        }

        public int GetValue(int posX, int posY) => gameFieldValues[posX, posY];
        public void SetValue(int posX, int posY, int value) => gameFieldValues[posX,posY] = value;

        private void InitializeValues()
        {
            for (int i = 0; i < gameFieldSize; i++)
                for (int j = 0; j < gameFieldSize; j++)
                    gameFieldValues[i, j] = 0;
        }

        private void PlaceValues(int[] valuesMass)
        {
            for (int i = 0; i < gameFieldSize; i++)
                for (int j = 0; j < gameFieldSize; j++)
                    gameFieldValues[j, i] = valuesMass[i * gameFieldSize + j];
        }
    }
}
