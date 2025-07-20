import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Funcionario } from '../models/funcionario.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class FuncionariosService {
  private apiUrl = 'http://localhost:7081/api/funcionario';

  constructor(private http: HttpClient) {}

listar(): Observable<any> {
  return this.http.get<any>(this.apiUrl);
}

  buscarPorId(id: number): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/${id}`);
  }

  criar(func: Funcionario): Observable<any> {
    return this.http.post<any>(this.apiUrl, func);
  }

  atualizar(id: number, func: Funcionario): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, func);
  }

  deletar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
