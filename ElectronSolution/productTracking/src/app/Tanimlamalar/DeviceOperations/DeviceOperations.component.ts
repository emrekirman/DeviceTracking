import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { MessageType } from 'src/Enums/MessageType.enum';
import { Device } from 'src/Models/Device';
import { DeviceType } from 'src/Models/DeviceType';
import { Unit } from 'src/Models/Unit';
import { DeviceService } from 'src/Services/Device.service';
import { DeviceTypeService } from 'src/Services/DeviceType.service';
import { GeneralHelperService } from 'src/Services/GeneralHelper.service';
import { ToastService } from 'src/Services/Toast.service';
import { UniteService } from 'src/Services/Unite.service';

@Component({
  selector: 'app-DeviceOperations',
  templateUrl: './DeviceOperations.component.html',
  styleUrls: ['./DeviceOperations.component.css']
})
export class DeviceOperationsComponent implements OnInit {

  constructor(
    private deviceTypeService: DeviceTypeService,
    private unitService: UniteService,
    private spinner: NgxSpinnerService,
    private message: ToastService,
    private helper: GeneralHelperService,
    private service: DeviceService
  ) { }

  model: Device = new Device();

  deviceTypeList: Array<DeviceType>;
  unitList: Array<Unit>;

  text2:string="";

  framList = this.helper.framList;
  confirmList = this.helper.confirmList;

  ngOnInit() {
    this.getDeviceTypeList();
    this.getUnitList();
  }

  createDevice() {
    this.spinner.show();
    this.service.create(this.model).subscribe(x => {
      this.spinner.hide();
      this.message.showMessage(MessageType.Success, "Başarılı", "Cihaz Ekleme Başarılı.");
      this.model = new Device();
    }, err => {
      this.spinner.hide();
      this.message.showMessage(MessageType.Error, "Hata!", err);
      console.log(err.errors.Descreption[0]);
    })
  }



  getDeviceTypeList() {
    this.spinner.show();
    this.deviceTypeService.getAll().subscribe(x => {
      this.deviceTypeList = x;
      this.spinner.hide();
    }, err => {
      this.spinner.hide();
      this.message.showMessage(MessageType.Error, "Hata!", err);
    });
  }

  getUnitList() {
    this.spinner.show();
    this.unitService.getAll().subscribe(x => {
      this.unitList = x;
      this.spinner.hide();
    }, err => {
      this.spinner.hide();
      this.message.showMessage(MessageType.Error, "Hata!", err);
    });
  }

}
