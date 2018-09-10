import { Action } from '@ngrx/store';
import { Message } from '../../../shared/interfaces/message';

export const JOIN_GROUP = '[comms] JOIN_GROUP';
export const LEAVE_GROUP = '[comms] LEAVE_GROUP';
export const JOIN_GROUP_COMPLETE = '[comms] JOIN_GROUP_COMPLETE';
export const LEAVE_GROUP_COMPLETE = '[comms] LEAVE_GROUP_COMPLETE';
export const SEND_MESSAGE = '[comms] SEND_MESSAGE';
export const SEND_MESSAGE_COMPLETE = '[comms] SEND_MESSAGE_COMPLETE';
export const RECEIVED_MESSAGE = '[comms] RECEIVED_MESSAGE';
export const RECEIVED_GROUP_JOINED = '[comms] RECEIVED_GROUP_JOINED';
export const RECEIVED_GROUP_LEFT = '[comms] RECEIVED_GROUP_LEFT';

export const RECEIVED_GROUP_HISTORY = '[comms] RECEIVED_GROUP_HISTORY';


export const SELECTALL_GROUPS = '[comms] Select All Groups';
export const SELECTALL_GROUPS_COMPLETE = '[comms] Select All Groups Complete';

export class JoinGroupAction implements Action {
    readonly type = JOIN_GROUP;

    constructor(public group: string) { }
}

export class LeaveGroupAction implements Action {
    readonly type = LEAVE_GROUP;

    constructor(public group: string) { }
}


export class JoinGroupActionComplete implements Action {
    readonly type = JOIN_GROUP_COMPLETE;

    constructor(public group: string) { }
}

export class LeaveGroupActionComplete implements Action {
    readonly type = LEAVE_GROUP_COMPLETE;

    constructor(public group: string) { }
}
export class SendMessageAction implements Action {
    readonly type = SEND_MESSAGE;

    constructor(public message: Message) { }
}

export class SendMessageActionComplete implements Action {
    readonly type = SEND_MESSAGE_COMPLETE;

    constructor(public message: Message) { }
}

export class ReceivedMessageAction implements Action {
    readonly type = RECEIVED_MESSAGE;

    constructor(public message: Message) { }
}

export class ReceivedGroupJoinedAction implements Action {
    readonly type = RECEIVED_GROUP_JOINED;

    constructor(public group: string) { }
}

export class ReceivedGroupLeftAction implements Action {
    readonly type = RECEIVED_GROUP_LEFT;

    constructor(public group: string) { }
}

export class ReceivedGroupHistoryAction implements Action {
    readonly type = RECEIVED_GROUP_HISTORY;

    constructor(public messages: Message[]) { }
}

export class SelectAllGroupsAction implements Action {
    readonly type = SELECTALL_GROUPS;

    constructor() { }
}

export class SelectAllGroupsActionComplete implements Action {
    readonly type = SELECTALL_GROUPS_COMPLETE;

    constructor(public groups: string[]) { }
}

export type Actions
    = JoinGroupAction
    | LeaveGroupAction
    | JoinGroupActionComplete
    | LeaveGroupActionComplete
    | SendMessageAction
    | SendMessageActionComplete
    | ReceivedMessageAction
    | ReceivedGroupJoinedAction
    | ReceivedGroupLeftAction
    | ReceivedGroupHistoryAction
    | SelectAllGroupsAction
    | SelectAllGroupsActionComplete;