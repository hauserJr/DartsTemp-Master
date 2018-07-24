import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { MessageListComponent } from './message-list/message-list.component';

const routes: Routes = [
  { path: 'messageList', component: MessageListComponent },
  { path: '', redirectTo: 'messageList', pathMatch: 'full' },
];

@NgModule(
  {
    exports: [RouterModule],
    imports: [RouterModule.forRoot(routes)],
  }
)

export class AppRoutingModule { }
