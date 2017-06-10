import {Component, Input} from '@angular/core';
@Component({
    selector: 'small-product',
    templateUrl: './small-product.component.html'
})
export class SmallProductComponent {
    @Input() product: any;
    @Input() isAuthenticated: boolean;
}