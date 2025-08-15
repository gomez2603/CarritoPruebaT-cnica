import { Component, inject, signal } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogContent, MatDialogRef } from '@angular/material/dialog';
import { articuloClass } from '../../articulosClass';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-articulo-create-update-dialog',
  imports: [ReactiveFormsModule, MatButtonModule, MatInputModule, MatFormFieldModule, MatDialogContent, MatDialogActions],
  templateUrl: './articulo-create-update-dialog.html',
  styleUrl: './articulo-create-update-dialog.css'
})
export class ArticuloCreateUpdateDialog {
  readonly dialogRef = inject(MatDialogRef<ArticuloCreateUpdateDialog>);
  readonly data = inject<articuloClass>(MAT_DIALOG_DATA);
 selectedFile: File | null = null;
imagePreview = signal<string | null>(this.data.image ?? null);
CreateArticulo() {
  if (this.addArticulo.valid) {
    const formData = new FormData();

    Object.entries(this.addArticulo.value).forEach(([key, value]) => {
      if (value !== null && value !== undefined) {
        // Convertir todo a string excepto el archivo
        if (key !== 'image') {
          formData.append(key, value.toString());
        }
      }
    });

    if (this.selectedFile) {
      formData.append('image', this.selectedFile);
    }

    this.dialogRef.close(formData);
  }
}

 onNoClick(): void {
    this.dialogRef.close();
  }

  private formBuilder = inject(FormBuilder);
   addArticulo: FormGroup = this.formBuilder.group({
    id: [this.data.id || 0], 
    code: [this.data.code || '', [Validators.required]],
    description: [this.data.description || '', [Validators.maxLength(50), Validators.required]],
    price: [this.data.price||0,[Validators.required]],
    stock:[this.data.stock||'',[Validators.required]],
    image:[this.data.image||null]
  });

onFileChange(event: Event) {
  const file = (event.target as HTMLInputElement)?.files?.[0] || null;
  this.selectedFile = file;
  this.addArticulo.patchValue({ image: null });

  if (file) {
    const reader = new FileReader();
    reader.onload = () => {
      this.imagePreview.set(reader.result as string);
    };
    reader.readAsDataURL(file);
  } else {
    this.imagePreview.set(null); 
  }
}

}
