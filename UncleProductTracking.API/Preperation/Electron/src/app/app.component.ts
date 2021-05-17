import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import * as moment from 'moment';
import { PrimeNGConfig } from 'primeng/api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AppComponent implements OnInit {
  constructor(
    private primengConfig: PrimeNGConfig
  ) { }
  title = 'Cihaz Takip';

  // exec = require('child_process').execFile;

  ngOnInit() {
    this.primengConfig.ripple = true;

    this.primengConfig.setTranslation({
      dayNames: ["Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar"],
      dayNamesShort: ["Pzt", "Sal", "Çar", "Per", "Cum", "Cumr", "Paz"],
      dayNamesMin: ["Pz", "Sl", "Çr", "Pr", "Cu", "Cm", "Pa"],
      monthNames: ["Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran", "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık  "],
      monthNamesShort: ["Ock", "Şbt", "Mrt", "Nsn", "Mys", "Hzr", "Tem", "Agu", "Eyl", "Ekm", "Ksm", "Arl"],
      today: 'Bugün',
      clear: 'Temizle',
      apply: 'Uygula',
      weekHeader: 'Hafta',
      equals:'Eşittir',
      startsWith:'İle Başlar',
      contains:'İçerir',
      notContains:'İçermez',
      endsWith:'İle Biter',
      notEquals:'Eşit Değildir',
      matchAll:'Hepsini Eşleştir',
      matchAny:'Herhangisiyle Eşleştir',
      dateAfter:'Tarihten Sonra',
      dateBefore:'Tarihten Önce',
      dateIs:'Tarih Eşittir',
      dateIsNot:'Tarih Eşit Değildir',
      addRule:'Kural Ekle',
      removeRule:'Kural Kaldır',
      upload:'Yükle',
      //translations
    });
  }

}
