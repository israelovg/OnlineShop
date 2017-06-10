import {Component, OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {DataService} from '../services/data-service';
@Component({
    selector: 'product-list',
    templateUrl: './product-list.component.html'
})
export class ProductListComponent implements OnInit {
    errorMessage: string;
    products: any[] = new Array();
    pageNumber: number = 0;
    loadMoreShow: boolean = false;
    public isAuthenticated: boolean;
    constructor(private dataService: DataService
        , private route: ActivatedRoute) {
        console.log("product-list.component reloded");
    }
    ngOnInit(): void {
        this.dataService.isAuthenticated().subscribe(data => {
            this.isAuthenticated = data;
        });
        this.getCatalog();
        this.route.queryParams.subscribe(params => {
            this.pageNumber = 0;
            this.getCatalog();
        });
    }
    getCatalog(): void {
        let queryString = "?page=" + this.pageNumber;
        if (this.route.snapshot.queryParams['category'])
            queryString += "&category=" + this.route.snapshot.queryParams['category'];
        if (this.route.snapshot.queryParams['search'])
            queryString += "&search=" + this.route.snapshot.queryParams['search'];
        this.dataService.getCatalog(queryString).subscribe(
            data => {
                if (this.pageNumber > 0)
                    this.products.push.apply(this.products, data.products);
                else
                    this.products = data.products;

                this.loadMoreShow = data.moreResults > 0;
            },
            error => this.errorMessage = <any>error);
    }
    loadMore(): void {
        this.pageNumber++;
        this.getCatalog();
    }
}