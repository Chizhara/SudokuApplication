using SudokuApplication.windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Forms = System.Windows.Forms;
using System.IO;

namespace SudokuApplication.Sudoku
{
    public class SudokuPlayingFieldKeeper
    {
        SudokuGameField gameField;
        int gameFieldSize = 9;

        public SudokuPlayingFieldKeeper(SudokuGameField concreteGameField)
        {
            gameField = concreteGameField;
        }

        public void WriteToFilePlayingField(string fileName)
        {         
            using (StreamWriter strWriter = new StreamWriter(fileName, false))
            {
                strWriter.Write(ReturnValuesFromField());
            }
        }

        private string ReturnValuesFromField()
        {
            string values = "";

            for (int i = 0; i < gameFieldSize; i++)
                for (int j = 0; j < gameFieldSize; j++)
                    values += gameField.GetValue(j, i);

            return values;
        }
    }
}
