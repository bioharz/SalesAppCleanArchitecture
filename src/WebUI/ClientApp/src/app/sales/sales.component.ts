import {Component, OnInit} from '@angular/core';
import {SaleItemsClient, SalesVm} from "../cleanarchitecture-api";
import {SalesService} from "../services/sales/sales.service";


@Component({
  selector: 'app-sales',
  templateUrl: './sales.component.html',
  styleUrls: ['./sales.component.css']
})
export class SalesComponent implements OnInit {

  salesVm: SalesVm | void;

  constructor(
    private saleItemsClient: SaleItemsClient,
    private salesService: SalesService
  ) {
  }

  ngOnInit() {
    this.getSalesVm();
  }

  async getSalesVm(){
    this.salesVm = await this.salesService.getSalesVm();
  }

}
