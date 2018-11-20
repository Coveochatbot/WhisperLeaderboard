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
import { Suggestion } from './../models/suggestion';
import { SuggestionService } from './../services/suggestion.service';
import { Component, Input, Output, EventEmitter } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import * as $ from 'jquery';
var SuggestionComponent = /** @class */ (function () {
    function SuggestionComponent(suggestionService, loginService, sanitizer) {
        this.suggestionService = suggestionService;
        this.loginService = loginService;
        this.sanitizer = sanitizer;
        this.suggestionClickEvent = new EventEmitter();
        this.selectedDocument = this.sanitizer.bypassSecurityTrustResourceUrl('about:blank');
    }
    SuggestionComponent.prototype.ngOnInit = function () {
        this._userLogged = this.loginService.getCurrentUser();
    };
    SuggestionComponent.prototype.choiceSuggestion = function (document) {
        this.selectedDocument = this.sanitizer.bypassSecurityTrustResourceUrl(document.uri);
        $('#suggestion')
            .transition({
            animation: 'scale',
            duration: '300ms',
            onComplete: function () {
                $('#documentWrapper').transition('scale');
            }
        });
    };
    SuggestionComponent.prototype.choiceQuestion = function (question, chatKey) {
        this.suggestionService.selectSuggestion(chatKey, question.id);
        this.suggestionClickEvent.emit(question.text);
    };
    SuggestionComponent.prototype.closeDocument = function () {
        $('#documentWrapper')
            .transition({
            animation: 'scale',
            duration: '300ms',
            onComplete: function () {
                $('#suggestion').transition('scale');
            }
        });
    };
    __decorate([
        Input(),
        __metadata("design:type", Suggestion)
    ], SuggestionComponent.prototype, "suggestion", void 0);
    __decorate([
        Output(),
        __metadata("design:type", EventEmitter)
    ], SuggestionComponent.prototype, "suggestionClickEvent", void 0);
    SuggestionComponent = __decorate([
        Component({
            selector: 'whisper-suggestion',
            templateUrl: './suggestion.component.html',
            styleUrls: ['./suggestion.component.css']
        }),
        __metadata("design:paramtypes", [SuggestionService,
            LoginService,
            DomSanitizer])
    ], SuggestionComponent);
    return SuggestionComponent;
}());
export { SuggestionComponent };
//# sourceMappingURL=suggestion.component.js.map