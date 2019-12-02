import { Component, OnInit, ViewChild, ViewChildren, QueryList } from '@angular/core';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import {ProductService} from '../services/product.service';
import {PurchaseService} from '../services/purchase.service';
import {AuthService} from '../services/auth.service';
import { Product } from '../models/Product';
import { Purchase } from '../models/Purchase';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
  
})
export class HomeComponent {

  purchases:Purchase[];
  products:Product[];
  _productService:ProductService;
  _purchaseService:PurchaseService;
  _authService:AuthService;
  constructor(productService:ProductService,
             purchaseService:PurchaseService,
             authService:AuthService,
             private router: Router){

    this._productService = productService
    this._purchaseService = purchaseService
    this._authService = authService;
  }

  

  displayedColumns: string[] = ['id', 'name', 'description', 'price'];
  dataSource = new MatTableDataSource<Product>();

  displayedColumnsPurchases: string[] = ['id', 'name', 'description', 'price'];
  purchasesDataSource = new MatTableDataSource<Product>();
  
  
  @ViewChildren(MatPaginator) paginator = new QueryList<MatPaginator>();
  @ViewChildren(MatSort) sort = new QueryList<MatSort>();


  
  ngOnInit() {
    this._productService.getAll()
      .subscribe((products: Product[]) => {
        this.products = products;
        this.dataSource = new MatTableDataSource(products);
        this.dataSource.sort = this.sort.toArray()[0];
        this.dataSource.paginator = this.paginator.toArray()[0];
      });
    this.dataSource.paginator = this.paginator.toArray()[0];
    this.dataSource.sort = this.sort.toArray()[0];

    this._purchaseService.getAllForUser()
      .subscribe((purchases: Purchase[]) => {
        this.products = purchases;
        this.purchasesDataSource = new MatTableDataSource(purchases);
        this.purchasesDataSource.sort = this.sort.toArray()[1];
        this.purchasesDataSource.paginator = this.paginator.toArray()[1];
      });
    this.purchasesDataSource.paginator = this.paginator.toArray()[1];
    this.purchasesDataSource.sort = this.sort.toArray()[1];
  }
  Logout(){
    this._authService.logout();    
    this.router.navigateByUrl('/login');
  }
}
