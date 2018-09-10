import { Component, OnInit, Inject } from '@angular/core';
import { Card } from '../../../shared/interfaces/card';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { SaveCard } from '../../../shared/interfaces/saveCard';
import { FormControl, Validators, FormGroup, FormBuilder } from '@angular/forms';
import { FormFieldStateMatcher } from '../../../shared/modules/angular-material-components/formfield.statematcher';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-credit-card',
  templateUrl: './credit-card.component.html',
  styleUrls: ['./credit-card.component.css']
})
export class CreditCardComponent implements OnInit {

  form: FormGroup;

  private readonly cardUrl = "api/employer/card";

  matcher = new FormFieldStateMatcher();

  public nameOnCardFC = new FormControl('', [Validators.required]);
  public cardNumberFC = new FormControl('', [ Validators.compose([ Validators.required, Validators.pattern("\\d{16}") ]) ]);
  public cardTypeFC = new FormControl('', [Validators.required]);
  public expMonthFC = new FormControl('', [Validators.required]);
  public expYearFC = new FormControl('', [Validators.required]);
  public cvcFC = new FormControl('', [ Validators.compose([ Validators.required, Validators.pattern("\\d{3}") ]) ]);
  
  
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private sb: MatSnackBar, private fb: FormBuilder) {
    this.form = fb.group({
      id: 0,
      nameOnCard: this.nameOnCardFC,
      cardType: this.cardTypeFC,
      cardNumber: this.cardNumberFC,
      expMonth: this.expMonthFC,
      expYear: this.expYearFC,
      cvc: this.cvcFC
    });
  }

  ngOnInit() {
    this.http.get<Card>(this.baseUrl + this.cardUrl).subscribe(result => {
      this.form.patchValue(result);
    }, error => this.sb.open(error, 'close', { duration: 5000 }));
  }

  submit() {
    this.http.put<SaveCard>(this.cardUrl + '/' + this.form.value.id, this.form.value).subscribe(card => {
      this.sb.open('The request was successfully submitted.', 'close', { duration: 5000 });
    }, error =>  this.sb.open(error, 'close', { duration: 5000 }));

    // let result$ = (this.card.id) ? this.http.put<SaveCard>(this.cardUrl + '/' + this.card.id, this.card) : this.http.post<SaveCard>(this.cardUrl, this.card);
    // result$.subscribe(card => {
    //   this.sb.open('The request was successfully submitted.', 'close', { duration: 5000 });
    //   this.router.navigateByUrl(`settings`);
    // }, error =>  this.sb.open(error, 'close', { duration: 5000 }));
  }

  // submit(){
  //   let result$ = (this.card.id) ? this.restService.sendRequest(RequestMethod.Put, this.cardUrl + this.card.id, this.card) : this.restService.sendRequest(RequestMethod.Post, 'api/admin/groups', this.group);
  //   result$.subscribe(group => {
  //     this.sb.open('The request was successfully submitted.', 'close', { duration: 2000 });
  //     this.router.navigateByUrl(`/admin/groups/${group.id}`);
  //   });
  // }

  // updateCard() {
  //   this.http.post<SaveCard>(this.baseUrl + this.cardUrl, this.card).subscribe(result => 
  //     { this.sb.open('The message was successfully posted.', 'close', { duration: 5000 })
  //     }, error => { this.sb.open('The message was not submitted, an error occured.', 'close', { duration: 5000 })
  //   });  
  // }

  // private setCard(c: Card) {
  //   this.card.id = c.id;
  //   this.card.nameOnCard = c.nameOnCard;
  //   this.card.cardType = c.cardType;
  //   this.card.cardNumber = c.cardNumber;
  //   this.card.expMonth = c.expMonth;
  //   this.card.expYear = c.expYear;
  //   this.card.cvc = c.cvc;
  // }

  public get formOk(): boolean {
    return this.form.valid
  }

}

