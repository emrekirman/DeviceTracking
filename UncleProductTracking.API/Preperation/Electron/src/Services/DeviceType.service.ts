import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DeviceType } from 'src/Models/DeviceType';
import { IDeviceTypeService } from 'src/Interfaces/IDeviceTypeService';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DeviceTypeService implements IDeviceTypeService {

  constructor(
    private http: HttpClient
  ) { }


  getAll(): Observable<DeviceType[]> {
    return this.http.get<Array<DeviceType>>('http://localhost:5000/api/DeviceType/getAll');
  }
  delete(id: number) {
    return this.http.get('http://localhost:5000/api/DeviceType/delete?id=' + id);
  }
  update(model: DeviceType): Observable<DeviceType> {
    return this.http.post<DeviceType>('http://localhost:5000/api/DeviceType/update', model);
  }
  getById(id: number): Observable<DeviceType> {
    return this.http.get<DeviceType>('http://localhost:5000/api/DeviceType/getById?id=' + id);
  }

  getOrderDateDesc() {
    return this.http.get<Array<DeviceType>>('http://localhost:5000/api/DeviceType/getOrderDescList');
  }

  create(model: DeviceType) {
    return this.http.post<DeviceType>('http://localhost:5000/api/DeviceType/create', model);
  }

}
