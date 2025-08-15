import { Component, computed, inject, Signal } from '@angular/core';
import { TiendaService } from './tienda-service';
import { TiendaClass } from './tiendaClass';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { TiendaCreateUpdateDialog } from './tienda-create-update-dialog/tienda-create-update-dialog';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-tiendas',
  imports: [MatButtonModule, MatTableModule,MatIconModule],
  templateUrl: './tiendas.html',
  styleUrl: './tiendas.css'
})
export class Tiendas {

  protected readonly tiendaService = inject(TiendaService);
  readonly dialog = inject(MatDialog);


  displayedColumns: string[] = ['id', 'branch', 'address','actions'];
  
  tiendasState: Signal<TiendaClass[]> = computed(() =>
    this.tiendaService.getFormattedTiendas()
  );



 
  openDialog(tienda?: TiendaClass): void {
    const dialogRef = this.dialog.open(TiendaCreateUpdateDialog, {
      data: tienda || {} // Si no hay tienda seleccionada, se pasa un objeto vacío
    });

    dialogRef.afterClosed().subscribe((result:TiendaClass|undefined) => {
      console.log('The dialog was closed');
      if (result !== undefined) {
        // Aquí puedes manejar el resultado (guardar o actualizar la tienda)
        if(result.id !=0){
          this.tiendaService.updateTienda(result)
        }
        else{
          this.tiendaService.postTienda(result)
        }
      }
    });
  }

  deleteTienda(id: number) {
    if (confirm('¿Estás seguro de eliminar?')) {
      this.tiendaService.deleteTienda(id);
      this.tiendaService.getTiendas()
    }
  }
  
}



