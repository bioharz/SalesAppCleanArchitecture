import { Component, OnInit } from '@angular/core';
import {StaticsService} from "../services/statics/statics.service";
import {RevenueArticleVm} from "../cleanarchitecture-api";

@Component({
  selector: 'app-statics',
  templateUrl: './statics.component.html',
  styleUrls: ['./statics.component.css']
})
export class StaticsComponent implements OnInit {

  revenueVm: RevenueArticleVm | void;
  numberOfSoldArticlesPerDay: number | void;
  numberOfSoldArticlesDate: Date = new Date(Date.now());
  totalRevenuePerDay: number | void;
  totalRevenueDate: Date = new Date(Date.now());


  constructor(
    private staticsService: StaticsService
  ) { }

  ngOnInit() {
    this.getRevenueGroupedByArticles();
    this.getNumberOfSoldArticlesPerDay(this.numberOfSoldArticlesDate);
    this.getTotalRevenuePerDay(this.totalRevenueDate);
  }

  async getRevenueGroupedByArticles() {
    this.revenueVm = await this.staticsService.getRevenueGroupedByArticles();
  }

  async getNumberOfSoldArticlesPerDay(date: Date) {
    this.numberOfSoldArticlesPerDay = await this.staticsService.getNumberOfSoldArticlesPerDay(date);
  }

  async getTotalRevenuePerDay(date: Date) {
    this.totalRevenuePerDay = await this.staticsService.getTotalRevenuePerDay(date);
  }

}
