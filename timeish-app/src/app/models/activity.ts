export class Activity {
    id: number;
    date: Date;
    hours: number;
    description: string;
    pay: number;
    timeSheetId: number;

    constructor(id: number) {
        this.id = id;
    }

    // pay(hourlyPay: number): number {
    //     return hourlyPay * this.hours;
    // }
}
