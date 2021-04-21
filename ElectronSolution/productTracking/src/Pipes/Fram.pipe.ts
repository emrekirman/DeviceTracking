import { Pipe, PipeTransform } from '@angular/core';
import { FramType } from 'src/Enums/FramType.enum';

@Pipe({
  name: 'Fram'
})
export class FramPipe implements PipeTransform {

  transform(value: FramType, args?: any): any {
    let retval: string;
    if (value == FramType.Available) {
      retval = "Var";
    }
    else if (value == FramType.Not) {
      retval = "Yok"
    }
    return retval;
  }

}
