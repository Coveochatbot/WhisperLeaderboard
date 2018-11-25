import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';
import { Message } from './../models/message';
import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { catchError, first } from 'rxjs/operators';
import { throwError, Observable } from 'rxjs';

const ENDPOINT: string = 'https://whisper-megagenial.us-east-1.elasticbeanstalk.com:8081/game/name';
const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json'
    }),
    withCredentials: true
};
@Injectable({
    providedIn: 'root'
})
export class LoginService {
    private localUser: string = 'user';
    private localMessages: string = 'messages';

    public constructor( private router: Router, private http: HttpClient ) {}

    public isConnected(): boolean {
        if (this.getCurrentUser()) return true;
        else return false;
    }

    public connect(user: User): void {
        sessionStorage.setItem(this.localUser, JSON.stringify(user));
        this.sendNameToLeaderBoard(user)
            .pipe(first())
            .subscribe();
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

    private sendNameToLeaderBoard(user: User): Observable<{}> {
        const data = {
            'Type' : user.userType,
            'Name': user.name
        };
        return this.http.post(ENDPOINT, data, httpOptions)
            .pipe(catchError(this.errorHandler));
    }
    
    public errorHandler(error: HttpErrorResponse): any {
        return throwError(error.message || 'Erreur de serveur');
    }
}