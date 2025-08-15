import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogContent, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-art-tienda-create-update-dialog',
  imports: [ReactiveFormsModule, MatButtonModule, MatInputModule, MatFormFieldModule, MatDialogContent, MatDialogActions],
  templateUrl: './art-tienda-create-update-dialog.html',
  styleUrl: './art-tienda-create-update-dialog.css'
})
export class ArtTiendaCreateUpdateDialog {
  readonly dialogRef = inject(MatDialogRef<ArtTiendaCreateUpdateDialog>);
  readonly data = inject<artTiendaClass>(MAT_DIALOG_DATA);
  
CreateArtTienda() {
  if(this.addArtTienda.valid){
    this.dialogRef.close(this.addArtTienda.value);
  }
}

 onNoClick(): void {
    this.dialogRef.close();
  }

  private formBuilder = inject(FormBuilder);
   addArtTienda: FormGroup = this.formBuilder.group({
    id: [this.data.id || 0], 
    articuloId: [this.data.articuloId || '', [Validators.required]],
    storeId: [this.data.storeId || '', [Validators.maxLength(50), Validators.required]]
  });
}
