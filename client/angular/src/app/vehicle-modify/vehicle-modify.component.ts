import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Vehicle } from "../services/models/vehicle.model";
import { NgForm } from "@angular/forms";
import { VehiclesService } from "../services/vehicles.service";

@Component({
    selector: 'app-vehicle-modify',
    templateUrl: './vehicle-modify.component.html',
    styleUrls: ['./vehicle-modify.component.css']
})
export class VehicleModifyComponent implements OnInit {

    @Input()
    vehicle: Vehicle | null = Vehicle.createEmpty();

    @ViewChild(NgForm, { static: false })
    formRef!: NgForm;

    constructor(private vehiclesService: VehiclesService) { }

    get valid() {
        return this.formRef.form.valid;
    }

    ngOnInit(): void {
    }
}