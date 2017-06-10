import {Injectable} from '@angular/core';
import {Observable} from 'rxjs/Observable';
import {Http, Response} from '@angular/http';
//import 'rxjs/Rx';
import 'rxjs/add/operator/map'
import 'rxjs/add/operator/do'
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/share';
import 'rxjs/add/observable/throw';
import 'rxjs/add/observable/of';
declare var $: any;
@Injectable()
export class DataService {
    private _dataServiceUrl = $('base').attr('href') + '/api/dataservice/';
    private categories: any[];
    private observable: Observable<any>;
    constructor(private _http: Http) {
       // this.getCategories().subscribe(data => this.categories = data);
    }
    getCatalog(queryString: string): Observable<any> {
        return this._http.get(this._dataServiceUrl + 'getCatalog' + queryString)
            .map((response: Response) => response.json())
            //.do(data => console.log("All : " + JSON.stringify(data)))
            .catch(this.handleError);
    }
    getCategories(): Observable<any> {
        // if `categories` is available just return it as `Observable`
        if (this.categories)
            return Observable.of(this.categories);
        else if (this.observable)
            // if `this.observable` is set then the request is in progress
           // return the `Observable` for the ongoing request
            return this.observable;
        else {
            this.observable = this._http.get(this._dataServiceUrl + 'getCategories')
                .map((response: Response) => response.json())
                .do(data => {
                    // when the cached data is available we don't need the `Observable` reference anymore
                    this.observable = null;
                    this.categories = data;
                })
                .catch(this.handleError).share();
            return this.observable;
        }
    }
    isAuthenticated(): Observable<boolean> {
        return this._http.get(this._dataServiceUrl + 'isAuthenticated')
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }
    getProduct(queryString: string):  Observable<any> {
        return this._http.get(this._dataServiceUrl + 'getProduct' + queryString)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    };
    addProductReview(json: any): Observable<any> {
        return this._http.post(this._dataServiceUrl + 'addProductReview', json)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    };
    addToCart(queryString: string): Observable<any> {
        return this._http.get(this._dataServiceUrl + 'addToCart' + queryString)
        .map((response: Response) => response.json())
        .catch(this.handleError);
    }
    getUserCart(): Observable<any> {
        return this._http.get(this._dataServiceUrl + 'getUserCart')
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }
    removeFromCart(cart: any): Observable<any> {
        return this._http.post(this._dataServiceUrl +'removeFromCart',cart)
            .map((response: Response) => response.json())
            .catch(this.handleError);
    }
    orderProduct(queryString: string): Observable<any> {
        return this._http.get(this._dataServiceUrl + 'orderProduct' + queryString)
            .map((response: Response) => response.json())
            .do(data => console.log(data))
            .catch(this.handleError);
    }
    orderCart(queryString: string): Observable<any> {
        return this._http.get(this._dataServiceUrl + 'OrderCart' + queryString)
            .map((response: Response) => response.json())
            .do(data => console.log(data))
            .catch(this.handleError);
    }
    orderAllCart(queryString: string): Observable<any> {
        return this._http.get(this._dataServiceUrl + 'OrderAllCart=' + queryString)
            .map((response: Response) => response.json())
            .do(data => console.log(data))
            .catch(this.handleError);
    }
    private handleError(error: Response) {
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    };
}