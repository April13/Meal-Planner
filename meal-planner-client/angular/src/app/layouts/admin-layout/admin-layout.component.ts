import { Component, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { AuthenticationService } from 'app/services/account/authentication.service';
import { Account } from "../../data/account.model";


@Component({
  selector: 'app-admin-layout',
  templateUrl: './admin-layout.component.html',
  styleUrls: ['./admin-layout.component.scss']
})
export class AdminLayoutComponent implements OnInit {
  currentAccount: Account;
  currentAccountSubscription: Subscription;
  accounts: Account[] = [];

  constructor(
    private authenticationService: AuthenticationService
  ) 
  {
    this.currentAccountSubscription = this.authenticationService.currentAccount.subscribe(account => {
      this.currentAccount = account;
    });
  }

  ngOnInit() { }

  ngOnDestroy() {
    // unsubscribe to ensure no memory leaks
    this.currentAccountSubscription.unsubscribe();
  }

}
