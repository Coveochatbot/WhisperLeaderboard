import { LoginService } from './login.service';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { Observer } from 'rxjs/Observer';
import { Message } from '../models/message';
import { Event } from '../models/event';
import { environment } from '../../environments/environment';
import * as socketIo from 'socket.io-client';

const SERVER_URL = environment.SOCKET_ENDPOINT;

@Injectable()
export class SocketService {
    private socket: any;
    constructor(private loginService: LoginService) {      
    }
    public initSocket(): void {
        this.socket = socketIo(SERVER_URL);
        this.onNew();
    }

    public send(message: Message): void {
        this.socket.emit('message', message);
    }

    private onNew(): void {  
        this.socket.on('new', () => {
            this.loginService.disconnect();
        });
    }
    
    public onMessage(): Observable<Message> {
        return new Observable<Message>(observer => {
            this.socket.on('message', (data: Message) => observer.next(data));
        });
    }

    public onEvent(event: Event): Observable<any> {
        return new Observable<Event>(observer => {
            this.socket.on(event, () => observer.next());
        });
    }
}