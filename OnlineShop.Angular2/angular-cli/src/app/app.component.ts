import {Component} from '@angular/core';
@Component({
    selector: 'app-root',
    template: `<div id='main'>
                <category-sidebar></category-sidebar>
                <router-outlet></router-outlet>
             </div>`,
})
export class AppComponent { }