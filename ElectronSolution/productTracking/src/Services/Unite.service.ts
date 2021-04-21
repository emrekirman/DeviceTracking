import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OptionModel } from 'src/Helper/OptionModel';
import { IUnitService } from 'src/Interfaces/IUnitService';
import { Device } from 'src/Models/Device';
import { Unit } from 'src/Models/Unit';

@Injectable({
  providedIn: 'root'
})
export class UniteService implements IUnitService {

  constructor(
    private http: HttpClient
  ) { }


  GetAllUnitsFromOpt() {
    return this.http.get<Array<OptionModel<number>>>('http://localhost:5000/api/Unit/getAllUnitsFromOpt');
  }


  getById(id: number) {
    return this.http.get<Unit>('http://localhost:5000/api/Unit/getById?id=' + id);
  }

  create(model: Unit) {
    return this.http.post<Unit>('http://localhost:5000/api/Unit/create', model);
  }

  getAll() {
    return this.http.get<Array<Unit>>('http://localhost:5000/api/Unit/getAll');
  }

  delete(id: number) {
    return this.http.get('http://localhost:5000/api/Unit/delete?id=' + id);
  }

  update(model: Unit) {
    return this.http.post<Unit>('http://localhost:5000/api/Unit/update', model);
  }

}
