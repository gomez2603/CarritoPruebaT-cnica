import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TiendaCreateUpdateDialog } from './tienda-create-update-dialog';

describe('TiendaCreateUpdateDialog', () => {
  let component: TiendaCreateUpdateDialog;
  let fixture: ComponentFixture<TiendaCreateUpdateDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TiendaCreateUpdateDialog]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TiendaCreateUpdateDialog);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
