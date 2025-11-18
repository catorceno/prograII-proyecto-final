
export interface SeatingPlan {
    theaterId: number;
    rows: Row[];
}

export interface Row {
    name: string;
    seats: Seat[];
}
export interface Seat {
    column: number;
    number: number;
    side: Side
}

export enum Side {
    L,
    R
}