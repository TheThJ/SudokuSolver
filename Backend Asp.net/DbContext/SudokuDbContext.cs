using Microsoft.EntityFrameworkCore;
using SudokuSolver.Models;



namespace SudokuSolver.SudokuDb
{
    public class SudokuDbContext : DbContext
    {
        public SudokuDbContext(DbContextOptions<SudokuDbContext> options) : base(options) {
            
        }
        public DbSet<Cell> Cells  {get; set;}

        //Seeding of the Db
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cell>().HasKey(c => new { c.row, c.col });

            modelBuilder.Entity<Cell>().HasData(
                        new Cell {row = 0, col = 2, cellValue = "1"},
                        new Cell {row = 0, col = 6, cellValue = "7"},
                        new Cell {row = 1, col = 3, cellValue = "4"},
                        new Cell {row = 1, col = 5, cellValue = "8"},
                        new Cell {row = 1, col = 8, cellValue = "3"},
                        new Cell {row = 2, col = 0, cellValue = "3"},
                        new Cell {row = 2, col = 3, cellValue = "9"},
                        new Cell {row = 2, col = 5, cellValue = "6"},
                        new Cell {row = 2, col = 8, cellValue = "1"},
                        new Cell {row = 3, col = 1, cellValue = "2"},
                        new Cell {row = 3, col = 2, cellValue = "8"},
                        new Cell {row = 3, col = 6, cellValue = "1"},
                        new Cell {row = 3, col = 7, cellValue = "5"},
                        new Cell {row = 5, col = 1, cellValue = "5"},
                        new Cell {row = 5, col = 2, cellValue = "4"},
                        new Cell {row = 5, col = 6, cellValue = "6"},
                        new Cell {row = 5, col = 7, cellValue = "3"},
                        new Cell {row = 6, col = 0, cellValue = "1"},
                        new Cell {row = 6, col = 3, cellValue = "3"},
                        new Cell {row = 6, col = 5, cellValue = "4"},
                        new Cell {row = 6, col = 8, cellValue = "9"},
                        new Cell {row = 7, col = 3, cellValue = "1"},
                        new Cell {row = 7, col = 5, cellValue = "9"},
                        new Cell {row = 8, col = 2, cellValue = "2"},
                        new Cell {row = 8, col = 6, cellValue = "3"}                      
            );
        }
        
    }
}