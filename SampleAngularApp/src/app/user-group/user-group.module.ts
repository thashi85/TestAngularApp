import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UserGroupRoutingModule } from './user-group-routing.module';
import { UserGroupComponent } from 'src/app/user-group/user-group/user-group.component';
import { AccessRightComponent } from './access-right/access-right.component';
//shared
import { CommonModule as TestCommon } from 'src/shared/common.module';

@NgModule({
  declarations: [UserGroupComponent, AccessRightComponent],
  imports: [
    CommonModule,
    UserGroupRoutingModule,TestCommon
  ]
  
})
export class UserGroupModule { }
