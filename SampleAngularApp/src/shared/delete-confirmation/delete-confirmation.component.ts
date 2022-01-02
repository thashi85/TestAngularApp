import { Component, OnInit,Output,EventEmitter,Inject } from '@angular/core';

import {MatDialog,MatDialogRef,MAT_DIALOG_DATA} from '@angular/material/dialog';
@Component({
  selector: 'app-delete-confirmation',
  templateUrl: './delete-confirmation.component.html',
  styleUrls: ['./delete-confirmation.component.scss']
})
export class DeleteConfirmationComponent implements OnInit {

  @Output() onDeleteConfirm = new EventEmitter<any>(true);
  constructor(public matDialogRef: MatDialogRef<DeleteConfirmationComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
     public dialogRef: MatDialogRef<DeleteConfirmationComponent>) { }

  ngOnInit() {
  }

  onCancelClick() {
    this.onDeleteConfirm.emit(false);
    this.matDialogRef.close();
 }

onOkClick() {
    this.onDeleteConfirm.emit(true);
    this.matDialogRef.close();
}

closeDialog() {
  this.dialogRef.close();
}
}
