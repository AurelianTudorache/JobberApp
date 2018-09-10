import { Component, OnInit, Inject } from '@angular/core';
import { JobAd } from '../../../shared/interfaces/jobAd';
import { HttpClient } from '@angular/common/http';
import { MatSnackBar, MatDialog } from '@angular/material';
import { JobadDialogComponent } from '../jobad-dialog/jobad-dialog.component';

@Component({
  selector: 'app-jobs-completed',
  templateUrl: './jobs-completed.component.html',
  styleUrls: ['./jobs-completed.component.css']
})
export class JobsCompletedComponent implements OnInit {

  position = 'below';
  
  private readonly completedjobAdsUrl = "api/employer/completedjobads";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private sb: MatSnackBar, public dialog: MatDialog) { }

  completedjobAds: JobAd[];

  openDialog(completedjobAds): void {
    let dialogRef = this.dialog.open(JobadDialogComponent, {
      width: '350px',
      data: completedjobAds 
    });
  }

  ngOnInit() {
    this.getCompletedJobAds();
  }

  getCompletedJobAds() {
    this.http.get<JobAd[]>(this.baseUrl + this.completedjobAdsUrl).subscribe(result => {
      this.completedjobAds = result;
    }, error => this.sb.open(error, 'close', { duration: 5000 }));
  }

}
