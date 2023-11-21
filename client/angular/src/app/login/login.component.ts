import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
    loginForm!: FormGroup;

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private authService: AuthService) {}

    ngOnInit() {
        this.loginForm = this.formBuilder.group({
            email: ['', [Validators.email, Validators.required]],
            password: ['', [Validators.minLength(8), Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$/) ]]
        });
    }

    login() {
        const email = this.loginForm.value.email;
        const password = this.loginForm.value.password;

        this.authService.logIn(email, password)
            .subscribe(user => this.router.navigate(['']), errorRes => {
                alert(errorRes.error.message);
            });
    }
}
