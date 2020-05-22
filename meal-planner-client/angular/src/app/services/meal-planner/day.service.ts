import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { concatMap, map } from 'rxjs/operators';
import { ConfigService } from '../config/config.service';
import { Day } from 'app/data/day.model';

@Injectable({
  providedIn: 'root'
})
export class DayService {

  private readonly apiUrl$: Observable<string>;

  /**
   * Represents the _Day Service_ `constructor` method
   *
   * @param config ConfigService
   * @param http HttpClient
   */
  constructor(private readonly config: ConfigService, private readonly http: HttpClient) {
    this.apiUrl$ = config.get().pipe(map((cfg) => cfg.api.day));
  }

  /**
   * Represents the _Day Service_ `delete` method
   *
   * @param id string
   */
  delete(id: string): Observable<boolean> {
    return this.apiUrl$.pipe(
      concatMap((url) => this.http.delete<boolean>(url, { params: { id } }))
    );
  }

  /**
   * Represents the _Day Service_ `get` method
   *
   * @param id string
   */
  get(id?: string): Observable<Account[]> {
    const options = id ? { params: new HttpParams().set('id', id) } : {};
    return this.apiUrl$.pipe(concatMap((url) => this.http.get<Account[]>(url, options)));
  }
  /**
   * Represents the _Day Service_ `get` method
   *
   * @param id number
   */
  getByAccountId(accountId: number): Observable<Day[]> {
    return this.apiUrl$.pipe( concatMap( (url) => this.http.get<Day[]>(url + '/account/' + accountId) ));
  }

  /**
   * Represents the _Day Service_ `post` method
   *
   * @param day Day
   */
  post(day: Day): Observable<boolean> {
    return this.apiUrl$.pipe(concatMap((url) => this.http.post<boolean>(url, day)));
  }

  /**
   * Represents the _Day Service_ `put` method
   *
   * @param day Day
   */
  put(day: Day): Observable<Day> {
    return this.apiUrl$.pipe(concatMap((url) => this.http.put<Day>(url, day)));
  }
}
