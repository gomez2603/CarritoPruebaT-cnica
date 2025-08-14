export class TiendaClass {
  id: number;
  branch: string;
  address: string;

  constructor(id: number, branch: string, address: string) {
    this.id = id;
    this.branch = branch;
    this.address = address;
  }
}
