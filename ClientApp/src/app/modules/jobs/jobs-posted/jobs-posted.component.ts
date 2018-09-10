import { Component, OnInit, Inject, Input } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JobAd } from '../../../shared/interfaces/jobAd';
import { MatSnackBar, MatDialog } from '@angular/material';
import { JobadDialogComponent } from '../jobad-dialog/jobad-dialog.component';
import { DialogsService } from '../../../shared/services/dialogs.service';

@Component({
  selector: 'app-jobs-posted',
  templateUrl: './jobs-posted.component.html',
  styleUrls: ['./jobs-posted.component.css']
})
export class JobsPostedComponent implements OnInit {

  position = 'below';

  private readonly jobAdsUrl = "api/employer/jobads";

  constructor(private dialogsService: DialogsService, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private sb: MatSnackBar, public dialog: MatDialog) { }

  jobAds: JobAd[];
  jobAd: any;

  openDialog(jobAd): void {
    let dialogRef = this.dialog.open(JobadDialogComponent, {
      width: '350px',
      data: jobAd 
    });

    // dialogRef.afterClosed().subscribe(result => {
    //   console.log('The dialog was closed');
    //   var animal = result;
    // });
  }

  ngOnInit() {
    this.getJobAds();
  }

  getJobAds() {
    this.http.get<JobAd[]>(this.baseUrl + this.jobAdsUrl).subscribe(result => {
      this.jobAds = result;
    }, error => this.sb.open(error, 'close', { duration: 5000 }));
  }

  deleteJobAd(id: number) {
    this.dialogsService.confirm('Confirm Delete', 'Are you sure you want to delete it?').subscribe(res => {
      if (res) {  
        this.http.delete(this.baseUrl + "api/employer/jobad/" + id).subscribe(res => {
          this.getJobAds();
        }, error => console.log(error));
      }
    })
  }

}

