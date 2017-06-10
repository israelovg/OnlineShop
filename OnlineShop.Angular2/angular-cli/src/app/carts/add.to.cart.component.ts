import {Component, OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {DataService} from '../services/data-service';
declare var $: any;
@Component({
    selector: 'add-to-cart',
    template:`<div></div>`
})
export class AddToCartComponent implements OnInit {
    private isAuthenticated: boolean;
    private productId: number;
    constructor(private dataService: DataService
        , private activatedRoute: ActivatedRoute
        , private router: Router) {
    }
    ngOnInit(): void {
        this.activatedRoute.params.subscribe(params => {
            this.productId = +params['id']; // (+) converts string 'id' to a number
            this.dataService.isAuthenticated().subscribe(data => {
                if (data === true) {
                    this.dataService.addToCart('?id=' + this.productId).subscribe(data => {
                        this.router.navigate(['/cart']);
                    });
                }
                else
                    location.href = $('base').attr('href') + 'account/login?returnUrl=' + $('base').attr('href') + 'addToCart/ ' + this.productId;
            });
        });

    }
}