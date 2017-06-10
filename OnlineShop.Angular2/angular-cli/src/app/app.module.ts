import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpModule, JsonpModule } from '@angular/http';
import { FormsModule, ReactiveFormsModule }   from '@angular/forms';
import { RouterModule }   from '@angular/router';
import { AppComponent } from './app.component';
import {ProductListComponent} from './products/product-list.component';
import {MediumProductComponent} from './products/medium-product.component';
import {SmallProductComponent} from './products/small-product.component';
import {ProductComponent} from './products/product.component';
import {CategorySidebarComponent} from './categories/category-sidebar.component';
import {DataService} from './services/data-service';
import {AppSearchComponent} from './header/app.search.component';
import {AddToCartBtnComponent} from './partials/add-to-cart-btn.component';
import {BuyBtmComponent} from './partials/buy-btn.component';
import {MainLink} from './header/main-link.component';
import {AddToCartComponent} from './carts/add.to.cart.component';
import {CartComponent} from './carts/cart.component';
import { DataTablesModule } from 'angular-datatables';
import {ConfirmOrder} from './order/confirm.order.component';
import {OrderProductComponent} from './order/order.product.component';

@NgModule({
    imports: [BrowserModule, FormsModule, ReactiveFormsModule,
        HttpModule,
        JsonpModule,
        DataTablesModule,
        RouterModule.forRoot([
            { path: '', pathMatch: 'prefix',redirectTo:'products' },
            { path: 'products', component: ProductListComponent },
            { path: 'product/:id', component: ProductComponent },
            { path: 'addToCart/:id', component: AddToCartComponent },
            { path: 'cart', component: CartComponent },
            { path: 'confirmOrder/:id', component: ConfirmOrder}
        ])],
    declarations: [AppComponent
        , ProductListComponent, MediumProductComponent
        , SmallProductComponent, ProductComponent
        , CategorySidebarComponent, AppSearchComponent
        , AddToCartBtnComponent, BuyBtmComponent, MainLink, AddToCartComponent, CartComponent
        , ConfirmOrder, OrderProductComponent],
    providers: [DataService], // for sharing same instance to consumer that get injection of object
    bootstrap: [AppComponent, AppSearchComponent, MainLink]
})
export class AppModule { }