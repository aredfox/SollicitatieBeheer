import { Injectable } from '@angular/core';

@Injectable()
export class SearchService {
    containsInAny<T>(model: T, searchTerm: string, propertyNames: string[]): boolean {
        if (searchTerm === '') return true;

        searchTerm = searchTerm.trim().toLowerCase();

        for (let propertyName of propertyNames) {
            if (model[propertyName].toString().toLowerCase().indexOf(searchTerm) >= 0) {
                return true;
            }
        }

        return false;
    }
}