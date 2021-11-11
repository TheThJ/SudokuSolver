import { Component,ViewChild } from '@angular/core';
import { TableComponent } from './table/table.component';
import { AppService } from './app.service';

// indices used in the creation of the sudoku table
export const indices = [0, 1, 2, 3, 4, 5, 6, 7, 8];

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor (private appService : AppService) {}

  title = 'SudokuSolver';

  //Load the content of its table child to use functions of it
  @ViewChild('table') table: TableComponent | undefined;

  //Clearing the table
  clearTable() {
    this.table?.clearTable();
    this.appService.clearTable("https://localhost:5001/api/Sudoku/clear");
  }
  //solvs the current table and updates the current table with the solutions
  solveTable () {
    this.appService.getSolution("https://localhost:5001/api/Sudoku/solve").subscribe(x  => this.table?.updateTable(x[0]));
  }


}
