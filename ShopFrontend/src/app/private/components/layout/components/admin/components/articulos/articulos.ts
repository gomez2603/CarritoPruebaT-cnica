import { Component, computed, inject, Signal } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';
import { ArticulosService } from './articulos-service';
import { MatDialog } from '@angular/material/dialog';
import { articuloClass } from './articulosClass';
import { ArticuloCreateUpdateDialog } from './Components/articulo-create-update-dialog/articulo-create-update-dialog';

@Component({
  selector: 'app-articulos',
  imports: [MatButtonModule, MatTableModule,MatIconModule],
  templateUrl: './articulos.html',
  styleUrl: './articulos.css'
})
export class Articulos {
  protected readonly articuloService = inject(ArticulosService);
  readonly dialog = inject(MatDialog);
  displayedColumns: string[] = ['id', 'code', 'description','price','stock','image','actions'];

    articulosState: Signal<articuloClass[]> = computed(() =>
    this.articuloService.getFormattedArticulos()
  );

    openDialog(articulo?: articuloClass): void {
      const dialogRef = this.dialog.open(ArticuloCreateUpdateDialog, {
        data: articulo || {} // Si no hay tienda seleccionada, se pasa un objeto vacío
      });
  
      dialogRef.afterClosed().subscribe((result:FormData|undefined) => {
        console.log('The dialog was closed');
        if (result !== undefined) {
          // Aquí puedes manejar el resultado (guardar o actualizar la tienda)}
            const id = Number(result.get('id'));
          if(id !=0){
            this.articuloService.updateArticulos(result)
          }
          else{
            this.articuloService.postArticulos(result)
          }
        }
      });
    }
  
    deleteTienda(id: number) {
      if (confirm('¿Estás seguro de eliminar?')) {
        this.articuloService.deleteArticulos(id);

      }
    }

}
