import { Component, computed, inject, Signal } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { ArtTiendaServices } from './art-tienda-services';
import { MatDialog } from '@angular/material/dialog';
import { ArtTiendaCreateUpdateDialog } from './components/art-tienda-create-update-dialog/art-tienda-create-update-dialog';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-art-tienda',
  imports: [MatButtonModule, MatTableModule,MatIconModule,DatePipe],
  templateUrl: './art-tienda.html',
  styleUrl: './art-tienda.css'
})
export class ArtTienda {

  protected readonly ArtTiendaService = inject(ArtTiendaServices);
  readonly dialog = inject(MatDialog);


  displayedColumns: string[] = ['id', 'tiendasBranch', 'articuloCode','fecha','actions'];
  
  tiendasState: Signal<artTiendaClass[]> = computed(() =>
    this.ArtTiendaService.getFormattedTiendas()
  );



 
  openDialog(tienda?: artTiendaClass): void {
    const dialogRef = this.dialog.open(ArtTiendaCreateUpdateDialog, {
      data: tienda || {} // Si no hay tienda seleccionada, se pasa un objeto vacío
    });

    dialogRef.afterClosed().subscribe((result:artTiendaClass|undefined) => {
      console.log('The dialog was closed');
      if (result !== undefined) {
        // Aquí puedes manejar el resultado (guardar o actualizar la tienda)
        if(result.id !=0){
          this.ArtTiendaService.updateTienda(result)
        }
        else{
          this.ArtTiendaService.postTienda(result)
        }
      }
    });
  }

  deleteTienda(id: number) {
    if (confirm('¿Estás seguro de eliminar?')) {
      this.ArtTiendaService.deleteTienda(id);
      this.ArtTiendaService.getTiendas()
    }
  }
}
