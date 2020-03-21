import { Injectable } from '@angular/core';
import {SaleItemsClient, SalesVm} from "../../cleanarchitecture-api";


@Injectable({
  providedIn: 'root'
})
export class SalesService {

  constructor(
    private saleItemsClient: SaleItemsClient
  ) { }

  getSalesVm():Promise<SalesVm | void> {
    return this.saleItemsClient.get().toPromise().catch(error => console.error(error));
  }
}
