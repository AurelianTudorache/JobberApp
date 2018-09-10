import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { JobsRoutingModule } from './jobs-routing.module';
import { JobsListComponent } from './jobs-list/jobs-list.component';
import { JobsPostedComponent } from './jobs-posted/jobs-posted.component';
import { JobsFilledComponent } from './jobs-filled/jobs-filled.component';
import { JobsTodayComponent } from './jobs-today/jobs-today.component';
import { JobsCompletedComponent } from './jobs-completed/jobs-completed.component';
import { AngularMaterialComponentsModule } from './../../shared/modules/angular-material-components/angular-material-components.module';
import { JobadDialogComponent } from './jobad-dialog/jobad-dialog.component';
import { TruncateStringPipe } from '../../shared/pipes/truncate-string.pipe';
import { DialogsService } from '../../shared/services/dialogs.service';
import { AuthGuard } from '../../shared/services/auth.guard';

@NgModule({
  imports: [
    CommonModule,
    JobsRoutingModule,
    AngularMaterialComponentsModule
  ],
  entryComponents: [JobadDialogComponent],
  declarations: [TruncateStringPipe, JobsListComponent, JobsPostedComponent, JobsFilledComponent, JobsTodayComponent, JobsCompletedComponent, JobadDialogComponent],
  providers: [DialogsService, AuthGuard]
})
export class JobsModule { }
