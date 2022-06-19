import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserandroleComponent } from './userandrole.component';

describe('UserandroleComponent', () => {
  let component: UserandroleComponent;
  let fixture: ComponentFixture<UserandroleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserandroleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserandroleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
