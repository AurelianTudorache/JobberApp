import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'app-jobad-dialog',
  templateUrl: './jobad-dialog.component.html',
  styleUrls: ['./jobad-dialog.component.css']
})
export class JobadDialogComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<JobadDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  // onNoClick(): void {
  //   this.dialogRef.close();
  // }

  ngOnInit(){}

}
