import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Store } from '@ngrx/store';
import { CommsState } from '../store/comms.state';
import * as CommsActions from '../store/comms.action';
import { Message } from '../../../shared/interfaces/message';
import { AuthService } from '../../../shared/services/auth.service';


@Component({
  selector: 'app-message-board',
  templateUrl: './message-board.component.html',
  styleUrls: ['./message-board.component.css']
})
export class MessageBoardComponent implements OnInit {

    public async: any;
    message: Message;
    messages: Message[] = [];
    group = '';
    author = '';
    messagesState$: Observable<CommsState>;
    groups = [];

    constructor(private store: Store<any>, private auth: AuthService) {

        this.messagesState$ = this.store.select<CommsState>(state => state.comms);

        this.store.select<CommsState>(state => state.comms).subscribe((o: CommsState) => {
            this.messages = o.comms.messages;
        });

        this.message = new Message();
        this.message.AddData('', this.author, this.group);
    }

    public sendMessage(): void {
        this.message.jobGroup = this.group;
        this.message.author = this.auth.getAuth()!.displayName;
        this.store.dispatch(new CommsActions.SendMessageAction(this.message));
    }

    public join(): void {
        this.store.dispatch(new CommsActions.JoinGroupAction(this.group));
    }

    public leave(): void {
        this.store.dispatch(new CommsActions.LeaveGroupAction(this.group));
    }

    ngOnInit() {
        console.log('go');
        this.store.dispatch(new CommsActions.SelectAllGroupsAction());
    }
}
