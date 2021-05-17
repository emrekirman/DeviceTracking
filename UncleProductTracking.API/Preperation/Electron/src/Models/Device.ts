import { ConfirmationType } from "src/Enums/ConfirmationType.enum";
import { FramType } from "src/Enums/FramType.enum";
import { BaseModel } from "./Base/BaseModel";
import { DeviceType } from "./DeviceType";
import { Unit } from "./Unit";

export class Device extends BaseModel {

    constructor() {
        super();
    }

    serialNumber: string;

    readerSerialNumber: string;

    ipNumber: string;

    fault: string;

    descreption: string;

    deviceTypeId: number;

    unitId: number;

    fram: FramType;

    confirmation: ConfirmationType;

    unit: Unit;

    deviceType: DeviceType;

    createdDate: Date
}
