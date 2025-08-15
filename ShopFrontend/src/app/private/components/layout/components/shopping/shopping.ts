import { Component, computed, inject, Signal } from '@angular/core';

import { SaleService } from '../shop/sale-service';
import { shoppingClass } from './shoppingClass';
import { MatTableModule } from '@angular/material/table';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-shopping',
  imports: [ MatTableModule,DatePipe],
  templateUrl: './shopping.html',
  styleUrl: './shopping.css'
})
export class Shopping {
protected readonly shoppingService = inject(SaleService)
  displayedColumns: string[] = ['saleId', 'code', 'price','image','fecha'];
  articulosState: Signal<shoppingClass[]> = computed(() =>
    this.shoppingService.getFormattedArticulosByClient()
  );

}
