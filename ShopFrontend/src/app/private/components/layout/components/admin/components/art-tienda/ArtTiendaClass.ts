class artTiendaClass {
  id: number;
  storeId: number;
  articuloId: number;
  tiendasBranch?: string;
  articuloCode?: string;
  fecha?: string;

  constructor(
    id: number,
    storeId: number,
    articuloId: number,
    tiendasBranch?: string,
    articuloCode?: string,
    fecha?: string
  ) {
    this.id = id;
    this.storeId = storeId;
    this.articuloId = articuloId;
    this.tiendasBranch = tiendasBranch;
    this.articuloCode = articuloCode;
    this.fecha = fecha;
  }
}
