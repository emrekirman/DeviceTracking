import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { MessageType } from 'src/Enums/MessageType.enum';
import { Unit } from 'src/Models/Unit';
import { ToastService } from 'src/Services/Toast.service';
import { UniteService } from 'src/Services/Unite.service';
import { UnitComponent } from '../Unit/Unit.component';

@Component({
  selector: 'app-UnitUpdate',
  templateUrl: './UnitUpdate.component.html',
  styleUrls: ['./UnitUpdate.component.css']
})
export class UnitUpdateComponent implements OnInit {

  constructor(
    private service: UniteService,
    public config: DynamicDialogConfig,
    private router: Router,
    public ref: DynamicDialogRef,
    private messageService: ToastService,
  ) { }

  unit: Unit = new Unit();
  unitComponent: UnitComponent;

  ngOnInit() {
    this.unitComponent = this.config.data.Component;

    this.service.getById(this.config.data.id).subscribe(x => {
      this.unit = x;
    });
  }

  updateUnit() {
    this.service.update(this.unit).subscribe(x => {

      this.service.getAll().subscribe(x => {
        this.unitComponent.units = x;
      }, err => {
        this.messageService.showMessage(MessageType.Error, "Hata!", err);
      });

      this.ref.close();
      this.messageService.showMessage(MessageType.Success, "Başarılı", "Güncelleme Başarılı");
    }, err => { });
  }

}
