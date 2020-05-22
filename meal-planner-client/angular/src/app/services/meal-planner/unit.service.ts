import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { concatMap, map } from 'rxjs/operators';
import { ConfigService } from '../config/config.service';
import { Unit } from 'app/data/unit.model';

@Injectable({
  providedIn: 'root'
})
export class UnitService {

  private readonly apiUrl$: Observable<string>;

  /**
   * Represents the _Day Service_ `constructor` method
   *
   * @param config ConfigService
   * @param http HttpClient
   */
  constructor(private readonly config: ConfigService, private readonly http: HttpClient) {
    this.apiUrl$ = config.get().pipe(map((cfg) => cfg.api.unit));
  }

  
  /**
   * Represents the _Day Service_ `get` method
   *
   * @param id string
   */
  get(id?: string): Observable<Unit[]> {
    const options = id ? { params: new HttpParams().set('id', id) } : {};
    return this.apiUrl$.pipe(concatMap((url) => this.http.get<Unit[]>(url, options)));
  }
}
