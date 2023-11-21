import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from "@angular/common/http";
import { Observable } from "rxjs";
import { Vehicle } from "./models/vehicle.model";
import { VehicleFilter } from "./models/vehicle-filter.model";

@Injectable({
    providedIn: 'root'
})
export class VehiclesService {

    constructor(
        private readonly httpClient: HttpClient
    ) { }

    addVehicle(vehicle: Vehicle) {
        const body = this.getVehicleRequestBody(vehicle);
        return this.httpClient.post('/api/vehicles', body);
    }
    
    editVehicle(vehicle: Vehicle) {
        const body = this.getVehicleRequestBody(vehicle);
        return this.httpClient.put(`/api/vehicles/${vehicle._id}`, body);
    }
    
    removeVehicle(vehicle: Vehicle) {
        return this.httpClient.delete(`/api/vehicles/${vehicle._id}`);
    }
    
    private getVehicleRequestBody(vehicle: Vehicle): object {
        return {
            brand: vehicle.brand,
            model: vehicle.model,
            registrationNumber: vehicle.registrationNumber,
            locationIDs: vehicle.locationIDs
        };
    }

    getVehicle(id: number): Observable<Vehicle> {
        return this.httpClient.get<Vehicle>(`/api/vehicle/${id}`);
    }

    getVehicles(vehicleFilter: VehicleFilter): Observable<Array<Vehicle>> {
        let params = new HttpParams();
        for (const key in vehicleFilter) { // Projíždíme každou vlastnost modelu a přidáváme ji do httpParams, když není null.
            if (vehicleFilter.hasOwnProperty(key)) {
                const value = (vehicleFilter as any)[key];
                if (value !== null) {
                    params = params.set(key, value.toString());
                }
            }
        }

        return this.httpClient.get<Array<Vehicle>>('/api/vehicles', { params });
    }

    private getHttpParams(filter: VehicleFilter): HttpParams {
        let params = new HttpParams();

        if (filter != null && filter.limit !== null) {
            params = params.set('limit', filter.limit.toString());
        }

        return params;
    }

}