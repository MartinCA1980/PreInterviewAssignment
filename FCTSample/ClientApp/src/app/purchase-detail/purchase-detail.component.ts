import { Component, OnInit } from '@angular/core';
import { PurchaseService } from '../services/purchase.service';
import { ActivatedRoute } from '@angular/router';
import { Purchase } from '../models/Purchase';
import { Router } from '@angular/router';
@Component({
  selector: 'app-purchase-detail',
  templateUrl: './purchase-detail.component.html',
  styleUrls: ['./purchase-detail.component.css']
})
export class PurchaseDetailComponent implements OnInit {

  constructor(private purchaseService: PurchaseService, private route: ActivatedRoute, private router: Router) { }
  purchase: Purchase;
  ngOnInit() {
    

    this.purchaseService.get(this.route.snapshot.paramMap.get('id'))
    .subscribe((mypurchase: Purchase) => {
      this.purchase = mypurchase;      
      console.log(JSON.stringify(mypurchase));
    });
  }
  onClickMe(){
    this.purchaseService.remove(this.route.snapshot.paramMap.get('id'))
    .subscribe((mypurchase: Purchase) => {
      this.router.navigateByUrl('/');
    });
  }

}
