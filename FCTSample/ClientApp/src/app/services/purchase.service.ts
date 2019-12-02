import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { environment } from '../environments/environment'
import { Purchase } from '../models/Purchase';

@Injectable({ providedIn: 'root' })
export class PurchaseService {    
    constructor(private http: HttpClient) {        
    }

    get(id:string){
        return this.http.get<Purchase>(`${environment.apiUrl}/Purchase/Get/` + id)      
    }
    remove(id:string){
        return this.http.get<Purchase>(`${environment.apiUrl}/Purchase/Remove/` + id)      
    }
    getAllForUser() {
        return this.http.get<Purchase[]>(`${environment.apiUrl}/Purchase/GetAllForUser`)      
    }

    purchaseByProductId(id: string) {
        return this.http.get<Purchase>(`${environment.apiUrl}/Purchase/PurchaseProductById/` + id)      
    }
    

    
}
