import { catchError, map, switchMap } from 'rxjs/operators';

import { Injectable } from '@angular/core';
import { Actions, Effect } from '@ngrx/effects';
import { Observable, of } from 'rxjs';

import * as commsAction from './comms.action';
import { CommsService } from '../../../shared/services/comms.service';


@Injectable()
export class CommsEffects {

    @Effect() sendNewItem$ = this.actions$.ofType<commsAction.SendMessageAction>(commsAction.SEND_MESSAGE).pipe(
        switchMap((action: commsAction.SendMessageAction) => {
            this.commsService.send(action.message);
            return of(new commsAction.SendMessageActionComplete(action.message));
        }));

    @Effect() joinGroup$ = this.actions$.ofType<commsAction.JoinGroupAction>(commsAction.JOIN_GROUP).pipe(
        switchMap((action: commsAction.JoinGroupAction ) => {
            this.commsService.joinGroup(action.group);
            return of(new commsAction.JoinGroupActionComplete(action.group));
        }));

    @Effect() leaveGroup$ = this.actions$.ofType<commsAction.LeaveGroupAction>(commsAction.LEAVE_GROUP).pipe(
        switchMap((action: commsAction.LeaveGroupAction) => {
            this.commsService.leaveGroup(action.group);
            return of(new commsAction.LeaveGroupActionComplete(action.group));
        }));


    @Effect() getAllGroups$ = this.actions$.ofType(commsAction.SELECTALL_GROUPS).pipe(
        switchMap(() => {
            return this.commsService.getAllGroups().pipe(
                map((data: string[]) => {
                    return new commsAction.SelectAllGroupsActionComplete(data);
                }),
                catchError((error: any) => of(error)
                ))
        }));

    constructor(
        private commsService: CommsService,
        private actions$: Actions
    ) { }
}