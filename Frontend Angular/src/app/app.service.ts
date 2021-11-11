import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable()
export class AppService {

  constructor(private http: HttpClient) {
  }


  //Gets the value of a cell from the API
  public getValue(url : string, row : number, col :number) : Observable<string[]> {
    return this.http.get<string[]>(url + row + "/" + col);
  }

  //Retrieves the solution of the current sudoku table as a string from the API
  public getSolution(url : string) : Observable<string[]> {
    return this.http.get<string[]>(url);
  }

  //Instructs the API to delete the entire current table it stores
  public clearTable(url : string) {
    return this.http.put<string[]>(url,"").subscribe(result => {});
  }

  //Adds or Updates a value of the sudoku table
  public pushValue(url : string, value : string) {
    console.log("send data: " + value);
    this.http.put<string>(url + "/" + value,{}).subscribe(result => {});
  }


}
