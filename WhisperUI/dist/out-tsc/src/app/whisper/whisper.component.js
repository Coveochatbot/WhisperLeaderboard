var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { LoginService } from './../services/login.service';
import { SuggestionService } from './../services/suggestion.service';
import { Component } from '@angular/core';
import { Suggestion } from '../models/suggestion';
import { first } from 'rxjs/operators';
import { environment } from '../../environments/environment';
var WhisperComponent = /** @class */ (function () {
    function WhisperComponent(loginService, suggestionService) {
        this.loginService = loginService;
        this.suggestionService = suggestionService;
        this.userType = environment.userType;
        this.suggestion = new Suggestion();
        this.chatInput = '';
    }
    WhisperComponent.prototype.ngOnInit = function () {
        var _this = this;
        this._userLogged = this.loginService.getCurrentUser();
        this.suggestionService.getSuggestion(this._userLogged.id)
            .subscribe(function (res) { return _this.suggestion = res; });
    };
    WhisperComponent.prototype.onSuggestionClicked = function (agentInput) {
        this.chatInput = agentInput;
    };
    WhisperComponent.prototype.messageSent = function (message) {
        var _this = this;
        this.suggestionService.getSuggestionWithQuery(message, this._userLogged.id)
            .pipe(first())
            .subscribe(function (res) { return _this.suggestion = res; });
    };
    WhisperComponent = __decorate([
        Component({
            selector: 'whisper-main',
            templateUrl: './whisper.component.html',
            styleUrls: ['./whisper.component.css']
        }),
        __metadata("design:paramtypes", [LoginService, SuggestionService])
    ], WhisperComponent);
    return WhisperComponent;
}());
export { WhisperComponent };
//# sourceMappingURL=whisper.component.js.map