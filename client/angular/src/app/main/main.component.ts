import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { VehicleModifyComponent } from '../vehicle-modify/vehicle-modify.component';
import { VehiclesService } from '../services/vehicles.service';

@Component({
    selector: 'app-main',
    templateUrl: './main.component.html',
    styleUrls: ['./main.component.css']
})
export class MainComponent {

    title = 'client';

    public isVehicleModalClosed = true;

    @ViewChild(VehicleModifyComponent, { static: false })
    vehicleAddRef!: VehicleModifyComponent;

    constructor(
        private vehiclesService: VehiclesService,
        public authService: AuthService,
        private router: Router
    ) { }

    public addVehicle() {
        if (this.vehicleAddRef.vehicle != null && this.vehicleAddRef.valid) {
            this.vehiclesService.addVehicle(this.vehicleAddRef.vehicle)
                .subscribe(
                    (response) => {
                        this.router.onSameUrlNavigation = 'reload';
                        this.router.routeReuseStrategy.shouldReuseRoute = function () {
                            return false;
                        }
                        this.vehicleAddRef.formRef.resetForm();
                        this.isVehicleModalClosed = true;
                        this.router.navigate(['/list/vehicles']);
                    }, (error) => {
                        alert('Chyba: ' + error.toLocaleString());
                    }
                );
        }
    }

    public logOut() {
        this.authService.logOut().subscribe();
        this.router.navigate(['/login']);
    }

}
