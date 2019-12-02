import { Component, OnInit } from '@angular/core';
import { Product } from '../models/Product';
import { Purchase } from '../models/Purchase';
import { ProductService } from '../services/product.service';
import { PurchaseService } from '../services/purchase.service';
import { ActivatedRoute } from '@angular/router';
import { Router } from '@angular/router';
@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.css']
})
export class ProductDetailComponent implements OnInit {

  product: Product;
  constructor(private productServioce: ProductService, private purchaseService: PurchaseService, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    
    this.productServioce.get(this.route.snapshot.paramMap.get('id'))
    .subscribe((products: Product) => {
      this.product = products;      
    });
  }
  onClickMe(){
    this.purchaseService.purchaseByProductId(this.route.snapshot.paramMap.get('id'))
    .subscribe((mypurchase: Purchase) => {
      this.router.navigateByUrl('/');
    });
  }

}
