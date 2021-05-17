import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { MenubarModule } from 'primeng/menubar';
import { PanelModule } from 'primeng/panel';
import { InputTextModule } from 'primeng/inputtext';
import { TableModule } from 'primeng/table';
import { NgxSpinnerModule } from "ngx-spinner";
import { FormsModule } from '@angular/forms';
import { ButtonModule } from 'primeng/button';
import { ConfirmPopupModule } from 'primeng/confirmpopup';
import { ToastModule } from 'primeng/toast';
import { TooltipModule } from 'primeng/tooltip';
import { DropdownModule } from 'primeng/dropdown';




import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavigationBarComponent } from './NavigationBar/NavigationBar.component';
import { DeviceTypeComponent } from './Tanimlamalar/DeviceType/DeviceType.component';
import { UnitComponent } from './Tanimlamalar/Unit/Unit.component';
import { DeviceComponent } from './Device/Device.component';
import { HttpClientModule } from '@angular/common/http';
import { DynamicDialogModule } from 'primeng/dynamicdialog';
import { CalendarModule } from 'primeng/calendar';
import { EditorModule } from 'primeng/editor';
import { ContextMenuModule } from 'primeng/contextmenu';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { SidebarModule } from 'primeng/sidebar';


import { DeviceTypeService } from 'src/Services/DeviceType.service';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { UnitUpdateComponent } from './Tanimlamalar/UnitUpdate/UnitUpdate.component';
import { DeviceTypeUpdateComponent } from './Tanimlamalar/DeviceTypeUpdate/DeviceTypeUpdate.component';
import { DeviceService } from 'src/Services/Device.service';
import { FramPipe } from 'src/Pipes/Fram.pipe';
import { ConfirmationTypePipe } from 'src/Pipes/ConfirmationType.pipe';
import { DeviceOperationsComponent } from './Tanimlamalar/DeviceOperations/DeviceOperations.component';
import { GeneralHelperService } from 'src/Services/GeneralHelper.service';
import { DeviceDetailsComponent } from './DeviceDetails/DeviceDetails.component';



@NgModule({
  declarations: [
    AppComponent,
    NavigationBarComponent,
    DeviceTypeComponent,
    DeviceComponent,
    UnitComponent,
    UnitUpdateComponent,
    DeviceTypeUpdateComponent,
    FramPipe,
    ConfirmationTypePipe,
    DeviceOperationsComponent,
    DeviceDetailsComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    HttpClientModule,
    MenubarModule,
    PanelModule,
    InputTextModule,
    TableModule,
    NgxSpinnerModule,
    FormsModule,
    ButtonModule,
    ConfirmPopupModule,
    ToastModule,
    DynamicDialogModule,
    TooltipModule,
    DropdownModule,
    CalendarModule,
    EditorModule,
    ContextMenuModule,
    ConfirmDialogModule,
    SidebarModule
  ],
  providers: [
    DeviceTypeService,
    ConfirmationService,
    MessageService,
    DeviceService,
    GeneralHelperService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
