import {Component, Input} from '@angular/core';
@Component({
    selector: 'order-product',
    templateUrl: './order.product.component.html'
})
export class OrderProductComponent {
    @Input() orderDetail: any;
}