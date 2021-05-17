import { Observable } from "rxjs";
import { OptionModel } from "src/Helper/OptionModel";
import { Device } from "src/Models/Device";
import { IBaseService } from "./Base/IBaseService";

export interface IDeviceService extends IBaseService<Device> {
    getAllDevice(): Observable<Array<Device>>;

    getDates(list: Array<Device>): Observable<Array<OptionModel<Date>>>
}
