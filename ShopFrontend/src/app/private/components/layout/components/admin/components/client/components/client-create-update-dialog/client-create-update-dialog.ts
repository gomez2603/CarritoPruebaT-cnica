import { Component, inject } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogContent, MatDialogActions, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';

@Component({
  selector: 'app-client-create-update-dialog',
  imports: [ReactiveFormsModule, MatButtonModule, MatInputModule, MatFormFieldModule, MatDialogContent, MatDialogActions,MatSelectModule],
  templateUrl: './client-create-update-dialog.html',
  styleUrl: './client-create-update-dialog.css'
})
export class ClientCreateUpdateDialog {
  readonly dialogRef = inject(MatDialogRef<ClientCreateUpdateDialog>);
  readonly data = inject<clientClass>(MAT_DIALOG_DATA);
CreateClient() {
  if(this.addClient.valid){
    this.dialogRef.close(this.addClient.value);
  }
}


 onNoClick(): void {
    this.dialogRef.close();
  }

    private formBuilder = inject(FormBuilder);
   addClient: FormGroup = this.formBuilder.group({
    id: [ 0], 
    name: [ '', [Validators.required]],
    lastName: [ '', [Validators.maxLength(50), Validators.required]],
    password: ['' ,[Validators.required]],
    username: ['',[Validators.required]],
    address : ['',[Validators.required]],
    rol:[1,Validators.required]

  
  });

}
