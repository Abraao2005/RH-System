import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Funcionario, FuncionarioResponse } from '../models/funcionario.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class FuncionariosService {
  private apiUrl = 'http://localhost:7081/api/ferias';

  constructor(private http: HttpClient) {}

listar(): Observable<any> {
  return this.http.get<any>(this.apiUrl);
}

  buscarPorId(id: number): Observable<FuncionarioResponse> {
    return this.http.get<FuncionarioResponse>(`${this.apiUrl}/${id}`);
  }

  criar(func: Funcionario): Observable<FuncionarioResponse> {
    return this.http.post<FuncionarioResponse>(this.apiUrl, func);
  }

  atualizar(id: number, func: Funcionario): Observable<void> {
    return this.http.put<void>(`${this.apiUrl}/${id}`, func);
  }

  deletar(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}
