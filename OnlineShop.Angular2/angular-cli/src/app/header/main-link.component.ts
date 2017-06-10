import {Component} from '@angular/core';
@Component({
    selector: 'main-link',
    template:`<a  [routerLink]="['/products']" routerLinkActive="active" class = "navbar-brand">Women's Fashion</a>`
})
export class MainLink { };