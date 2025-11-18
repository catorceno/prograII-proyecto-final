import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../environments/environment.development';
import { SeatingPlan } from './models/seating-plan.models';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SeatingPlanService {
  private http = inject(HttpClient);
  private URLbase = environment.apiURL + '/api';
  constructor() { }

  public getByTheaterId(id: number): Observable<SeatingPlan> {
    return this.http.get<SeatingPlan>(`${this.URLbase}/${id}/seating-plan`);
  }
}

/*
public getById(id: number): Observable<TheaterInfo> {
    return this.http.get<TheaterInfo>(`${this.URLbase}/${id}`);
  }
*/