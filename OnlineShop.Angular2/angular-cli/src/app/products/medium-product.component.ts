import {Component, Input} from '@angular/core';
@Component({
    selector: 'medium-product',
    templateUrl: './medium-product.component.html'
})
export class MediumProductComponent {
    @Input() product: any;
    @Input() isAuthenticated: boolean;
}