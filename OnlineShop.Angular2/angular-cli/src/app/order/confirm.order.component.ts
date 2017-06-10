import {Component, OnInit} from '@angular/core';
import {DataService} from '../services/data-service';
import { ActivatedRoute } from '@angular/router';
@Component({
    selector: 'confirm-order',
    templateUrl: './confirm.order.component.html'
})
export class ConfirmOrder implements OnInit {
    private orderType: string;
    private id: number;
    private order: any;
    constructor(private dataService: DataService
        , private route: ActivatedRoute) { }
    ngOnInit(): void{
        this.orderType = this.route.snapshot.queryParams['orderType']; //singleProduct,singleCart,allCart
        this.id = this.route.snapshot.params['id'];
        console.log('orderType:' + this.orderType);
        console.log('id:' + this.id);
        switch (this.orderType) {
            case 'singleProduct': this.dataService.orderProduct("?id=" + this.id)
                .subscribe(data => this.order = data);
                break;
            case 'singleCart': this.dataService.orderCart("?id=" + this.id)
                .subscribe(data => this.order = data);
                break;
            case 'allCart': this.dataService.orderCart("?id=" + this.id)
                .subscribe(data => this.order = data);
                break;
        }
    }
}