using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace SudokuSolver.Models
{
    public class Table
    {
        public int id {get; set;}
        public Cell[] cells {get;set;}
    }
}