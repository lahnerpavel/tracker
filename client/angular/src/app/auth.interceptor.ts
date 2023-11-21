import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { BehaviorSubject, from, Observable } from "rxjs";
import { filter, take, switchMap } from 'rxjs/operators';
import { AuthService } from "./services/auth.service";

@Injectable()
export class AuthInterceptor implements HttpInterceptor {
    private readonly pathsWithoutToken = ['login', 'register', 'refreshtoken'];
    private isRefreshing: boolean = false;
    private tokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);

    constructor(private authService: AuthService, private router: Router) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<any> {
        return from(this.handle(request, next));
    }

    private async handle(request: HttpRequest<any>, next: HttpHandler) {
        if (!this.pathsWithoutToken.some(path => request.url.includes(path))) {
            if (!this.isRefreshing) {
                this.isRefreshing = true;
                this.tokenSubject.next(null);
    
                try {
                    const token = await this.authService.getAccessToken();
                    if (token) {
                        request = request.clone({
                            setHeaders: { 'access-token': token }
                        });
    
                        this.tokenSubject.next(token);
                    }
                }
                catch(error) {
                    console.log(error);
                    this.authService.logOut().subscribe();
                    this.router.navigate(['/login']);
                }
                this.isRefreshing = false;
            }
            else {
                return this.tokenSubject.pipe(
                    filter(token => token != null),
                    take(1),
                    switchMap(jwt => {
                        request = request.clone({
                            setHeaders: { 'access-token': jwt }
                        });
                        return next.handle(request);
                })).toPromise();
            }
        }
    
        return next.handle(request).toPromise();
    }

}
