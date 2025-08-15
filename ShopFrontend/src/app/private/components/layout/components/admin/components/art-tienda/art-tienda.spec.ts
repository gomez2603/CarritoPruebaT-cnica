import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArtTienda } from './art-tienda';

describe('ArtTienda', () => {
  let component: ArtTienda;
  let fixture: ComponentFixture<ArtTienda>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ArtTienda]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ArtTienda);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
