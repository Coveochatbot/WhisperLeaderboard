import { WhisperComponent } from './whisper/whisper.component';
import { LoginComponent } from './login/login.component';
import { Routes, RouterModule } from '@angular/router';
import { NeedAuthGuard } from './auth.guard';
import { ModuleWithProviders } from '@angular/core';

const appRoutes: Routes = [
    { path: '', component: WhisperComponent, canActivate:  [NeedAuthGuard ] },
    { path: 'login', component: LoginComponent }
];

export const appRouting: ModuleWithProviders = RouterModule.forRoot(appRoutes);
