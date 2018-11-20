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
import {SuiModule} from 'ng2-semantic-ui';
registerLocaleData(localeFr, 'fr');
  
@NgModule({
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
    HttpClientModule,
    SuiModule
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
export class AppModule { }
