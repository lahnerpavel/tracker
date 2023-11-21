import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { VehiclesService } from "../../services/vehicles.service";
import { VehicleFilter } from "../../services/models/vehicle-filter.model";
//import { Vehicle } from 'src/app/services/models/vehicle.model';

@Component({
    selector: 'app-vehicle-filter',
    templateUrl: './vehicle-filter.component.html',
    styleUrls: ['./vehicle-filter.component.css']
})
export class VehicleFilterComponent implements OnInit {

    @Output()
    public onFilter: EventEmitter<void> = new EventEmitter<void>();

    vehicleFilter = new VehicleFilter();

    //public brands: Array<string> = [];
    //public models: Array<string> = [];
    //public registrationNumbers: Array<string> = [];

    constructor(
        private readonly vehiclesService: VehiclesService
    ) { }

    ngOnInit(): void {
    }

}
