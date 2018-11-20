var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { environment } from './../../environments/environment';
import { Router } from '@angular/router';
import { LoginService } from './../services/login.service';
import { Component } from '@angular/core';
import { User } from '../models/user';
var LoginComponent = /** @class */ (function () {
    function LoginComponent(loginService, router) {
        this.loginService = loginService;
        this.router = router;
        this.user = new User();
        this.error = '';
    }
    LoginComponent.prototype.ngOnInit = function () {
    };
    LoginComponent.prototype.onConnect = function () {
        if (!this.user.name || this.user.name.length < 1) {
            this.error = 'Veuillez entrer un nom';
            return;
        }
        this.user.avatar = this.randomColorStyle();
        this.user.userType = environment.userType;
        this.loginService.connect(this.user);
        this.router.navigate(['/']);
    };
    LoginComponent.prototype.randomColorStyle = function () {
        var letters = '0123456789ABCDEF';
        var color = '#';
        for (var i = 0; i < 6; ++i) {
            color += letters[Math.floor(Math.random() * 16)];
        }
        return { 'color': color };
    };
    LoginComponent = __decorate([
        Component({
            selector: 'whisper-login',
            templateUrl: './login.component.html',
            styleUrls: ['./login.component.css']
        }),
        __metadata("design:paramtypes", [LoginService, Router])
    ], LoginComponent);
    return LoginComponent;
}());
export { LoginComponent };
//# sourceMappingURL=login.component.js.map