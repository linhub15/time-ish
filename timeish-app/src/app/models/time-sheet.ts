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
