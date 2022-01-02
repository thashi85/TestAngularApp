import { Component, OnInit,Inject,ChangeDetectorRef } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import {MatDialog,MatDialogRef,MAT_DIALOG_DATA} from '@angular/material/dialog';
import {MatSnackBar} from '@angular/material/snack-bar';

import { CommonComponent } from 'src/app/common.component';
//models
import { User,Admin,Person } from 'src/models/user/user';
import { UserGroup } from 'src/models/user/user-group';

//services
import {UserService} from 'src/services/user.service'
@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss']
})
export class AddUserComponent extends CommonComponent implements OnInit {
  formGroup: FormGroup;
  userGroups:UserGroup[]=[];
  selectedGroup:UserGroup;
  selectedGroupId:number;

  addUserGroup:boolean=false;
  public objectComparisonFunction = function( option, value ) : boolean {
    return option.userGroupId == value;
  }
  
  constructor(private formBuilder: FormBuilder, 
              @Inject(MAT_DIALOG_DATA) public data: Person,
              public dialogRef: MatDialogRef<AddUserComponent>,
              snackBar: MatSnackBar,
              private _userService:UserService,
              public cd:ChangeDetectorRef
  ) { 

    super(snackBar);
  }

  ngOnInit(): void {
    this.loadUserGroups();
    this.createForm();
  
  }

  createForm() {
    let emailregex: RegExp = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/
    this.formGroup = this.formBuilder.group({
      'firstName': [this.data.firstName, Validators.required],
      'lastName': [this.data.lastName, Validators.required],
      'emailAddress': [this.data.emailAddress, [Validators.required, Validators.pattern(emailregex)]],
      'isAdmin':this.data instanceof Admin,
      'groupId':[this.data?.userGroup?.userGroupId ? this.data?.userGroup?.userGroupId: '',Validators.required],
      'groupName':['']
        });

        if(this.data?.userGroup?.userGroupId){
          this.getFormControl('groupId').setValue(this.data?.userGroup?.userGroupId); 
          this.selectedGroupId      =this.data?.userGroup?.userGroupId; 
          }
  }

  getFormControl(name) :FormControl{
    return this.formGroup.get(name) as FormControl
  }
  getErrorEmail() {
    return this.getFormControl('emailAddress').hasError('required') ? 'Field is required' :
      this.getFormControl('emailAddress').hasError('pattern') ? 'Not a valid emailaddress' : '';
  }
  closeDialog() {
    this.dialogRef.close();
  }
  loadUserGroups()
  {
    //start Loading
    this._userService.getUserGroups().subscribe(res => {
      this.userGroups = res.data;
      if(this.data?.userGroup?.userGroupId){
        this.getFormControl('groupId').setValue(this.data?.userGroup?.userGroupId);
        this.selectedGroup=this.userGroups.find(a=>a.userGroupId==this.data?.userGroup?.userGroupId) ;
        
        }
    }, error => {
      
    },()=>{
      //Stop Loading
    });
  }
   // Choose group using select dropdown
   changeGroup(e) {
     if(e && e.userGroupId)
    this.getFormControl('groupId').setValue(e.userGroupId);
    //this.formGroup.setValue(e.target.value, {
   //   onlySelf: true
   // })
  }
  onAddUserGroup(){
    this.addUserGroup=!this.addUserGroup;
  }
  onSaveUserGroup(){
    let _ug=new UserGroup();
    _ug.groupName=this.getFormControl('groupName').value;
    if(_ug.groupName.length>0){
    //start Loading
    this._userService.saveUserGroup(_ug).subscribe(res => {
      if(!res.status.isError){      
        this.openSuccessSnackBar(`User group is added successfully`);  
        this.userGroups.push(res.data);
        this.getFormControl('groupId').setValue(res.data.userGroupId);
        this.onAddUserGroup();     
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
  onSubmit(post) {
      console.log(post)
      //any other business validtaions
      let _user=null;
      if(post.isAdmin)
      {
          _user=new Admin();
      }else{
        _user=new User();
        _user.userGroup=new UserGroup();
        _user.userGroup.userGroupId=post.groupId;
      }
      _user.id=this.data.id;
      _user.firstName=post.firstName;
      _user.lastName=post.lastName;
      _user.emailAddress=post.emailAddress;
     
      //start Loading
      this._userService.saveUser(_user).subscribe(res => {
        if(!res.status.isError){
          var _action=this.data?.id>0 ?'updated' :'added'
          this.openSuccessSnackBar(`User is ${_action} successfully`)
          this.dialogRef.close(res);
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
