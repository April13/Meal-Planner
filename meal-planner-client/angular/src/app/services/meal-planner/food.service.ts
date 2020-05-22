import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { concatMap, map } from 'rxjs/operators';
import { ConfigService } from '../config/config.service';
import { Food } from 'app/data/food.model';

@Injectable({
  providedIn: 'root'
})
export class FoodService {

  private readonly apiUrl$: Observable<string>;

  /**
   * Represents the _Food Service_ `constructor` method
   *
   * @param config ConfigService
   * @param http HttpClient
   */
  constructor(private readonly config: ConfigService, private readonly http: HttpClient) {
    this.apiUrl$ = config.get().pipe(map((cfg) => cfg.api.food));
  }

  /**
   * Represents the _Food Service_ `delete` method
   *
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    return this.apiUrl$.pipe(
      concatMap((url) => this.http.delete<boolean>(url, { params: { id } }))
    );
  }

  /**
   * Represents the _Food Service_ `get` method
   *
   * @param id string
   */
  get(id?: string): Observable<Account[]> {
    const options = id ? { params: new HttpParams().set('id', id) } : {};
    return this.apiUrl$.pipe(concatMap((url) => this.http.get<Account[]>(url, options)));
  }
  /**
   * Represents the _Food Service_ `get` method
   *
   * @param id number
   */
  getByAccountId(accountId: number): Observable<Food[]> {
    return this.apiUrl$.pipe( concatMap( (url) => this.http.get<Food[]>(url + '/account/' + accountId) ));
  }

  /**
   * Represents the _Food Service_ `post` method
   *
   * @param food Food
   */
  post(food: Food): Observable<boolean> {
    return this.apiUrl$.pipe(concatMap((url) => this.http.post<boolean>(url, food)));
  }

  /**
   * Represents the _Food Service_ `put` method
   *
   * @param food Food
   */
  put(food: Food): Observable<Food> {
    return this.apiUrl$.pipe(concatMap((url) => this.http.put<Food>(url, food)));
  }
}
