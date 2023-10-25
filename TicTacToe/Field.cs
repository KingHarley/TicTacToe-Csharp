using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    internal class Field
    {
        public readonly int Row;
        public readonly int Column;
        public Field(int row, int column)
        {
            Row = row;
            Column = column;
        }
    }
}
