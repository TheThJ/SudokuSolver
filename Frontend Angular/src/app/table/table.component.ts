import { Component, OnInit ,QueryList, ViewChild , ViewChildren } from '@angular/core';
import { CellComponent } from './cell/cell.component';
import { indices } from '../app.component';




@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent implements OnInit {

  //Finds every cell of this sudoku Table
  @ViewChildren('tableCells') tableCells: QueryList<CellComponent> | undefined;

  indices = indices;
  constructor() {
  }

  ngOnInit(): void {
  }

  //clears out every value in every cell of the table
  clearTable() {
    console.log('clearing Table');
    for (let i = 0; i < 81; i++) {
      this.tableCells?.get(i)?.setValue('');
    }
  }

  //Updates the table with the value given from a string
  updateTable(newValue : string){
    console.log('updating Table');
    for (let i = 0; i < 81; i++) {
      this.tableCells?.get(i)?.setValue(Array.from(newValue)[i]);
    }
  }


}
