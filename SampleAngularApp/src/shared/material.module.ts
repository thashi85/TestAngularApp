import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import {MatButtonModule} from '@angular/material/button';
import {MatInputModule} from '@angular/material/input';
import {MatCheckboxModule} from '@angular/material/checkbox';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatDialogModule,MAT_DIALOG_DATA,MatDialogRef} from '@angular/material/dialog';
import {MatSnackBarModule} from '@angular/material/snack-bar';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatIconModule} from '@angular/material/icon';

@NgModule({
  imports: [ 
    MatButtonModule,
    MatDialogModule,MatInputModule,MatToolbarModule,MatFormFieldModule,MatCheckboxModule,MatSelectModule,
    MatSnackBarModule,MatPaginatorModule,MatIconModule
  ],
  exports: [
    MatButtonModule,
    MatDialogModule,MatInputModule,MatToolbarModule,MatFormFieldModule,MatCheckboxModule,MatSelectModule,
    MatSnackBarModule,MatPaginatorModule,MatIconModule
  ]   ,
  providers:[ { provide: MAT_DIALOG_DATA, useValue: {} },
    { provide: MatDialogRef, useValue: {} }]
})

export class MaterialModule {}