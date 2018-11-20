var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
import { SuggestionService } from './services/suggestion.service';
import { SocketService } from './services/socket.service';
import { LoginService } from './services/login.service';
import { NeedAuthGuard } from './auth.guard';
import { SuggestionComponent } from './suggestion/suggestion.component';
import { BrowserModule } from '@angular/platform-browser';
import { LOCALE_ID, NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { ChatComponent } from './chat/chat.component';
import { WhisperComponent } from './whisper/whisper.component';
import { LoginComponent } from './login/login.component';
import { appRouting } from './app.routing';
import { FormsModule } from '@angular/forms';
import { registerLocaleData } from '@angular/common';
import localeFr from '@angular/common/locales/fr';
import { HttpClientModule } from '@angular/common/http';
registerLocaleData(localeFr, 'fr');
var AppModule = /** @class */ (function () {
    function AppModule() {
    }
    AppModule = __decorate([
        NgModule({
            declarations: [
                AppComponent,
                ChatComponent,
                WhisperComponent,
                LoginComponent,
                SuggestionComponent
            ],
            imports: [
                BrowserModule,
                appRouting,
                FormsModule,
                HttpClientModule
            ],
            providers: [
                NeedAuthGuard,
                LoginService,
                SocketService,
                SuggestionService,
                {
                    provide: LOCALE_ID,
                    useValue: 'fr'
                }
            ],
            bootstrap: [AppComponent]
        })
    ], AppModule);
    return AppModule;
}());
export { AppModule };
//# sourceMappingURL=app.module.js.map