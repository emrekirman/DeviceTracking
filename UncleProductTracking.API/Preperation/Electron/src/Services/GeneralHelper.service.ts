import { Injectable } from '@angular/core';
import { OptionModel } from 'src/Helper/OptionModel';

@Injectable({
  providedIn: 'root'
})
export class GeneralHelperService {

  constructor() { }

  framList = [
    { title: "Var", id: 1 },
    { title: "Yok", id: 2 }
  ]
  confirmList= [
    { title: "Evet", id: 1 },
    { title: "Hayır", id: 2 }
  ]

  framOptList: Array<OptionModel<number>> = [
    { label: "Var", value: 1 },
    { label: "Yok", value: 2 }
  ]

  confirmOptList: Array<OptionModel<number>> = [
    { label: "Var", value: 1 },
    { label: "Yok", value: 2 }
  ]
}
