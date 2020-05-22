import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { concatMap, map } from 'rxjs/operators';
import { ConfigService } from '../config/config.service';
import { NutrientType } from 'app/data/nutrient-type.model';

@Injectable({
  providedIn: 'root'
})
export class NutrientTypeService {

  private readonly apiUrl$: Observable<string>;

  /**
   * Represents the _Day Service_ `constructor` method
   *
   * @param config ConfigService
   * @param http HttpClient
   */
  constructor(private readonly config: ConfigService, private readonly http: HttpClient) {
    this.apiUrl$ = config.get().pipe(map((cfg) => cfg.api.nutrientType));
  }

  
  /**
   * Represents the _Day Service_ `get` method
   *
   * @param id string
   */
  get(id?: string): Observable<NutrientType[]> {
    const options = id ? { params: new HttpParams().set('id', id) } : {};
    return this.apiUrl$.pipe(concatMap((url) => this.http.get<NutrientType[]>(url, options)));
  }
}
