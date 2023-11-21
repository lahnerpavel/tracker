import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AuthInterceptor } from './auth.interceptor';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalComponent } from './components/modal/modal.component';
import { VehiclesListComponent } from './vehicles-list/vehicles-list.component';
import { VehicleFilterComponent } from './components/vehicle-filter/vehicle-filter.component';
import { VehicleModifyComponent } from './vehicle-modify/vehicle-modify.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { MainComponent } from './main/main.component';

@NgModule({
    declarations: [
        AppComponent,
        ModalComponent,
        VehiclesListComponent,
        VehicleFilterComponent,
        VehicleModifyComponent,
        LoginComponent,
        RegisterComponent,
        MainComponent
    ],
    imports: [
        BrowserModule,
        AppRoutingModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule
    ],
    providers: [
        {
            provide: HTTP_INTERCEPTORS,
            useClass: AuthInterceptor,
            multi: true
        }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
