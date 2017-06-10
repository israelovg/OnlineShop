import {Component, OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import {DataService} from '../services/data-service';
@Component({
    selector: 'category-sidebar',
    templateUrl: './category-sidebar.component.html'
})
export class CategorySidebarComponent implements OnInit{
    categories: any[];
    selectedCategoryId: number;
    constructor(private _dataService: DataService
        , private route: ActivatedRoute) { }
    ngOnInit(): void {
        this.route.queryParams.subscribe(params => {
            this.selectedCategoryId = params["category"];
        });
        this._dataService.getCategories().subscribe(data => this.categories = data);
    }
}