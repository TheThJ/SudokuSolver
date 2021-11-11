import { Component, OnInit, Input } from '@angular/core';
import { Output, EventEmitter } from '@angular/core';
import { AppService } from 'src/app/app.service';


@Component({
  selector: 'app-cell',
  templateUrl: './cell.component.html',
  styleUrls: ['./cell.component.css']
})



export class CellComponent implements OnInit {

  //stores the current value of the cell
  cellValue:string = "";
  constructor(private appService : AppService) {
  }
  ngOnInit(): void {

  }
  ngOnChanges() {
    //retrieves the values left in the DB over API
    this.appService.getValue("https://localhost:5001/api/Sudoku/", this.row , this.col).subscribe(x  => this.cellValue = x[0]) ;
  }
  //Input from the parent table to create all the cells
  @Input() row = 0;
  @Input() col = 0;

  //Sets the value of the current cell
  setValue(setvalue :string) {
    if (typeof setvalue === 'string') {
      this.cellValue = setvalue;
    }

  }

  //function that handles changes on the sudoku Table and commits them to the DB
  handleInput(){
    if(!parseInt(this.cellValue)) {
      this.cellValue ="";
    }
    console.log(this.cellValue.localeCompare("") + ' cell: ' + this.cellValue + ' ' + this.row + ' ' + this.col)
    if (this.cellValue.localeCompare("") == 0) {
      this.appService.pushValue("https://localhost:5001/api/Sudoku/" + this.row + "/" + this.col, "0");
    }
    else
    {
      this.appService.pushValue("https://localhost:5001/api/Sudoku/" + this.row + "/" + this.col, this.cellValue);
    }

  }

}
