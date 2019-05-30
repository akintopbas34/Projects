import { Order } from './order';

export class RefusalInformation {
    id: number;
    orderId: number;
    iadeNedeni: string;
    iadeTarihi: Date;
    iadeMiktari: number;
    order: Order;
}
