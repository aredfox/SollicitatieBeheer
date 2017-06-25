export class SelectList<T> {
    public constructor(
        public items: string[],
        public selectedItem: string)
    { }

    public static createSelectList<T>(array: T[], propertySelector: (x: T) => string, selectedItem: string = '*'): SelectList<T> {
        const items = this.createSelectListItems(array, propertySelector);
        let selectList = new SelectList<T>(items, selectedItem);
        return selectList;
    }

    private static createSelectListItems<T, TResult>(array: T[], propertySelector: (x: T) => TResult | string): TResult[] {
        return this.distinct(array
            .map(propertySelector)
            .concat('*'))
            .sort();
    }

    private static distinct(array: any[]): any[] {
        return array.reduce((p, c) => {
            if (p.indexOf(c) < 0) p.push(c);
            return p;
        }, []);
    };
}