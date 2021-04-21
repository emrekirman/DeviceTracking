import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { ConfirmationService, MenuItem } from 'primeng/api';
import { MessageType } from 'src/Enums/MessageType.enum';
import { Device } from 'src/Models/Device';
import { DeviceService } from 'src/Services/Device.service';
import { ToastService } from 'src/Services/Toast.service';
import * as moment from 'moment';
import { OptionModel } from 'src/Helper/OptionModel';
import { GeneralHelperService } from 'src/Services/GeneralHelper.service';
import { UniteService } from 'src/Services/Unite.service';
import { DeviceDetailsComponent } from '../DeviceDetails/DeviceDetails.component';
import { Router } from '@angular/router';
import { FileDownloadService } from 'src/Services/File/FileDownload.service';

@Component({
  selector: 'app-Device',
  templateUrl: './Device.component.html',
  styleUrls: ['./Device.component.css'],
  encapsulation: ViewEncapsulation.None,
  providers: [FileDownloadService]
})
export class DeviceComponent implements OnInit {

  constructor(
    private service: DeviceService,
    private spinner: NgxSpinnerService,
    private message: ToastService,
    private helper: GeneralHelperService,
    private unitService: UniteService,
    private confirmationService: ConfirmationService,
    private route: Router,
    private fileDownload: FileDownloadService
  ) { }

  deviceList: Array<Device> = [];

  selectedDevice: Device = new Device();

  contextMenuItems: Array<MenuItem>;

  dates: Array<OptionModel<Date>> = [];

  frams = this.helper.framOptList;
  confirms = this.helper.confirmOptList;
  units: Array<OptionModel<number>>;

  visibleSidebar: boolean = false;

  ngOnInit() {
    moment.locale('tr');
    this.getAllDevice();
    this.getUnits();

    this.contextMenuItems = [
      {
        label: 'Rapor', icon: 'pi pi-fw pi-file-excel', command: () => {
          this.spinner.show();
          this.service.getDeviceReport(this.selectedDevice).subscribe(x => {
            this.spinner.hide();
            this.fileDownload.downloadToLocal(x, "CihazDetay.xlsx");
          }, err => {
            this.spinner.hide();
            this.message.showMessage(MessageType.Error, "Hata!", err);
          })
        }
      },
      {
        label: 'Düzenle', icon: 'pi pi-fw pi-pencil', command: () => {
          this.route.navigate(['updateDevice/' + this.selectedDevice.id]);
        }
      },
      {
        label: 'Sil', icon: 'pi pi-fw pi-trash', command: () => {
          this.deleteConfirm(this.selectedDevice.id);
        }
      }
    ]

  }

  getAllDevice() {
    this.spinner.show();
    this.service.getAllDevice().subscribe(x => {
      this.deviceList = x;
      this.spinner.hide();
      this.getDates();

    }, err => {
      this.spinner.hide();
      this.message.showMessage(MessageType.Error, "Hata!", err);

    });
  }


  getDates() {
    this.spinner.show();
    this.service.getDates(this.deviceList).subscribe(x => {
      this.dates = x;
      this.spinner.hide();
    },
      err => {
        this.spinner.hide();
        this.message.showMessage(MessageType.Error, "Hata!", err);
      });
  }

  getUnits() {
    this.spinner.show();
    this.unitService.GetAllUnitsFromOpt().subscribe(x => {
      this.units = x;
      this.spinner.hide();
    },
      err => {
        this.spinner.hide();
        this.message.showMessage(MessageType.Error, "Hata!", err);
      })
  }

  deleteConfirm(id: number) {
    this.confirmationService.confirm({
      message: "Silmek İstediğinize Emin Misiniz ?",
      icon: "pi pi-trash",
      acceptLabel: "Evet",
      rejectLabel: "Hayır",
      accept: () => {
        this.spinner.show();
        this.service.delete(id).subscribe(x => {
          this.spinner.hide();
          this.getAllDevice();
          this.message.showMessage(MessageType.Info, "Başarılı", "Silme işlemi başarılı");
        },
          err => {
            this.spinner.hide();
            this.message.showMessage(MessageType.Error, "Hata!", err);
          });
      }
    })
  }

  exportExcel() {
    this.spinner.show();
    this.service.getReportList(this.deviceList).subscribe(x => {
      this.fileDownload.downloadToLocal(x, "CihazListesi.xlsx");
    }, err => {
      this.message.showMessage(MessageType.Error, "Hata!", "Raporlama sırasında bir hata oluştu. Hata: " + err);
    }, () => { this.spinner.hide() });
  }

}
