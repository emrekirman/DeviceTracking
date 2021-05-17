import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { OptionModel } from 'src/Helper/OptionModel';
import { IDeviceService } from 'src/Interfaces/IDeviceService';
import { Device } from 'src/Models/Device';

@Injectable({
  providedIn: 'root'
})
export class DeviceService implements IDeviceService {

  constructor(
    private http: HttpClient
  ) { }


  getDates(list: Array<Device>) {
    return this.http.post<Array<OptionModel<Date>>>('http://localhost:5000/api/Device/getDates', list);
  }

  getReportList(list: Array<Device>) {
    return this.http.post('http://localhost:5000/api/Device/getReportList',list, { responseType: 'blob' });
  }

  getDeviceReport(model: Device) {
    return this.http.post('http://localhost:5000/api/Device/getDeviceReport',model, { responseType: 'blob' });
  }


  getAllDevice() {
    // return this.http.get<Array<Device>>('https://localhost:44343/api/Device/getAllDevice');
    return this.http.get<Array<Device>>('http://localhost:5000/api/Device/getAllDevice');
  }

  create(model: Device) {
    model.createdDate.setDate(model.createdDate.getDate() + 1);
    return this.http.post<Device>('http://localhost:5000/api/Device/create', model);
  }
  getAll() {
    return this.http.get<Array<Device>>('http://localhost:5000/api/Device/getAll');
  }
  delete(id: number) {
    return this.http.get('http://localhost:5000/api/Device/delete/' + id);
  }
  update(model: Device) {
    model.createdDate.setDate(model.createdDate.getDate() + 1);
    return this.http.post<Device>('http://localhost:5000/api/Device/update', model);
  }
  getById(id: number) {
    return this.http.get<Device>('http://localhost:5000/api/Device/getById/' + id);
  }

}
