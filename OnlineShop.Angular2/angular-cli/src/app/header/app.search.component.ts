import {Component,OnInit} from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {DataService} from '../services/data-service';
declare var $: any;
@Component({
    selector: 'app-search',
    templateUrl: './app.search.component.html'
})
export class AppSearchComponent implements OnInit{
    categories: any[] = [{ id: 0, name: 'Everything' }];
    selectedCategory: any;
    search: string;
    constructor(private dataService: DataService
        , private activatedRoute: ActivatedRoute
        , private router: Router) {
        this.selectedCategory= this.categories[0];
    }
    ngOnInit(): void {
        this.dataService.getCategories().subscribe(data => {
            this.categories = this.categories.concat(data);
            if (this.activatedRoute.snapshot.queryParams['category'])
                this.selectCategory(this.activatedRoute.snapshot.queryParams['category']);
        });
        
    }
    selectCategory(categoryId: number): void {
        this.selectedCategory = this.categories.filter(function (element) { return element.id==categoryId })[0];
    };
    searchInputKeyPress($event: any): void {
        var code = $event.keyCode || $event.which;
        if (code === 13)
            this.searchClicked();
    }
    searchClicked(): void {
        var queryParams = {};
        if (this.search) {
            Object.defineProperty(queryParams, 'search', {
                enumerable: true,
                configurable: false,
                writable: true,
                value: this.search
            });
            if (this.selectedCategory.id > 0) {
                Object.defineProperty(queryParams, 'category', {
                    enumerable: false,
                    configurable: false,
                    writable: true,
                    value: this.selectedCategory.id
                });
            }
            this.router.navigate(['/products'], { queryParams: queryParams });
        }

    }
}