import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
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
  selector: 'app-DeviceDetails',
  templateUrl: './DeviceDetails.component.html',
  styleUrls: ['./DeviceDetails.component.css']
})
export class DeviceDetailsComponent implements OnInit {

  constructor(
    private deviceTypeService: DeviceTypeService,
    private unitService: UniteService,
    private spinner: NgxSpinnerService,
    private message: ToastService,
    private helper: GeneralHelperService,
    private service: DeviceService,
    private route: ActivatedRoute
  ) { }


  model: Device = new Device();

  ngOnInit() {
    this.getDeviceTypeList();
    this.getUnitList();

    this.route.params.subscribe(params => {
      this.spinner.show();
      this.service.getById(params["deviceId"]).subscribe(x => {
        x.createdDate = new Date(x.createdDate);
        this.model = x;
      },
        err => {
          this.message.showMessage(MessageType.Error, "Hata!", err);
        }, () => {
          this.spinner.hide();
        })

    });
  }

  deviceTypeList: Array<DeviceType>;
  unitList: Array<Unit>;

  framList = this.helper.framList;
  confirmList = this.helper.confirmList;


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

  updateDevice() {
    this.spinner.show();
    this.service.update(this.model).subscribe(x => {
      this.message.showMessage(MessageType.Info, "Başarılı", "Güncelleme Başarılı");
    }, err => {
      this.message.showMessage(MessageType.Error, "Hata!", err);
    }, () => {
      this.spinner.hide();
    })
  }

}
