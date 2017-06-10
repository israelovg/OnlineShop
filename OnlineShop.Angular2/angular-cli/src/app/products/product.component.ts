import {Component, OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgForm, FormControl, Validators } from '@angular/forms';
import {DataService} from '../services/data-service';
@Component({
    providers: [DataService],
    templateUrl: './product.component.html'
})
export class ProductComponent implements OnInit {
    private productId: number;
    public product: any = {};
    public userProductReview: any = { review: "", rating: 0 };
    public isAuthenticated: boolean;
    constructor(private _activatedRoute: ActivatedRoute,
        private _dataService: DataService) {

    }
    ngOnInit(): void {
        this._dataService.isAuthenticated().subscribe(data => {
            this.isAuthenticated = data;
            console.log(this.isAuthenticated)
        });
        this._activatedRoute.params.subscribe(params => {
            this.productId = +params['id']; // (+) converts string 'id' to a number
            this.userProductReview.productId = this.productId;
            this._dataService.getProduct('?id=' + this.productId)
                .subscribe(data => {
                    this.product = data;
                });
        });
    };
    submitForm(userProductReview: any, form: NgForm): void {
        if (form.valid) {
            this._dataService.addProductReview(userProductReview)
                .subscribe(data => this.product.productReviews = data);
        }
    };
}