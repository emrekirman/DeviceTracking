import { Observable } from "rxjs";
import { DeviceType } from "src/Models/DeviceType";
import { IBaseService } from "./Base/IBaseService";

export interface IDeviceTypeService extends IBaseService<DeviceType> {
    
    getOrderDateDesc(): Observable<Array<DeviceType>>
}
