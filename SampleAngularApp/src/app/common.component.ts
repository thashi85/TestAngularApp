import { Component, OnInit } from '@angular/core';
import {MatDialog,MatDialogRef} from '@angular/material/dialog';
import {MatSnackBar} from '@angular/material/snack-bar';

@Component({
  selector: 'app-common',
  template: ''
})
export class CommonComponent implements OnInit {
    
    /**
     *
     */
    constructor(public snackBar: MatSnackBar) {
       
        
    }
    ngOnInit(): void {
       
    }

    // Snackbar that opens with success background
   openSuccessSnackBar(message:string="Success"){
    this.snackBar.open(message, "", {      
      panelClass: ['green-snackbar'],
     });
    }
    //Snackbar that opens with failure background
    openFailureSnackBar(message:string="Error Occured"){
    this.snackBar.open(message, "", {     
      panelClass: ['red-snackbar'],
      });
     }

/*TODO
   
    openDialog(cmp,options) {
        const dialogRef = this.dialog.open(cmp,options);
    
        dialogRef.afterClosed().subscribe(result => {
          console.log(`Dialog result: ${result}`);
        });
    }*/
   
}
