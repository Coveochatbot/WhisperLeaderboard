import { Message } from './../models/message';
import { UserType } from './../models/usertype';
import { User } from './../models/user';
import { LoginService } from './../services/login.service';
import { SuggestionService } from './../services/suggestion.service';
import { Component, OnInit } from '@angular/core';
import { Suggestion } from '../models/suggestion';
import { first } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Component({
    selector: 'whisper-main',
    templateUrl: './whisper.component.html',
    styleUrls: ['./whisper.component.css']
})
export class WhisperComponent implements OnInit {
    public userLogged: User;
    public suggestion: Suggestion;
    public chatInput: string;
    
    constructor(private loginService: LoginService, private suggestionService: SuggestionService) {
        this.suggestion = new Suggestion();
        this.chatInput = '';
    }

    public ngOnInit(): void {
        this.userLogged = this.loginService.getCurrentUser();
        this.suggestionService.getSuggestion(this.userLogged.id)
            .subscribe((res: Suggestion) => this.suggestion = res);
    }

    public onSuggestionClicked(agentInput: string): void {
        this.chatInput = agentInput;
    }

    public messageSent(message: string): void {
        const aMessage: Message = JSON.parse(message);
        this.suggestionService.getSuggestionWithQuery(aMessage.content, aMessage.from, this.userLogged.id)
            .pipe(first())
            .subscribe((res: Suggestion) => {
                this.suggestion = res;
            });
    }

    public calculateClass(): any {
        if (environment.userType === UserType.AGENT)
            return {'left-section': true };
        return {'left-section-user': true };
    }
}
