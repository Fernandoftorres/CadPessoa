import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { ServiceBase } from './service.base';
import { Pessoa } from '../models/pessoa.model';

@Injectable({
    providedIn: 'root'
})

export class PessoaService extends ServiceBase {

    constructor(private _httpClient: HttpClient) {
        super();
    }

    obterPessoas(): Observable<Pessoa[]> {
        return this._httpClient.get<Pessoa[]>(this.UrlServiceV1 + "pessoas");
    }

    salvarPessoa(pessoa): Observable<Pessoa> {
        return this._httpClient.put(this.UrlServiceV1 + 'pessoa/' + pessoa.id, pessoa)
            .pipe(map(super.extractData));
    }

    adicionarPessoa(pessoa): Observable<Pessoa> {
        return this._httpClient.post(this.UrlServiceV1 + 'pessoa/', pessoa)
            .pipe(map(super.extractData));
    }

    obterPessoa(id): Observable<Pessoa> {
        if (id !== 'new') {
            return this._httpClient.get<Pessoa>(this.UrlServiceV1 + "pessoa/" + id);
        } else {
            return of(null);
        }
    }

    removerPessoa(id): Observable<any> {
        return this._httpClient.delete<Pessoa>(this.UrlServiceV1 + "pessoa/"+ id);
    }
}
