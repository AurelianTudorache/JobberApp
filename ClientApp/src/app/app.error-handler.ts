import { MatSnackBar } from "@angular/material";
import { ErrorHandler, Inject, Injectable, Injector, NgZone } from "@angular/core";

@Injectable()
export class AppErrorHandler implements ErrorHandler {
   
    constructor(@Inject(NgZone) private ngZone: NgZone, @Inject(Injector) private inj: Injector) { }

    private get sb(): MatSnackBar {
        return this.inj.get(MatSnackBar);
    }
    
    handleError(error: any): void {
        this.ngZone.run(() => {
            this.sb.open(error, 'close', {duration: 5000});
        });
    }
    
}