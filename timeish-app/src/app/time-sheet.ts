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
}
