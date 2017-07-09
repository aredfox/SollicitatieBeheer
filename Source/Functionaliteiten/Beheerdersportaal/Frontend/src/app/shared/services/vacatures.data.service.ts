import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Vacature } from '../../vacatures/vacature.model';

import { Observable } from 'rxjs/Observable';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';

@Injectable()
export class VacaturesDataService {

    private apiUrl = 'http://localhost:10370/api/vacatures';

    constructor(private http: Http) { }

    private handleError(error: Response | any) {
        // In a real world app, you might use a remote logging infrastructure
        let errMsg: string;
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }
        console.error(errMsg);
        return Observable.throw(errMsg);
    }

    lijstVacaturesOp(): Promise<Vacature[]> {
        return this.http.get(this.apiUrl)
            .map(response => {
                let body = response.json();
                console.log(body);
                return body.vacatures || {};
            })
            .toPromise()
            .catch(this.handleError);
    }
}