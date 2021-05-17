import { Component, OnInit } from '@angular/core';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { MessageType } from 'src/Enums/MessageType.enum';
import { DeviceType } from 'src/Models/DeviceType';
import { DeviceTypeService } from 'src/Services/DeviceType.service';
import { ToastService } from 'src/Services/Toast.service';
import { DeviceTypeComponent } from '../DeviceType/DeviceType.component';

@Component({
  selector: 'app-DeviceTypeUpdate',
  templateUrl: './DeviceTypeUpdate.component.html',
  styleUrls: ['./DeviceTypeUpdate.component.css']
})
export class DeviceTypeUpdateComponent implements OnInit {

  constructor(
    private service: DeviceTypeService,
    public config: DynamicDialogConfig,
    public ref: DynamicDialogRef,
    private messageService: ToastService,
  ) { }

  deviceType: DeviceType = new DeviceType();
  deviceTypeComponent: DeviceTypeComponent;

  ngOnInit() {
    this.deviceTypeComponent = this.config.data.Component;

    this.service.getById(this.config.data.id).subscribe(x => {
      this.deviceType = x;
    });
  }

  updateDeviceType() {
    this.service.update(this.deviceType).subscribe(x => {

      this.service.getAll().subscribe(x => {
        this.deviceTypeComponent.deviceTypeList = x;
      }, err => {
        this.messageService.showMessage(MessageType.Error, "Hata!", err);
      });

      this.ref.close();
      this.messageService.showMessage(MessageType.Success, "Başarılı", "Güncelleme Başarılı");
    }, err => { });
  }

}
