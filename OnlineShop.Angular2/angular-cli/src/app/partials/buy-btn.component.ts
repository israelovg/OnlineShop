import {Component, Input} from '@angular/core';
declare var $: any;
@Component({
    selector: 'buy-btn',
    template: `<a *ngIf='isAuthenticated' [routerLink]="['/confirmOrder',product.id]"  [queryParams]="{ orderType: 'singleProduct' }" routerLinkActive="active" class='btn btn-warning btn-buy'>Buy</a>
                  <a *ngIf='!isAuthenticated' href="{{baseUrl+'/account/login?returnUrl='+baseUrl+'confirmOrder/'+product.id}}"  class='btn btn-warning btn-buy'>Buy</a>`
})
export class BuyBtmComponent {
    private baseUrl: string = $('base').attr('href');
    @Input() isAuthenticated: boolean;
    @Input() product: any;
}