import { CommsState } from './comms.state';
import * as commsAction from './comms.action';

export const initialState: CommsState = {
    comms: {
        messages: [],
        groups: ['IT', 'global', 'sport']
    }
};

export function commsReducer(state = initialState, action: commsAction.Actions): CommsState {
    switch (action.type) {

        case commsAction.RECEIVED_GROUP_JOINED:
            return Object.assign({}, state, {
                comms: {
                    messages: state.comms.messages,
                    groups: (state.comms.groups.indexOf(action.group) > -1) ? state.comms.groups : state.comms.groups.concat(action.group)
                }
            });

        case commsAction.RECEIVED_MESSAGE:
            return Object.assign({}, state, {
                comms: {
                    messages: state.comms.messages.concat(action.message),
                    groups: state.comms.groups
                }
            });

        case commsAction.RECEIVED_GROUP_HISTORY:
            return Object.assign({}, state, {
                comms: {
                    messages: action.messages,
                    groups: state.comms.groups
                }
            });

        case commsAction.RECEIVED_GROUP_LEFT:
            const data = [];
            for (const entry of state.comms.groups) {
                if (entry !== action.group) {
                    data.push(entry);
                }
            }
            console.log(data);
            return Object.assign({}, state, {
                comms: {
                    messages: state.comms.messages,
                    groups: data
                }
            });

        case commsAction.SELECTALL_GROUPS_COMPLETE:
            return Object.assign({}, state, {
                comms: {
                    messages: state.comms.messages,
                    groups: action.groups
                }
            });

        default:
            return state;

    }
}