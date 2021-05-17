import { Injectable } from '@angular/core';
import { Component } from '@angular/core';
import { MessageService } from 'primeng/api';
import { MessageType } from 'src/Enums/MessageType.enum';

@Injectable({
  providedIn: 'root'
})
export class ToastService {

  constructor(
    private messageService: MessageService
  ) { }

  showMessage(messageType: MessageType, title: string, detail: string) {
    this.messageService.add({ severity: messageType, summary: title, detail: detail });
  }

}
