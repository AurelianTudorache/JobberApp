import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable, Inject } from '@angular/core';
import { Observable } from 'rxjs';

import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';
import { Message } from '../../shared/interfaces/message';
import { Store } from '@ngrx/store';
import * as CommsActions from '../../modules/messages/store/comms.action';

@Injectable()
export class CommsService {

    private _hubConnection: HubConnection | undefined;
    private actionUrl: string;
    private headers: HttpHeaders;

    constructor(private http: HttpClient,
        private store: Store<any>,
        @Inject('BASE_URL') private baseUrl: string
    ) {
        this.init();
        this.actionUrl = 'api/employer/jobgroups';

        this.headers = new HttpHeaders();
        this.headers = this.headers.set('Content-Type', 'application/json');
        this.headers = this.headers.set('Accept', 'application/json');
    }

    send(message: Message): Message {
        if (this._hubConnection) {
            this._hubConnection.invoke('Send', message);
        }
        return message;
    }

    joinGroup(group: string): void {
        if (this._hubConnection) {
            this._hubConnection.invoke('JoinGroup', group);
        }
    }

    leaveGroup(group: string): void {
        if (this._hubConnection) {
            this._hubConnection.invoke('LeaveGroup', group);
        }
    }

    getAllGroups(): Observable<string[]> {
        return this.http.get<string[]>(this.baseUrl + this.actionUrl, { headers: this.headers });
    }

    private init() {

        // this._hubConnection = new HubConnection(this.baseUrl + 'messages');
        this._hubConnection = (new HubConnectionBuilder()).withUrl(this.baseUrl + 'messages').build();

        this._hubConnection.on('Send', (message: Message) => {
            this.store.dispatch(new CommsActions.ReceivedMessageAction(message));
        });

        this._hubConnection.on('JoinGroup', (data: string) => {
            console.log('recieved data from the hub');
            console.log(data);
            this.store.dispatch(new CommsActions.ReceivedGroupJoinedAction(data));
        });

        this._hubConnection.on('LeaveGroup', (data: string) => {
            this.store.dispatch(new CommsActions.ReceivedGroupLeftAction(data));
        });

        this._hubConnection.on('History', (message: Message[]) => {
            console.log('recieved history from the hub');
            console.log(message);
            this.store.dispatch(new CommsActions.ReceivedGroupHistoryAction(message));
        });

        this._hubConnection.start()
            .then(() => {
                console.log('Hub connection started')
            })
            .catch(() => {
                console.log('Error while establishing connection')
            });
    }

}