import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar, MatDialog } from '@angular/material';
import { JobAd } from '../../../shared/interfaces/jobAd';
import { JobadDialogComponent } from '../jobad-dialog/jobad-dialog.component';

@Component({
  selector: 'app-jobs-filled',
  templateUrl: './jobs-filled.component.html',
  styleUrls: ['./jobs-filled.component.css']
})
export class JobsFilledComponent implements OnInit {

  position = 'below';
  
  private readonly assignedjobAdsUrl = "api/employer/assignedjobads";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private sb: MatSnackBar, public dialog: MatDialog) { }

  assignedjobAds: JobAd[];

  openDialog(assignedjobAds): void {
    let dialogRef = this.dialog.open(JobadDialogComponent, {
      width: '350px',
      data: assignedjobAds 
    });
  }

  ngOnInit() {
    this.getCompletedJobAds();
  }

  getCompletedJobAds() {
    this.http.get<JobAd[]>(this.baseUrl + this.assignedjobAdsUrl).subscribe(result => {
      this.assignedjobAds = result;
    }, error => this.sb.open(error, 'close', { duration: 5000 }));
  }

}
