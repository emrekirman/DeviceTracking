import { Component, OnInit } from '@angular/core';
import { NgxSpinnerService } from 'ngx-spinner';
import { Unit } from 'src/Models/Unit';
import { UniteService } from 'src/Services/Unite.service';
import { ConfirmationService } from 'primeng/api';
import { ToastService } from 'src/Services/Toast.service';
import { MessageType } from 'src/Enums/MessageType.enum';
import { DialogService } from 'primeng/dynamicdialog';
import { UnitUpdateComponent } from '../UnitUpdate/UnitUpdate.component';

@Component({
  selector: 'app-Unit',
  templateUrl: './Unit.component.html',
  styleUrls: ['./Unit.component.css'],
  providers: [DialogService]
})
export class UnitComponent implements OnInit {

  constructor(
    private service: UniteService,
    private spinner: NgxSpinnerService,
    private confirmationService: ConfirmationService,
    private messageService: ToastService,
    public dialogService: DialogService
  ) { }

  units: Array<Unit> = [];
  unit: Unit = new Unit();

  ngOnInit() {
    this.getUnits();
  }



  getUnits() {
    this.spinner.show();
    this.service.getAll().subscribe(x => {
      this.units = x;
      this.spinner.hide();
    }, err => {
      this.spinner.hide();
    });
  }

  createUnit() {
    this.spinner.show();
    this.service.create(this.unit).subscribe(x => {
      this.spinner.hide();
      this.getUnits();
      this.messageService.showMessage(MessageType.Success, "Başarılı", "Ekleme Başarılı");
    }, err => {
      this.spinner.hide();
    });
  }

  delete(id: number) {
    this.spinner.show();
    this.service.delete(id).subscribe(x => {
      this.getUnits();
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
    const ref = this.dialogService.open(UnitUpdateComponent, {
      header: "Bölge Güncelle",
      width: '70%',
      data: {
        id: id,
        Component: this
      }
    });
  }
}
