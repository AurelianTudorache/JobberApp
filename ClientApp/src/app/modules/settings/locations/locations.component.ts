import { Component, OnInit, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { MatTableDataSource, MatSnackBar } from '@angular/material';
import { Location } from '../../../shared/interfaces/location';
import { SaveLocation } from '../../../shared/interfaces/saveLocation';
import { FormFieldStateMatcher } from '../../../shared/modules/angular-material-components/formfield.statematcher';
import { Validators, FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { DialogsService } from '../../../shared/services/dialogs.service';

@Component({
  selector: 'app-locations',
  templateUrl: './locations.component.html',
  styleUrls: ['./locations.component.css']
})
export class LocationsComponent implements OnInit {

  form: FormGroup;

  panelOpenState: boolean = false;
  position = 'below';

  private readonly locationsUrl = "api/employer/locations";

  displayedColumns = ['name', 'street', 'building', 'city', 'actions'];
  dataSource: MatTableDataSource<Location> | null = new MatTableDataSource;

  matcher = new FormFieldStateMatcher();

  public name = new FormControl('', [Validators.required]);
  public street = new FormControl('', [Validators.required]);
  public city = new FormControl('', [Validators.required]);
  public building = new FormControl('', [Validators.required]);

  constructor(private dialogsService: DialogsService, private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private sb: MatSnackBar, private fb: FormBuilder) { 
    this.form = fb.group({
      id: 0,
      name: this.name,
      city: this.city,
      street: this.street,
      building: this.building,
    });
  }
  
  ngOnInit() {
    this.getLocations();
  }

  submit() {
    let result$ = (this.form.value.id) ? this.http.put<SaveLocation>(this.baseUrl + 'api/employer/location/' + this.form.value.id, this.form.value) : this.http.post<SaveLocation>(this.baseUrl + 'api/employer/addlocation', this.form.value);
    result$.subscribe(location => {
      this.formReset();
      this.getLocations();
      this.sb.open('The request was successfully submitted.', 'close', { duration: 5000 });
    }, error =>  this.sb.open(error, 'close', { duration: 5000 }));   
  }

  getLocations() {
    this.http.get<Location[]>(this.baseUrl + this.locationsUrl).subscribe(result => {
      this.dataSource.data = result;
    }, error => console.error(error));
  }

  delete(id: number) {
      this.dialogsService.confirm('Confirm Delete', 'Are you sure you want to delete it?').subscribe(res => {
      if (res) {      
        this.http.delete(this.baseUrl + "api/employer/location/" + id).subscribe(res => {
          this.formReset();
          this.getLocations();
        }, error => console.log(error));
      }
    });
  }

  formReset(){
    this.form.reset({id: 0});
    Object.keys(this.form.controls).forEach(key => {
      this.form.controls[key].setErrors(null)
    });
  }

  togglePanel(element: any) {
    if(!this.panelOpenState) 
      this.panelOpenState = !this.panelOpenState;

      this.form.setValue(element);
  }

  public get formOk(): boolean {
    return this.form.valid;
  }
}
