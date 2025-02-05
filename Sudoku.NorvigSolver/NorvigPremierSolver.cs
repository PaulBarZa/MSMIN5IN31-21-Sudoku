﻿using Sudoku.Shared;
using System.Globalization;
using System.Text;
using System.Linq;

namespace Sudoku.NorvigSolver
{
    public  class NorvigPremierSolver : ISolverSudoku
    {

        

        public SudokuGrid Solve(SudokuGrid sorel)
        {
            var stringSudoku = sorel.Cells.Aggregate("",
                (strRows, row) => strRows + row.Aggregate("",
                    (strCells, cell) => strCells + cell.ToString(CultureInfo.InvariantCulture)));
            var dictSudoku = LinqSudokuSolver.parse_grid(stringSudoku);
            var dictSolution = LinqSudokuSolver.search(dictSudoku);
            var toReturn = new SudokuGrid();
            foreach (var strCellPair in dictSolution)
            {
                var rowIndex = strCellPair.Key[0] - 'A';
                var colIndex = strCellPair.Key[1] - '1';
                toReturn.Cells[rowIndex][colIndex] = int.Parse(strCellPair.Value, CultureInfo.InvariantCulture);
            }

            return toReturn;
        }

    }

    
}
