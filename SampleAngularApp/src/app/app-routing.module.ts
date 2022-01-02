import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

//component
import { UserListComponent } from './user/user-list/user-list.component';

const routes: Routes = [
  {
    path: '',
    component: UserListComponent
  },
   { path: 'user-groups', loadChildren: () => import('./user-group/user-group.module').then(m => m.UserGroupModule) }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
