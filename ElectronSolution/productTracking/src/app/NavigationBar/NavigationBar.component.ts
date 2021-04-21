import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-NavigationBar',
  templateUrl: './NavigationBar.component.html',
  styleUrls: ['./NavigationBar.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class NavigationBarComponent implements OnInit {

  constructor() { }

  items: MenuItem[] = [];

  ngOnInit() {
    this.items = [
      {
        label: 'Ana Sayfa',
        icon: 'pi pi-home',
        routerLink: '/'
      },
      {
        label: 'Tanımlamalar',
        icon: 'pi pi-plus',
        items: [
          {
            label: 'Cihaz Tipi',
            icon: 'pi pi-tablet',
            routerLink: '/deviceType',
          },
          {
            label: 'Bölge',
            icon: 'pi pi-compass',
            routerLink: '/unit',
          }
        ]
      },
      {
        label: 'Cihaz Ekle',
        icon: 'pi pi-tablet',
        routerLink: '/addDevice'
      },
    ];
  }

}
