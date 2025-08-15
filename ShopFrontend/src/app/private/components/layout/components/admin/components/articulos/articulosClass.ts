export class articuloClass {
  id: number;
  code: string;
  description: string;
  price: number;
  image: string
  stock: number;

  constructor(
    id: number,
    code: string,
    description: string,
    price: number,
    stock: number,
    image: string
  ) {
    this.id = id;
    this.code = code;
    this.description = description;
    this.price = price;
    this.stock = stock;
    this.image = image ?? null;
  }
}
