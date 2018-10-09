export class Activity {
    id: number;
    date: Date;
    hours: number;
    description: string;
    amount: number;
    timeSheetId: number;

    constructor(id: number) {
        this.id = id;
    }
}
