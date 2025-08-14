import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MAT_DIALOG_DATA, MatDialogActions,  MatDialogContent, MatDialogRef,  } from "@angular/material/dialog";
import { TiendaClass } from '../tiendaClass';


@Component({
  selector: 'app-tienda-create-update-dialog',
  imports: [ReactiveFormsModule, MatButtonModule, MatInputModule, MatFormFieldModule, MatDialogContent, MatDialogActions],
  templateUrl: './tienda-create-update-dialog.html',
  styleUrl: './tienda-create-update-dialog.css'
})
export class TiendaCreateUpdateDialog {
    readonly dialogRef = inject(MatDialogRef<TiendaCreateUpdateDialog>);
  readonly data = inject<TiendaClass>(MAT_DIALOG_DATA);
CreateTienda() {
  if(this.addTienda.valid){
    this.dialogRef.close(this.addTienda.value);
  }
}

 onNoClick(): void {
    this.dialogRef.close();
  }

  private formBuilder = inject(FormBuilder);
   addTienda: FormGroup = this.formBuilder.group({
    id: [this.data.id || 0], 
    branch: [this.data.branch || '', [Validators.required]],
    address: [this.data.address || '', [Validators.maxLength(50), Validators.required]]
  });
}
