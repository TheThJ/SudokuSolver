using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SudokuSolver.Models;
using SudokuSolver.SudokuDb;

//Controller of the Sudoku REST API
namespace SudokuSolver.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SudokuController : ControllerBase
    {
        //Receiving the current DbContext using injection
        private readonly SudokuDbContext _context;
        public SudokuController(SudokuDbContext context)
        {
            _context = context;
        }

        //Dummy HTTP get request
        [HttpGet]
        public IEnumerable<string> GetDefault()
        {
            return new string[] {"ok"};
        }

        //Controller for the HTTP get to receive a value of a row/column
        [HttpGet("{row}/{col}", Name ="GetCellValue")]
        public IEnumerable<string> GetCellValue([FromRoute] string row, [FromRoute] string col)
        {
            if (_context.Find<Cell>(Convert.ToInt32(row),Convert.ToInt32(col)) == null)
            {
                return new string[] {""};
            } 
            Console.WriteLine("accessing: " + row +", " + col + ", value: " + _context.Find<Cell>(Convert.ToInt32(row),Convert.ToInt32(col)).cellValue);
            return new string[] {_context.Find<Cell>(Convert.ToInt32(row),Convert.ToInt32(col)).cellValue};
        }

        //Initiates the solving of the current Sudoku table in the Db. Returns the solution as a string
        [HttpGet("solve", Name ="GetSolution")]
        public IEnumerable<string> GetSolution()
        {
            _context.SaveChanges();
            var solution = solveSudoku();
            string output = "";
            if (solution[0,0] != 0)
            { 
                for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9;j++)
                    {
                        output += solution[i,j];
                        if (_context.Find<Cell>(i,j) == null)
                        {
                            _context.Add<Cell>(new Cell() { row = i, col = j , cellValue = solution[i,j].ToString() });
                            _context.SaveChanges();
                        }
                    }
                }
            }
            else
            {
                output = "0";
            }
            Console.WriteLine("solution: " + output);
            return new string[] {output};
        }
        
        //Clears out every cell in the current Db
        [HttpPut("clear", Name ="ClearTable")]
        public void ClearTable()
        {
            for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; j < 9;j++)
                    {
                        if (_context.Find<Cell>(i,j) != null)
                        {
                            _context.Remove(_context.Find<Cell>(i,j));
                            _context.SaveChanges();
                        }
                    }
                }
        }

        //Updates the current cell with the provided value
        [HttpPut("{row}/{col}/{value}", Name ="Put")]
        public  void Put(string row, string col, string value)
        {
            if (_context.Find<Cell>(Convert.ToInt32(row),Convert.ToInt32(col)) == null)
            {
                _context.Add<Cell>(new Cell() { row = Convert.ToInt32(row), col = Convert.ToInt32(col) , cellValue = value });
            }
            else
            {
                if (value.Equals("0"))
                {
                    _context.Remove(_context.Find<Cell>(Convert.ToInt32(row),Convert.ToInt32(col)));
                }
                else
                {
                    _context.Find<Cell>(Convert.ToInt32(row),Convert.ToInt32(col)).cellValue = value;
                }
                
            }
            _context.SaveChanges();
        }

        //Solver for the Sudoku
        public char[,] solveSudoku() {
            var table = new char[,] {
                {'0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0'},
                {'0','0','0','0','0','0','0','0','0'}};

            for (int i = 0; i < 9; i++)
                {
                    for (int j = 0; i < 9; i++)
                    {
                        if (_context.Find<Cell>(i,j) != null)
                        {
                            table[i,j] = _context.Find<Cell>(i,j).cellValue.ToCharArray()[0];
                        }
                    }
                }

            if(backtrack(table,0,0)) return table;
            else return new char[,] {{'0'}};
            
        }
        private static bool backtrack (char[,] table, int row, int col){
            if(col==9)
            {
                col = 0; ++row;
                if(row==9) return true;
            }

            if(table[row,col]!='0')
                return backtrack(table, row, col+1);

            for(char v = '1' ; v <='9' ; v++)
            {                
                if(isValid(table, row, col, v))
                {                
                    table[row,col] = v;
                    if(backtrack(table, row, col+1)) return true;                    
                    else table[row,col] = '0';
                }
            } 
            return false;
        }
        private static bool isValid(char[,] table, int row, int col,char val){
        for(int r = 0 ; r < 9 ; r++)
            if(table[r,col]==val) return false;
			
        for(int c = 0 ; c < 9 ; c++)
            if(table[row,c]==val) return false;    
        
        int I = row/3; int J = col/3;
        for(int a = 0 ; a < 3 ; a++)
            for(int b = 0 ; b < 3 ; b++)
                if(val==table[3*I+a,3*J+b]) return false;
        
        return true;       
        }
    }
}
