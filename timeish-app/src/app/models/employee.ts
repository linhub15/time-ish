export class Employee {
    id: number;
    firstName: string;
    lastName: string;
    fullName: string;
    email: string;
    hourlyPay: number;
    constructor(employeeInstance) {
        Object.assign(this, employeeInstance);
        this.fullName = this.firstName.concat(' ', this.lastName);
    }
}