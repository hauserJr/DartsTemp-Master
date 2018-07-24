import { Component, OnInit } from '@angular/core';

import { AngularTempDataModel } from '../AngularTempDataModel';
import { MessageService } from '../message.service';
@Component({
  selector: 'app-message-list',
  templateUrl: './message-list.component.html',
  styleUrls: ['./message-list.component.css']
})
export class MessageListComponent implements OnInit {
  messages: AngularTempDataModel[];
  constructor(private messageService: MessageService) { }

  ngOnInit() {
    this.getMessages();
  }

  getMessages(): void {
    this.messageService.getMsgs()
      .subscribe(messages => this.messages = messages);

  }
}
