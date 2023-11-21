import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
    registerForm!: FormGroup;

    constructor(
        private formBuilder: FormBuilder,
        private router: Router,
        private authService: AuthService) { }

    ngOnInit() {
        this.registerForm = this.formBuilder.group({
            email: ['', [Validators.email, Validators.required]],
            password: ['', [Validators.minLength(8), Validators.required, Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d\w\W]{8,}$/)]],
            passwordConfirm: ['', [Validators.required]],
        },
            {
                validators: (group: AbstractControl): ValidatorFn | null => {
                    const passwordValue = group.get('password')?.value;
                    const passwordConfirmValue = group.get('passwordConfirm')?.value;
                    if (passwordValue !== passwordConfirmValue)
                        group.get("passwordConfirm")?.setErrors({ notSame: true });
                    return null;
                }
            });
    }

    register() {
        const email = this.registerForm.value.email;
        const password = this.registerForm.value.password;

        this.authService.register(email, password)
            .subscribe((user) => this.router.navigate(['/login']));
    }
}
