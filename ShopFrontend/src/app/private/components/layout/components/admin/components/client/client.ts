import { Component, computed, inject, Signal } from '@angular/core';
import { ClientService } from './client-service';
import { ClientCreateUpdateDialog } from './components/client-create-update-dialog/client-create-update-dialog';
import { MatDialog } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTableModule } from '@angular/material/table';

@Component({
  selector: 'app-client',
  imports: [MatButtonModule, MatTableModule,MatIconModule],
  templateUrl: './client.html',
  styleUrl: './client.css'
})
export class Client {
  protected readonly clientService = inject(ClientService);
  readonly dialog = inject(MatDialog);


  displayedColumns: string[] = ['id', 'name', 'lastName','userName','rol'];
  
  clientState: Signal<clientClass[]> = computed(() =>
    this.clientService.getFormattedTiendas()
  );



 
  openDialog(client?: clientClass): void {
    const dialogRef = this.dialog.open(ClientCreateUpdateDialog, {
      data: client || {}
    });

    dialogRef.afterClosed().subscribe((result:clientClass|undefined) => {
      console.log('The dialog was closed');
      if (result !== undefined) {
      
        if(result.id !=0){
          this.clientService.updateTienda(result)
        }
        else{
          this.clientService.postTienda(result)
        }
      }
    });
  }
}
