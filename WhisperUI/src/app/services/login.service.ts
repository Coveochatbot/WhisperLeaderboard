import { Router } from '@angular/router';
import { Message } from './../models/message';
import { Injectable } from '@angular/core';
import { User } from '../models/user';

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    private localUser: string = 'user';
    private localMessages: string = 'messages';

    public constructor( private router: Router) {}

    public isConnected(): boolean {
        if (this.getCurrentUser()) return true;
        else return false;
    }

    public connect(user: User): void {
        sessionStorage.setItem(this.localUser, JSON.stringify(user));
    }

    public disconnect(): void {
        sessionStorage.removeItem(this.localUser);
        sessionStorage.removeItem(this.localMessages);
        this.router.navigate(['/login']);
    }

    public getCurrentUser(): User {
        return JSON.parse(sessionStorage.getItem(this.localUser));
    }

    public saveMessages(message: Message): void {
        const messages: Array<Message> = this.getOldMessages();
        messages.push(message);
        sessionStorage.setItem(this.localMessages, JSON.stringify(messages));
    }

    public getOldMessages(): Array<Message> {
        const messagesStored: any = sessionStorage.getItem(this.localMessages);
        if (messagesStored)
            return JSON.parse(messagesStored);

        return new Array<Message>();
    }
}