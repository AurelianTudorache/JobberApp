import { Injectable, Inject, PLATFORM_ID } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { map, catchError } from 'rxjs/operators';
import { TokenResponse } from '../interfaces/token.response';
import { isPlatformBrowser } from '@angular/common';
import { NavDetails } from '../interfaces/navDetails';

@Injectable()
export class AuthService {

    authKey: string = "auth";
    clientId: string = "SomeCLient";
    url: string = "api/token/auth"; 

    constructor(private http: HttpClient, @Inject(PLATFORM_ID) private platformId: any, @Inject('BASE_URL') private baseUrl: string) { }
    // performs the login
    login(userName: string, password: string): Observable<boolean> {
        var data = {
            userName: userName,
            password: password,
            clientId: this.clientId,
            // required when signing up with username/password
            grantType: "password",
            // space-separated list of scopes for which the token is issued
            scope: "offline_access profile email"
        };

        return this.getAuthFromServer(this.url, data);
    }

    // try to refresh token
    refreshToken(): Observable<boolean> { 

        var data = {
            clientId: this.clientId,
            // required when signing up with username/password
            grantType: "refreshToken",
            refreshToken: this.getAuth()!.refreshToken,
            // space-separated list of scopes for which the token is issued
            scope: "offline_access profile email"
        };

        return this.getAuthFromServer(this.url, data);
    }

    // retrieve the access & refresh tokens from the server
    getAuthFromServer(url: string, data: any): Observable<boolean> {
        return this.http.post<TokenResponse>(url, data)
            .pipe(map((res) => {
                let token = res && res.token;
                // if the token is there, login has been successful
                if (token) {
                    // store username and jwt token
                    this.setAuth(res);
                    // successful login
                    return true;
                }

                // failed login
                return throwError('Unauthorized');
            }))
            .pipe(catchError(error => {
                return new Observable<any>(error);
            }));
    }

    // performs the logout
    logout(): boolean {
        this.setAuth(null);
        return true;
    }

    // Persist auth into localStorage or removes it if a NULL argument is given
    setAuth(auth: TokenResponse | null): boolean {
        if (isPlatformBrowser(this.platformId)) {
            if (auth) {
                localStorage.setItem( 
                    this.authKey,
                    JSON.stringify(auth));
            }
            else {
                localStorage.removeItem(this.authKey);
            }
        }
        return true;
    }

    // Retrieves the auth JSON object (or NULL if none)
    getAuth(): TokenResponse | null {
        if (isPlatformBrowser(this.platformId)) {
            var i = localStorage.getItem(this.authKey);
            if (i) {
                return JSON.parse(i);
            }
        }
        return null;
    }

    // Returns TRUE if the user is logged in, FALSE otherwise.
    isLoggedIn(): boolean {
        if (isPlatformBrowser(this.platformId)) {
            return localStorage.getItem(this.authKey) != null;
        }
        return false;
    }

    get displayName(){
        return this.getAuth()!.displayName;
    }

    // getNavDetails(): Observable<NavDetails> {    
    //     return this.http.get<NavDetails>(this.baseUrl + "api/user/details");    
    // }  

}
