class clientClass {
  id: number;
  name: string;
  lastName: string;
  password: string;
  username: string;
  address: string;
  rol: number;

  constructor(
    id: number,
    name: string,
    lastName: string,
    password: string,
    username: string,
    address: string,
    rol: number
  ) {
    this.id = id;
    this.name = name;
    this.lastName = lastName;
    this.password = password;
    this.username = username;
    this.address = address;
    this.rol = rol;
  }
}
