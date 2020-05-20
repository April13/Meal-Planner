import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { ToastrModule } from "ngx-toastr";

import { SidebarModule } from './sidebar/sidebar.module';
import { FooterModule } from './shared/footer/footer.module';
import { NavbarModule} from './shared/navbar/navbar.module';
import { FixedPluginModule} from './shared/fixedplugin/fixedplugin.module';

import { AppComponent } from './app.component';
import { AppRoutes } from './app.routing';

import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';

import { HttpClientModule } from '@angular/common/http';
import { AccountService } from './services/account/account.service';
import { AuthenticationService } from './services/account/authentication.service';

import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { LoginComponent } from './components/account/login/login.component';
import { RegisterComponent } from './components/account/register/register.component';

@NgModule({
  declarations: [
    AppComponent,
    AdminLayoutComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    RouterModule.forRoot(AppRoutes,{
      // useHash: true
    }),
    RouterModule,
    SidebarModule,
    NavbarModule,
    ToastrModule.forRoot(),
    FooterModule,
    FixedPluginModule,
    HttpClientModule,

    ReactiveFormsModule,
    FormsModule
  ],
  providers: [
    AccountService,
    AuthenticationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
