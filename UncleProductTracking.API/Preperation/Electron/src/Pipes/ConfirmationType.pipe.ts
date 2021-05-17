import { Pipe, PipeTransform } from '@angular/core';
import { ConfirmationType } from 'src/Enums/ConfirmationType.enum';

@Pipe({
  name: 'ConfirmationType'
})
export class ConfirmationTypePipe implements PipeTransform {

  transform(value: ConfirmationType, args?: any): any {
    let retval: string;

    if (value == ConfirmationType.Yes) {
      retval = "Evet"
    }
    else if (value == ConfirmationType.No) {
      retval = "Hayır"
    }
    return retval;
  }

}
