import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../environments/environment'
import { Product } from '../models/Product';
import { User } from '../models/User';

@Injectable({ providedIn: 'root' })
export class ProductService {
    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(private http: HttpClient) {
        
    }


    getAll() {
        return this.http.get<Product[]>(`${environment.apiUrl}/Product/GetAll`)      
    }
    get(id:string) {
        return this.http.get<Product>(`${environment.apiUrl}/Product/Get/`+id)      
    }

    
}
