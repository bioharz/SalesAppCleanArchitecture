import { Injectable } from '@angular/core';
import {
  GetNumberOfSoldArticlesPerDayClient, GetRevenueGroupedByArticlesClient,
  GetTotalRevenuePerDayClient,
  RevenueArticleVm,
} from "../../cleanarchitecture-api";

@Injectable({
  providedIn: 'root'
})
export class StaticsService {

  constructor(
    private getNumberOfSoldArticlesPerDayClient: GetNumberOfSoldArticlesPerDayClient,
    private getTotalRevenuePerDayClient: GetTotalRevenuePerDayClient,
    private getRevenueGroupedByArticlesClient: GetRevenueGroupedByArticlesClient
  ) { }

  getRevenueGroupedByArticles():Promise<RevenueArticleVm | void> {
    return this.getRevenueGroupedByArticlesClient.getRevenueGroupedByArticles().toPromise().catch(error => console.error(error));
  }

  getNumberOfSoldArticlesPerDay(date: Date):Promise<number | void> {
    return this.getNumberOfSoldArticlesPerDayClient.getNumberOfSoldArticlesPerDay(date).toPromise().catch(error => console.error(error));
  }

  getTotalRevenuePerDay(date: Date):Promise<number | void> {
    return this.getTotalRevenuePerDayClient.getTotalRevenuePerDay(date).toPromise().catch(error => console.error(error));
  }

}
