import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { observable, Observable} from 'rxjs';

@Injectable()
export class RecursoService {

  private apiURL = this.baseUrl +"api/Recursos";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}
  
    getRecursos(): Observable<Recurso[]> {
            return this.http.get<Recurso[]>(this.apiURL);
   
    }
    }
  



export interface Recurso{
    idx?: number;
    nombre: string;
    disponibilidad:number;
    correo: string;
  };