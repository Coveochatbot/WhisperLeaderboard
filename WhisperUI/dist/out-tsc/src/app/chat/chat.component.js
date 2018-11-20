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
import { Component, Output, EventEmitter, Input } from '@angular/core';
import { SocketService } from './../services/socket.service';
var ChatComponent = /** @class */ (function () {
    function ChatComponent(socketService, loginService) {
        this.socketService = socketService;
        this.loginService = loginService;
        this.messages = new Array();
        this.messageSentEvent = new EventEmitter();
        this._isNewMessage = false;
    }
    ChatComponent.prototype.ngOnInit = function () {
        var _this = this;
        this.socketService.initSocket();
        this._userConnected = this.loginService.getCurrentUser();
        this.messages = this.loginService.getOldMessages();
        this.socketService.onMessage()
            .subscribe(function (message) {
            _this.messages.push(message);
            _this.loginService.saveMessages(message);
            _this.messageSentEvent.emit(message.content);
            _this._isNewMessage = true;
        });
    };
    ChatComponent.prototype.ngAfterViewChecked = function () {
        if (this._isNewMessage) {
            var wrapper = document.getElementById('chat-wrapper');
            wrapper.scrollTo(0, wrapper.scrollHeight);
            this._isNewMessage = false;
        }
    };
    ChatComponent.prototype.sendMessage = function () {
        if (!this.messageContent) {
            return;
        }
        this.socketService.send({
            from: this._userConnected,
            content: this.messageContent,
            date: new Date()
        });
        this.messageContent = null;
    };
    ChatComponent.prototype.getConversationColor = function (user) {
        if (user.name === this._userConnected.name)
            return { 'background-color': '#c9ffff' };
        return { 'background-color': '#FFF' };
    };
    __decorate([
        Input(),
        __metadata("design:type", String)
    ], ChatComponent.prototype, "messageContent", void 0);
    __decorate([
        Output(),
        __metadata("design:type", EventEmitter)
    ], ChatComponent.prototype, "messageSentEvent", void 0);
    ChatComponent = __decorate([
        Component({
            selector: 'whisper-chat',
            templateUrl: './chat.component.html',
            styleUrls: ['./chat.component.css']
        }),
        __metadata("design:paramtypes", [SocketService, LoginService])
    ], ChatComponent);
    return ChatComponent;
}());
export { ChatComponent };
//# sourceMappingURL=chat.component.js.map