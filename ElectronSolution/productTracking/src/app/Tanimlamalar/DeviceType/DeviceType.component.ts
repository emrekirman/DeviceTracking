import { Component, OnInit } from '@angular/core';
import { DeviceType } from 'src/Models/DeviceType';
import { DeviceTypeService } from 'src/Services/DeviceType.service';
import { NgxSpinnerService } from "ngx-spinner";
import { ConfirmationService } from 'primeng/api';
import { ToastService } from 'src/Services/Toast.service';
import { DialogService } from 'primeng/dynamicdialog';
import { MessageType } from 'src/Enums/MessageType.enum';
import { UnitUpdateComponent } from '../UnitUpdate/UnitUpdate.component';
import { DeviceTypeUpdateComponent } from '../DeviceTypeUpdate/DeviceTypeUpdate.component';



@Component({
  selector: 'app-DeviceType',
  templateUrl: './DeviceType.component.html',
  styleUrls: ['./DeviceType.component.css'],
  providers: [DialogService]
})
export class DeviceTypeComponent implements OnInit {

  constructor(
    private service: DeviceTypeService,
    private spinner: NgxSpinnerService,
    private confirmationService: ConfirmationService,
    private messageService: ToastService,
    public dialogService: DialogService,
  ) { }

  deviceTypeList: Array<DeviceType> = [];
  device: DeviceType = new DeviceType();

  ngOnInit() {
    this.getDeviceTypes();
  }

  getDeviceTypes() {
    this.spinner.show();
    this.service.getOrderDateDesc().subscribe(x => {
      this.deviceTypeList = x;
      this.spinner.hide();
    },
      err => {
        this.spinner.hide();
      });
  }

  createDeviceType() {
    this.spinner.show();
    this.service.create(this.device).subscribe(x => {
      this.getDeviceTypes();
      this.spinner.hide();
      this.messageService.showMessage(MessageType.Success, "Başarılı", "Ekleme Başarılı");
    }, err => {
      this.spinner.hide();
    })
  }

  delete(id: number) {
    this.spinner.show();
    this.service.delete(id).subscribe(x => {
      this.getDeviceTypes();
      this.spinner.hide();
      this.messageService.showMessage(MessageType.Info, "Başarılı", "Silme Başarılı");
    }, err => {
      this.spinner.hide();
      this.messageService.showMessage(MessageType.Error, "Sorun Oluştu", err);
    });
  }

  confirmDelete(event: Event, id: number) {
    this.confirmationService.confirm({
      target: event.target,
      message: "Silmek istediğinize emin misiniz ?",
      icon: "pi pi-trash",
      acceptLabel: "Evet",
      rejectLabel: "Hayır",
      accept: () => {
        this.delete(id);
      }
    });
  }

  updateDialog(id: number) {
    const ref = this.dialogService.open(DeviceTypeUpdateComponent, {
      header: "Cihaz Tipi Güncelle",
      width: '70%',
      data: {
        id: id,
        Component: this
      }
    });
  }

}
