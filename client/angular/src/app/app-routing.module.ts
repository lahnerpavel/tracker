import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VehiclesListComponent } from "./vehicles-list/vehicles-list.component";
import { LoginComponent } from './login/login.component';
import { MainComponent } from './main/main.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuard } from './guards/auth.guard';
import { AppGuard } from './guards/app.guard';

const routes: Routes = [
    {
        path: 'list', component: MainComponent, canActivate: [AppGuard],
        children: [
            { path: '', redirectTo: '/list/vehicles', pathMatch: 'full' },
            { path: 'vehicles', component: VehiclesListComponent }
        ]
    },
    { path: 'login', component: LoginComponent, canActivate: [AuthGuard] },
    { path: 'register', component: RegisterComponent, canActivate: [AuthGuard] },
    { path: '', redirectTo: '/list/vehicles', pathMatch: 'full' }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
