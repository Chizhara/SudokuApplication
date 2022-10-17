using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuApplication.Sudoku
{
    public class SudokuCompleter
    {
        private SudokuGameField gameField;
        private int fieldSize = 9;

        public SudokuCompleter(SudokuGameField concreteGameField)
        {
            gameField = concreteGameField;
        }

        public bool IsSudokuCompleted()
        {
            bool res = true;

            for (int i = 0; i < fieldSize - 1; i++)
                for (int j = 0; j < fieldSize - 1; j++)                
                    if (IsHorizontalMatches(i,j) || IsVerticalMatches(i, j) || IsSectionMatches(i, j) || gameField.GetValue(i,j) == 0)
                        res = false;
                        

            return res;
        }

        private bool IsHorizontalMatches(int x, int y)
        {
            bool res = false;
            int concreteValue = gameField.GetValue(x,y);

            for (int i = x + 1; i < fieldSize; i++)
                if (concreteValue == gameField.GetValue(i, y))
                {
                    res = true;
                    break;
                }                    

            return res;
        }

        private bool IsVerticalMatches(int x, int y)
        {
            bool res = false;
            int concreteValue = gameField.GetValue(x, y);

            for (int i = y + 1; i < fieldSize; i++)
                if (concreteValue == gameField.GetValue(x, i))
                {
                    res = true;
                    break;
                }

            return res;
        }

        private bool IsSectionMatches(int x, int y)
        {
            bool res = false;
            int concreteValue = gameField.GetValue(x, y);

            for (int j = y + 1, i = x; (j < (y / 3 + 3)) && (i < (x / 3 + 3)); j++)
                if (j >= x / 3 + 3)
                {
                    j -= 2;
                    i++;
                }                       
                else if(concreteValue == gameField.GetValue(i, j))
                {
                    res = true;
                    break;
                }                 

            return res;
        }
    }
}
