import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FoumInitialPageComponent } from './foum-initial-page.component';

describe('FoumInitialPageComponent', () => {
  let component: FoumInitialPageComponent;
  let fixture: ComponentFixture<FoumInitialPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FoumInitialPageComponent]
    });
    fixture = TestBed.createComponent(FoumInitialPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
