import { Observable } from "rxjs";

export interface IBaseService<T> {

    create(model: T): Observable<T>;

    getAll(): Observable<Array<T>>;

    delete(id: number): Observable<Object>;

    update(model: T): Observable<T>;

    getById(id: number): Observable<T>;

}
