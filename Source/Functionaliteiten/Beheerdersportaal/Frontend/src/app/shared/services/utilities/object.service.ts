import { Injectable } from '@angular/core';

@Injectable()
export class ObjectService {
    extractPropertyNames<T>(propertySelectors: ((x: T) => any | string)[]): string[] {
        let propertyNames: string[] = [];

        propertySelectors.forEach(propertySelector => {
            const functionBody = propertySelector.toString();
            const expression = functionBody.slice(functionBody.indexOf('{') + 1, functionBody.lastIndexOf('}'));
            const propertyName = expression.slice(expression.indexOf('.') + 1, expression.lastIndexOf(';'));
            propertyNames.push(propertyName);
        });

        return propertyNames;
    }
}