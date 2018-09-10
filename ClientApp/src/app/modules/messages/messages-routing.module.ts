import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { MessageBoardComponent } from './message-board/message-board.component';
import { AuthGuard } from '../../shared/services/auth.guard';

const routes: Routes = [
  { path: '', component: MessageBoardComponent, canActivate: [AuthGuard]}, 
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class MessagesRoutingModule { }
