import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllForumsPageComponent } from './all-forums-page.component';

describe('AllForumsPageComponent', () => {
  let component: AllForumsPageComponent;
  let fixture: ComponentFixture<AllForumsPageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AllForumsPageComponent]
    });
    fixture = TestBed.createComponent(AllForumsPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
