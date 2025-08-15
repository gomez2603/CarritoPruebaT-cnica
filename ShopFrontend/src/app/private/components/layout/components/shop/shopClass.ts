export class CartItem {
  id: number;
  articuloId: number;

  constructor(id: number = 0, articuloId: number = 0) {
    this.id = id;
    this.articuloId = articuloId;
  }
}