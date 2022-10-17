using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;

namespace SudokuApplication.SudokuPanel
{
    public class ButtonSudokuSquare : Button
    {
        public int[] Coordinates { get; } = new int[2];
        public bool isSpecified = false;

        public ButtonSudokuSquare(int[] coordinates, int Size, int Indent, int BorderIndent, int addIndent)
        {
            if (coordinates.Length != 2)
                throw new Exception("Sudoku square can have only 2 coordinates");

            Coordinates = coordinates;

            Background = Brushes.Gray;

            Height = Size;
            Width = Size;
            Visibility = Visibility.Visible;
            Margin = new Thickness((Size + Indent) * coordinates[0] + BorderIndent + addIndent, (Size + Indent) * coordinates[1] + BorderIndent + addIndent, 0, 0);
        }
    }
}
