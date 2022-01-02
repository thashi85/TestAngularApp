import { NgModule } from '@angular/core';

import { ReactiveFormsModule,FormsModule } from '@angular/forms';
import {MAT_SNACK_BAR_DEFAULT_OPTIONS} from '@angular/material/snack-bar';

import{environment} from 'src/environments/environment'
//shared components
import {MaterialModule} from 'src/shared/material.module'
//services
import { testHttpProvider } from 'src/services/base/api-request-handler';
import {UserService} from 'src/services/user.service';
import { DeleteConfirmationComponent } from 'src/shared/delete-confirmation/delete-confirmation.component'
@NgModule({
  declarations: [
   
  DeleteConfirmationComponent],
  imports: [
    FormsModule,ReactiveFormsModule,
    MaterialModule
  ],
  exports: [    
    FormsModule,ReactiveFormsModule,
    MaterialModule
  ],
  providers: [testHttpProvider,UserService,
    {provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: {duration: environment.messageDurationInSeconds}}
  ]
})
export class CommonModule { }
