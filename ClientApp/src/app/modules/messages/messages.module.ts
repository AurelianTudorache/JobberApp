import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AngularMaterialComponentsModule } from './../../shared/modules/angular-material-components/angular-material-components.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MessagesRoutingModule } from './messages-routing.module';
import { MessageBoardComponent } from './message-board/message-board.component';
import { HttpClientModule } from '@angular/common/http';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { CommsEffects } from './store/comms.effects';
import { commsReducer } from './store/comms.reducer';
import { AuthGuard } from '../../shared/services/auth.guard';

@NgModule({
  imports: [
    CommonModule,
    FormsModule, ReactiveFormsModule,
    MessagesRoutingModule,
    AngularMaterialComponentsModule,
    StoreModule.forFeature('comms', commsReducer),
    EffectsModule.forFeature([CommsEffects])
  ],
  declarations: [MessageBoardComponent],
  providers: [AuthGuard]
})
export class MessagesModule { }
