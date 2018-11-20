import { WhisperComponent } from './whisper/whisper.component';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { NeedAuthGuard } from './auth.guard';
var appRoutes = [
    { path: '', component: WhisperComponent, canActivate: [NeedAuthGuard] },
    { path: 'login', component: LoginComponent }
];
export var appRouting = RouterModule.forRoot(appRoutes);
//# sourceMappingURL=app.routing.js.map