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
import { Observable } from 'rxjs/Observable';
import { environment } from '../../environments/environment';
import * as socketIo from 'socket.io-client';
var SERVER_URL = environment.SOCKET_ENDPOINT;
var SocketService = /** @class */ (function () {
    function SocketService(loginService) {
        this.loginService = loginService;
    }
    SocketService.prototype.initSocket = function () {
        this.socket = socketIo(SERVER_URL);
        this.onNew();
    };
    SocketService.prototype.send = function (message) {
        this.socket.emit('message', message);
    };
    SocketService.prototype.onNew = function () {
        var _this = this;
        this.socket.on('new', function () {
            _this.loginService.disconnect();
        });
    };
    SocketService.prototype.onMessage = function () {
        var _this = this;
        return new Observable(function (observer) {
            _this.socket.on('message', function (data) { return observer.next(data); });
        });
    };
    SocketService.prototype.onEvent = function (event) {
        var _this = this;
        return new Observable(function (observer) {
            _this.socket.on(event, function () { return observer.next(); });
        });
    };
    SocketService = __decorate([
        Injectable(),
        __metadata("design:paramtypes", [LoginService])
    ], SocketService);
    return SocketService;
}());
export { SocketService };
//# sourceMappingURL=socket.service.js.map