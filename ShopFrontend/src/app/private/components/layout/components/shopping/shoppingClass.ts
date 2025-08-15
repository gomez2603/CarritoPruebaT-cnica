export class shoppingClass {
  saleId: number;
  articuloId: number;
  code: string;
  description: string;
  price: number;
  image: string;
  fecha: Date;

  constructor(
    saleId: number,
    articuloId: number,
    code: string,
    description: string,
    price: number,
    image: string,
    fecha: Date
  ) {
    this.saleId = saleId;
    this.articuloId = articuloId;
    this.code = code;
    this.description = description;
    this.price = price;
    this.image = image;
    this.fecha = fecha;
  }


}
