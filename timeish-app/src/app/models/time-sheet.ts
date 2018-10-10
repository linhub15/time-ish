import { Activity } from "./activity";
import { PayPeriod } from "./pay-period";
import { Employee } from "./employee";

export class TimeSheet {
    id: number;
    issued: Date;
    submitted: Date;
    approved: Date;
    payPeriodId: number;
    payPeriod: PayPeriod;
    employeeId: number;
    employee: Employee;
    activities: Array<Activity>;

    constructor(instance) {
        this.activities = new Array<Activity>();   // need this for activities.length check
        Object.assign(this, instance);
        Object.assign(this.employee, new Employee(instance.employee))
    }

    totalHours(): number {
        let hours: number = 0;
        this.activities.forEach(activity => {
            hours += isNaN(activity.hours) ? 0 : activity.hours;
        });
        return hours;
    }

    totalPay(): number {
        let pay: number = 0;
        this.activities.forEach(activity => {
            pay += isNaN(activity.pay) ? 0 : activity.pay;
        })
        return pay;
    }
}
