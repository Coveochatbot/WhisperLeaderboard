import { User } from './../models/user';
import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse, HttpHeaders } from '@angular/common/http';
import { Suggestion } from '../models/suggestion';
import { throwError,  Observable  } from 'rxjs';
import {  catchError } from 'rxjs/operators';

const ENDPOINT: string = 'https://whisper-megagenial.us-east-1.elasticbeanstalk.com/whisper';

const httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
};
@Injectable({
    providedIn: 'root'
})
export class SuggestionService {
    public constructor(private http: HttpClient) {}

    public getSuggestion(chatKey: string): Observable<{} | Suggestion> {
        const parameters = '?chatkey=' + chatKey + '&maxDocuments=5&maxQuestions=3';
        return this.http.get<Suggestion>(`${ENDPOINT}/suggestions/${parameters}`)
            .pipe(catchError(this.errorHandler));
    }

    public getSuggestionWithQuery(query: string, user: User, chatKey: string): Observable<{} | Suggestion> {
        const data = {
            chatkey: chatKey,
            Query: query,
            type: user.userType,
            maxDocuments: 5,
            maxQuestions: 3
        };
        return this.http.post<Suggestion>(ENDPOINT + '/suggestions', data, httpOptions)
            .pipe(catchError(this.errorHandler));
    }

    public selectSuggestion(chatkey: string, id: string): Observable<{}> {
        const data = {
            chatkey,
            id
        };
        return this.http.post(ENDPOINT + '/suggestions/select', data, httpOptions)
            .pipe(catchError(this.errorHandler));
    } 

    public errorHandler(error: HttpErrorResponse): any {
        return throwError(error.message || 'Erreur de serveur');
    }

    public cancelQuestion(facetId: string): Observable<{}> {
        return this.http.delete(`${ENDPOINT}/facets/${facetId || ''}`, httpOptions)
            .pipe(catchError(this.errorHandler));
    }

    public getTimer(): Observable<string | {}> {
        // lol aNgUlAr cEsT bOn
        return this.http.get<string>('https://whisper-megagenial.us-east-1.elasticbeanstalk.com:8081/game/remaining', 
            { responseType: 'text' as 'json' })
            .pipe(catchError(this.errorHandler));
    }
}