var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
var LoginService = /** @class */ (function () {
    function LoginService(router) {
        this.router = router;
        this.localUser = 'user';
        this.localMessages = 'messages';
    }
    LoginService.prototype.isConnected = function () {
        if (this.getCurrentUser())
            return true;
        else
            return false;
    };
    LoginService.prototype.connect = function (user) {
        sessionStorage.setItem(this.localUser, JSON.stringify(user));
    };
    LoginService.prototype.disconnect = function () {
        sessionStorage.removeItem(this.localUser);
        sessionStorage.removeItem(this.localMessages);
        this.router.navigate(['/login']);
    };
    LoginService.prototype.getCurrentUser = function () {
        return JSON.parse(sessionStorage.getItem(this.localUser));
    };
    LoginService.prototype.saveMessages = function (message) {
        var messages = this.getOldMessages();
        messages.push(message);
        sessionStorage.setItem(this.localMessages, JSON.stringify(messages));
    };
    LoginService.prototype.getOldMessages = function () {
        var messagesStored = sessionStorage.getItem(this.localMessages);
        if (messagesStored)
            return JSON.parse(messagesStored);
        return new Array();
    };
    LoginService = __decorate([
        Injectable({
            providedIn: 'root'
        }),
        __metadata("design:paramtypes", [Router])
    ], LoginService);
    return LoginService;
}());
export { LoginService };
//# sourceMappingURL=login.service.js.map