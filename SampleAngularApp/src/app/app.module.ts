import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
//shared
import { CommonModule } from 'src/shared/common.module';

//app components
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { UserListComponent } from './user/user-list/user-list.component';
import { AddUserComponent } from './user/add-user/add-user.component';

@NgModule({
  declarations: [
    AppComponent,
    UserListComponent,
    AddUserComponent
  ],
  imports: [
    BrowserModule,BrowserAnimationsModule,HttpClientModule,
    AppRoutingModule,
    CommonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
