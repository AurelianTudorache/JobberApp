import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JobadDialogComponent } from './jobad-dialog.component';

describe('JobadDialogComponent', () => {
  let component: JobadDialogComponent;
  let fixture: ComponentFixture<JobadDialogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JobadDialogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JobadDialogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
