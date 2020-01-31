import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable} from 'rxjs';
import { create } from 'domain';

@Injectable()
export class RecursoService {

  private apiURL = this.baseUrl +"api/recurso";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}
  
    PruebaConexion(): Observable<Recurso[]> {
            return this.http.get<Recurso[]>(this.apiURL);
    }
  
    
    createRecurso(recurso: Recurso):Observable<Recurso[]>{
      return this.http.post<Recurso[]>(this.apiURL,recurso);
    }
  }
    export interface Recurso{
      idrecurso: number;
      recursoNombre: string;
      Recursodisponibilidad:number;
      Recursocorreo: string;
      };
  

