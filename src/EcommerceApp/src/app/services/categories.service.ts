import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import { HttpErrorHandler, HandleError } from '../http-error-handler.service';
import { environment } from '../../environments/environment';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json',
    'Authorization': 'my-auth-token'
  })
};

import { preProcess, preProcessNothing } from './api.preprocess';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  categoriesUrl = environment.ApiUrl + 'categories';  // URL to web api
  private handleError: HandleError;

  dataChange: BehaviorSubject<any[]> = new BehaviorSubject<any[]>([]);
  dialogData: any;

  constructor(
    private http: HttpClient,
    httpErrorHandler: HttpErrorHandler) {
    this.handleError = httpErrorHandler.createHandleError('CategoriesService');
  }

  /** GET categories from the server */
  getCategories (): Observable<any[]> {
    return this.http.get<any>(this.categoriesUrl)
      .pipe(
        map(preProcess),
        catchError(this.handleError('getCategories', []))
      );
  }

  createCategory(category): Observable<any> {
    return this.http.post(this.categoriesUrl, category, httpOptions)
      .pipe(
        map(preProcessNothing),
        catchError(this.handleError('createCategories', []))
      );
  }

  deleteCategory(category): Observable<any>{
    const id = typeof category === 'number' ? category : category.Id;
    const url = `${this.categoriesUrl}/${id}`; 
    return this.http.delete(url, httpOptions)
      .pipe(
        map(preProcessNothing),
        catchError(this.handleError('deleteCategories', []))
      )
  }

  updateCategory(category): Observable<any>{

    const id = typeof category === 'number' ? category : category.Id;
    const url = `${this.categoriesUrl}/${id}`; 

    return this.http.put(url, category, httpOptions)
    .pipe(
      map(preProcessNothing),
      catchError(this.handleError('updateCategories', []))
    )
  }
}
