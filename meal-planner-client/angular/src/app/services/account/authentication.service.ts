import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from './account.service';
import { Account } from '../../data/account.model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private currentAccountSubject: BehaviorSubject<Account>;
  public currentAccount: Observable<Account>;

  constructor(private http: HttpClient, private accountService: AccountService) {
      this.currentAccountSubject = new BehaviorSubject<Account>(JSON.parse(localStorage.getItem('currentAccount')));
      this.currentAccount = this.currentAccountSubject.asObservable();
  }

  public get currentAccountValue(): Account {
      return this.currentAccountSubject.value;
  }

  login(email: string, password: string) {
    return this.accountService.verify(email, password).pipe(map(account => {
      // login successful if id is returned
        if (account.id != 0 || account.id != null) {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem('currentAccount', JSON.stringify(account));
            this.currentAccountSubject.next(account);
        }
        return account;
      }));
          
  }

  logout() {
      // remove user from local storage to log user out
      localStorage.removeItem('currentAccount');
      this.currentAccountSubject.next(null);
  }
}
