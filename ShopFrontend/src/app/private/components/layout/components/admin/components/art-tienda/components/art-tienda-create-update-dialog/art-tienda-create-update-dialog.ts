import { Component, computed, inject, Signal } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MAT_DIALOG_DATA, MatDialogActions, MatDialogContent, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { TiendaService } from '../../../tiendas/tienda-service';
import { ArticulosService } from '../../../articulos/articulos-service';
import { articuloClass } from '../../../articulos/articulosClass';
import { TiendaClass } from '../../../tiendas/tiendaClass';
import {MatSelectModule} from '@angular/material/select';
import { ShopService } from '../../../../../shop/shop-service';
@Component({
  selector: 'app-art-tienda-create-update-dialog',
  imports: [ReactiveFormsModule, MatButtonModule, MatInputModule,MatSelectModule, MatFormFieldModule, MatDialogContent, MatDialogActions],
  templateUrl: './art-tienda-create-update-dialog.html',
  styleUrl: './art-tienda-create-update-dialog.css'
})
export class ArtTiendaCreateUpdateDialog {
  readonly dialogRef = inject(MatDialogRef<ArtTiendaCreateUpdateDialog>);
  readonly data = inject<artTiendaClass>(MAT_DIALOG_DATA);
  protected readonly tiendaService = inject(TiendaService);
  protected readonly articuloService = inject(ArticulosService);

      articulosState: Signal<articuloClass[]> = computed(() =>
    this.articuloService.getFormattedArticulos()
  );

    tiendasState: Signal<TiendaClass[]> = computed(() =>
      this.tiendaService.getFormattedTiendas()
    );
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
    storeId: [this.data.storeId || '', [Validators.required]]
  });
}
