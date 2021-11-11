using Microsoft.EntityFrameworkCore;

namespace SudokuSolver.Models
{
    public class Cell {
        public int row {get; set;}
        public int col {get; set;}
        public string cellValue {get; set;}
    }
}