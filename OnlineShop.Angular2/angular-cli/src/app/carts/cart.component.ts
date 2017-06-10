import {Component, OnInit} from '@angular/core';
import {DataService} from '../services/data-service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs/Rx';
@Component({
    selector: 'cart',
    templateUrl: './cart.component.html'
})
export class CartComponent implements OnInit {
    public userCarts: any[];
    public totalAmount: number=0;
    dtOptions: any = {};
    dtTrigger: Subject<any> = new Subject<any>();
    constructor(private dataService: DataService, private router: Router) {
    }
    ngOnInit(): void {
        this.dtOptions = {
            paginationType: 'full_numbers',
            displayLength: 10
        };
        this.dataService.getUserCart().subscribe(data => {
            this.userCarts = data;
            this.userCarts.forEach(x => this.totalAmount += x.quantity*x.product.price);
            this.dtTrigger.next();
        });
    }
    removeFromCart(cart: any): void {
        this.dataService.removeFromCart(cart).subscribe(data => {
            this.userCarts = this.userCarts.filter(function (elem: any, index: number){
                return cart.id != elem.id;
            });
        });
    }
    orderCart(cart: any): void {
        this.router.navigate(['/confirmOrder', cart.id], { queryParams: { orderType: 'singleCart' } });
    }
    orderAllCarts(): void {
        this.router.navigate(['/confirmOrder', -1], { queryParams: { orderType: 'allCart' } });
    }
}