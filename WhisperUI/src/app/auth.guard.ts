import { LoginService } from './services/login.service';
import {CanActivate, Router} from '@angular/router';
import {Injectable} from '@angular/core';


@Injectable()
export class NeedAuthGuard implements CanActivate {

  constructor(private router: Router, private loginService: LoginService) {
  }

  public canActivate(): boolean {
    if (this.loginService.isConnected()) return true;

    this.router.navigate(['/login']);
    return false;
  }
}
