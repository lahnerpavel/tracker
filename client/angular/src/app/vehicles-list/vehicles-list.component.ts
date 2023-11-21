import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { Vehicle } from "../services/models/vehicle.model";
import { VehiclesService } from "../services/vehicles.service";
import { VehicleFilterComponent } from "../components/vehicle-filter/vehicle-filter.component";
import { VehicleModifyComponent } from "../vehicle-modify/vehicle-modify.component";

@Component({
    selector: 'app-vehicles-list',
    templateUrl: './vehicles-list.component.html',
    styleUrls: ['./vehicles-list.component.css']
})

export class VehiclesListComponent implements AfterViewInit {

    vehicles: Array<Vehicle> = [];

    @ViewChild(VehicleFilterComponent, { static: false })
    private vehicleFilterRef!: VehicleFilterComponent;

    public selectedVehicle: Vehicle | null = null;

    public isDetailModalClosed: boolean = true;
    public isEditModalClosed: boolean = true;

    @ViewChild(VehicleModifyComponent, { static: false })
    private vehicleEditRef!: VehicleModifyComponent;

    constructor(
        private readonly vehiclesService: VehiclesService
    ) { }

    ngAfterViewInit(): void {
        this.filter();
    }

    public showDetail() {
        if (this.selectedVehicle == null) return;

        this.isDetailModalClosed = false;
    }

    public editVehicle() {
        if (this.selectedVehicle == null) return;

        if (this.vehicleEditRef.formRef.form.valid) {
            this.vehiclesService.editVehicle(this.selectedVehicle)
                .subscribe((result) => {
                    this.isEditModalClosed = true;
                    this.selectedVehicle = null;
                    this.filter();
                }, (error) => {
                    alert(`Chyba: ${error.toLocaleString()}`);
                });
        }
    }

    public removeVehicle() {
        if (this.selectedVehicle == null) return;

        if (confirm('Opravdu chcete odebrat toto vozidlo?')) {
            this.vehiclesService.removeVehicle(this.selectedVehicle)
                .subscribe((data) => {
                    this.filter();
                });
        }
    }

    filter() {
        const vehicleFilter = this.vehicleFilterRef.vehicleFilter; // Zde získáme filter model
        this.vehiclesService.getVehicles(vehicleFilter)
            .subscribe(
                (vehicles: Array<Vehicle>) => this.vehicles = vehicles, // Podobné `then` metodě
                (error) => console.log(error), // Podobné `catch()` metodě
                () => { } // Krajně podobné `complete()` metodě. Tato funkce tady ani nemusí být, jelikož je prázdná.
            );
    }

}
