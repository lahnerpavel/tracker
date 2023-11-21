export class Vehicle {
    public _id: string | null = null;

    constructor(
        //public _id: number,
        public brand: string,
        public model: string,
        public registrationNumber: string,
        public locationIDs: number
    ) { }

    static createEmpty() {
        return new Vehicle('', '', '', 0);
    }

}