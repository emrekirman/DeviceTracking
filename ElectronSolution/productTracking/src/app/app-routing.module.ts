import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DeviceComponent } from './Device/Device.component';
import { DeviceDetailsComponent } from './DeviceDetails/DeviceDetails.component';
import { DeviceOperationsComponent } from './Tanimlamalar/DeviceOperations/DeviceOperations.component';
import { DeviceTypeComponent } from './Tanimlamalar/DeviceType/DeviceType.component';
import { UnitComponent } from './Tanimlamalar/Unit/Unit.component';

const routes: Routes = [
  { path: '', component: DeviceComponent },
  { path: 'deviceType', component: DeviceTypeComponent },
  { path: 'unit', component: UnitComponent },
  { path: 'addDevice', component: DeviceOperationsComponent },
  { path: 'updateDevice/:deviceId', component: DeviceDetailsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
