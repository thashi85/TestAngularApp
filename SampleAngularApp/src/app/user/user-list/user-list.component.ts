import { Component, OnInit,OnDestroy,ViewChild } from '@angular/core';

import {MatDialog,MatDialogRef} from '@angular/material/dialog';
import {MatSnackBar} from '@angular/material/snack-bar';
import {MatPaginator,PageEvent} from '@angular/material/paginator';

import { Subscription } from 'rxjs';
//Components
import { CommonComponent } from 'src/app/common.component';
import {BaseParam, Paging} from 'src/models/base-param';
import { AddUserComponent} from 'src/app/user/add-user/add-user.component';
import { DeleteConfirmationComponent } from 'src/shared/delete-confirmation/delete-confirmation.component'

//models
import { User,Person } from 'src/models/user/user';
//services
import {UserService} from 'src/services/user.service'

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent extends CommonComponent implements OnInit,OnDestroy {
  users:User[];
  subscriptions:Subscription[]=[];

  totalRecordCount: number = 0;
  pageSize = 5;
  pagenumber =0;// this is for search   
  pageSizeOptions: number[] = [5, 10, 25, 100];
  @ViewChild('Paginator') paginator: MatPaginator;

  constructor(private _userService:UserService,
    public dialog: MatDialog,  snackBar: MatSnackBar,
    ) {
      super(snackBar);
   }
  ngOnDestroy(): void {
    //this can be handle commonly using wrapper
    if(this.subscriptions){
      this.subscriptions.forEach(s=>s.unsubscribe());
    }
  }

  ngOnInit(): void {
   this.loadUsers();
  }
  loadUsers(){
    var _param=new BaseParam();
    _param.paging=new Paging();
    _param.paging.number=(this.pagenumber+1).toString();
    _param.paging.size=this.pageSize.toString();

    //start Loading
    this._userService.getUsers(_param).subscribe(res => {
      if(res.status.isError){
        this.users = [];
        this.totalRecordCount=0;
        this.openFailureSnackBar(res.status.errorMessage);
      }else{
        this.users = res.data;
        this.totalRecordCount=res.totalResultCount;
      }
    }, error => {
      this.openFailureSnackBar(error?.message ? error?.message: null)
    },()=>{
      //Stop Loading
    });
  }
  onPageclickevent(pageEvent: PageEvent) {
    this.pageSize = pageEvent.pageSize;
    this.pagenumber = pageEvent.pageIndex;
    this.loadUsers()
}

  onAddUser():void{    
     this.openUserPopup(new User());
  }
  onEditUser(user:User) 
  {
    this.openUserPopup(user);
  }
  openUserPopup(person:Person){
    const dialogRef = this.dialog.open(AddUserComponent,{
      data:person,
      height: '550px',
      width: '600px',
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
      if(result && result.data){
        this.loadUsers();
      }
    });
  }
  onDeleteUser(user:User) {

    let dialogRef = this.dialog.open(DeleteConfirmationComponent, {
      data: {
        title:'Delete User',
        message: 'Are you sure that you want to delete the user?',
        yesText: 'Confirm',
        noText: 'Cancel'
      },
      panelClass: ['delete-confirm'],     
      width: '40vw',
    });
    //This is another way of subcribe modal popup action
    this.subscriptions.push(dialogRef.componentInstance.onDeleteConfirm.subscribe((data: any) => {
      if (data == true) {
           this.deleteUser(user.id);
      }
    })
    );

  }
  deleteUser(id){
    //start Loading
    this._userService.deleteUser(id).subscribe(res => {
      if(res.status.isError || !res.data){
        this.openFailureSnackBar(res.status.errorMessage)
      }else{
        this.openSuccessSnackBar("User is deleted successfully")
      }
    }, error => {
      this.openFailureSnackBar(error)
    },()=>{
      //Stop Loading
    });
  }
  
  
}
