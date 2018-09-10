import { Component, OnInit, Inject } from '@angular/core';
import { MatTableDataSource, MatSnackBar } from '@angular/material';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-settings-page',
  templateUrl: './settings-page.component.html',
  styleUrls: ['./settings-page.component.css']
})
export class SettingsPageComponent implements OnInit {
  panelOpenState: boolean = false;

  constructor(){}
  ngOnInit(){}

}
