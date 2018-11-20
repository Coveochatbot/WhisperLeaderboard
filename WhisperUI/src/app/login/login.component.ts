import { environment } from './../../environments/environment';
import { Router } from '@angular/router';
import { LoginService } from './../services/login.service';
import { Component, OnInit } from '@angular/core';
import { User } from '../models/user';
@Component({
    selector: 'whisper-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    public user: User;
    public error: string;

    constructor(private loginService: LoginService, private router: Router) {
        this.user = new User();
        this.error = '';
    }

    public ngOnInit(): void {
    }

    public onConnect(): void {
        if (!this.user.name || this.user.name.length < 1) {
            this.error = 'Veuillez entrer un nom';
            return;
        }  
        this.user.avatar = this.randomColorStyle();
        this.user.userType = environment.userType;
        this.loginService.connect(this.user);
        this.router.navigate(['/']);
    }

    private randomColorStyle(): any {
        const letters: string = '0123456789ABCDEF';
        let color: string = '#';
        for (let i = 0; i < 6; ++i) {
          color += letters[Math.floor(Math.random() * 16)];
        }
        return { 'color' : color };
    }
}
