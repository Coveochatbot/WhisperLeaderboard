var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { LoginService } from './login.service';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
var ENDPOINT = 'https://whisper-megagenial.us-east-1.elasticbeanstalk.com/whisper';
var httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};
var SuggestionService = /** @class */ (function () {
    function SuggestionService(http, loginService) {
        this.http = http;
        this.loginService = loginService;
    }
    SuggestionService.prototype.getSuggestion = function (chatKey) {
        var parameters = '?chatkey=' + chatKey.toString() + '&maxDocuments=5&maxQuestions=3';
        return this.http.get(ENDPOINT + "/suggestions/" + parameters)
            .pipe(catchError(this.errorHandler));
    };
    SuggestionService.prototype.getSuggestionWithQuery = function (query, chatKey) {
        var data = {
            chatkey: chatKey,
            Query: query,
            type: this.loginService.getCurrentUser().userType,
            maxDocuments: 5,
            maxQuestions: 3
        };
        return this.http.post(ENDPOINT + '/suggestions', data, httpOptions)
            .pipe(catchError(this.errorHandler));
    };
    SuggestionService.prototype.selectSuggestion = function (chatkey, id) {
        var data = {
            chatkey: chatkey,
            id: id
        };
        return this.http.post(ENDPOINT + '/suggestions/select', data, httpOptions)
            .pipe(catchError(this.errorHandler));
    };
    SuggestionService.prototype.errorHandler = function (error) {
        return throwError(error.message || 'Erreur de serveur');
    };
    SuggestionService.prototype.cancelQuestion = function (facetId) {
        return this.http.delete(ENDPOINT + "/facets/" + (facetId || ''), httpOptions)
            .pipe(catchError(this.errorHandler));
    };
    SuggestionService = __decorate([
        Injectable({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [HttpClient, LoginService])
    ], SuggestionService);
    return SuggestionService;
}());
export { SuggestionService };
//# sourceMappingURL=suggestion.service.js.map