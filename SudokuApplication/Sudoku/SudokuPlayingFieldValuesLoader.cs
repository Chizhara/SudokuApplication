using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SudokuApplication.Sudoku
{
    class SudokuFileReader
    {
        private string possibleValues = "0123456789";
        public int valuesCount = 81;
        private string fileText;

        public SudokuFileReader(string filePath)
        {
            using (StreamReader fileStream = new StreamReader(filePath))
                fileText = fileStream.ReadToEnd();
        }

        public bool CheckFileCompliance()
        {
            bool result = true;

            for (int i = 0; i < fileText.Length; i++)
                if (!possibleValues.Contains(fileText[i]))
                    result = false;

            return result;
        }

        public int[] ReadValuesFromFile()
        {
            int[] values = new int[valuesCount];

            for (int i = 0; i < valuesCount; i++)
                values[i] = Convert.ToInt32(Convert.ToString(fileText[i]));

            return values;
        }
    }
}
