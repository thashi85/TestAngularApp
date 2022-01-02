import { Component, OnInit,Inject } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';

import {MatDialog,MatDialogRef,MAT_DIALOG_DATA} from '@angular/material/dialog';
import {MatSnackBar} from '@angular/material/snack-bar';

import { CommonComponent } from 'src/app/common.component';
import { UserGroup } from 'src/models/user/user-group';
//services
import {UserService} from 'src/services/user.service'
@Component({
  selector: 'app-user-group',
  templateUrl: './user-group.component.html',
  styleUrls: ['./user-group.component.scss']
})
export class UserGroupComponent extends CommonComponent implements OnInit {
  formGroup: FormGroup;
  userGroups:UserGroup[]=[];
  public data: UserGroup=new UserGroup();
  constructor(private formBuilder: FormBuilder, 
    snackBar: MatSnackBar,
    private _userService:UserService) {
      super(snackBar);
   }

 ngOnInit(): void {
    this.loadUserGroups();  
    this.createForm();
     
  }

  loadUserGroups()
  {
    //start Loading
    this._userService.getUserGroups().subscribe(res => {
      this.userGroups = res.data;    
    }, error => {
      
    },()=>{
      //Stop Loading
    });
  }

  createForm() {
    this.formGroup = this.formBuilder.group({
         'name': [this.data.groupName, Validators.required],
     
        });
  }
  getFormControl(name) :FormControl{
    return this.formGroup.get(name) as FormControl
  }
 onEdit(userG:UserGroup){
    this.data=userG;
    this.getFormControl('name').setValue(this.data.groupName);
 }
 onAddUserGroup(){
  this.data=new UserGroup();
  this.getFormControl('name').setValue(this.data.groupName);
 }
  onSubmit(post) {
    console.log(post)
    //any other business validtaions
     let _grp=new UserGroup();  
    _grp.userGroupId=this.data.userGroupId;
    _grp.groupName=post.name;
     
    if(_grp.groupName.length>0){
    //start Loading
    this._userService.saveUserGroup(_grp).subscribe(res => {
      if(!res.status.isError){   
        var _action=this.data?.userGroupId>0 ?'updated' :'added'
        this.openSuccessSnackBar(`User group is ${_action} successfully`)   
       
       
        this.loadUserGroups();
      }        
      else{
        this.openFailureSnackBar(res.status.errorMessage)
      }
    }, error => {
      this.openFailureSnackBar(error)
    },()=>{
      //Stop Loading
    });
  }

}


}
