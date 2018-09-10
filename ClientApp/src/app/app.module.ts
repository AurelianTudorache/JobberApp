import { AngularMaterialComponentsModule } from './shared/modules/angular-material-components/angular-material-components.module';
import { AppRoutingModule } from './shared/modules/app-routing/app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule, ErrorHandler } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavigationComponent } from './shared/components/navigation/navigation.component';

import { AuthService } from './shared/services/auth.service';
import { AuthInterceptor } from './shared/services/auth-interceptor';
import { AuthResponseInterceptor } from './shared/services/auth.response.interceptor';
import { AppErrorHandler } from './app.error-handler';
 
import 'hammerjs';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { CommsService } from './shared/services/comms.service';
import { ConfirmDialogComponent } from './shared/components/confirm-dialog/confirm-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    NavigationComponent,
    ConfirmDialogComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    AngularMaterialComponentsModule,
    StoreModule.forRoot({}),        
    EffectsModule.forRoot([])    
  ],
  entryComponents: [ConfirmDialogComponent],
  providers: [ 
    AuthService,
    CommsService,    
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: AuthResponseInterceptor, multi: true },
    { provide: ErrorHandler, useClass: AppErrorHandler }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
