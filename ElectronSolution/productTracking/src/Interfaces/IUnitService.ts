import { Observable } from "rxjs";
import { OptionModel } from "src/Helper/OptionModel";
import { Unit } from "src/Models/Unit";
import { IBaseService } from "./Base/IBaseService";

export interface IUnitService extends IBaseService<Unit> {
    
    GetAllUnitsFromOpt():Observable<Array<OptionModel<number>>>;
}
