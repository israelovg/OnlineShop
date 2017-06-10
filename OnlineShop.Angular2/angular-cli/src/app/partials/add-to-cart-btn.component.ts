import {Component, Input} from '@angular/core';
declare var $: any;
@Component({
    selector: 'add-to-cart-btn',
    template: `<a *ngIf='isAuthenticated' [routerLink]="['/addToCart',product.id]" routerLinkActive="active" class='btn btn-success'>Add To Cart</a>
                  <a *ngIf='!isAuthenticated' href="{{baseUrl+'/account/login?returnUrl=addToCart/'+product.id}}"  class='btn btn-success'>Add To Cart</a>`
})
export class AddToCartBtnComponent {
    public baseUrl: string = $('base').attr('href');
    @Input() isAuthenticated: boolean;
    @Input() product: any;
    constructor() {

        console.log(this.isAuthenticated);
    }
}