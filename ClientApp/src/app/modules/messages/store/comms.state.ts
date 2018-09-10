import { Message } from '../../../shared/interfaces/message';

export interface CommsState {
    comms: CommsStateContainer
};

export interface CommsStateContainer {
    messages: Message[],
    groups: string[]
};