import { Activity } from "./activity";
import { PayPeriod } from "./pay-period";

export class TimeSheet {
    id: number;
    issued: Date;
    submitted: Date;
    approved: Date;
    employeeName: string;
    payPeriodId: number;
    payPeriod: PayPeriod;
    activities: Array<Activity>;

    totalHours(): number {
        let hours: number = 0;
        this.activities.forEach(activity => {
            hours += activity.hours;
        });
        return hours;
    }

    totalPay(): number {
        let pay: number = 0;
        this.activities.forEach(activity => {
            pay += activity.pay;
        })
        return pay;
    }
}
