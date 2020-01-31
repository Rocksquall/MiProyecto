import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable} from 'rxjs';

@Injectable()
export class RecursoService {

  private apiURL = this.baseUrl +"api/recurso";

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {}
  
    PruebaConexion(): Observable<Recurso[]> {
            return this.http.get<Recurso[]>(this.apiURL);
   
    }
    }
    
    export interface Recurso{
        idx?: number;
        nombre: string;
        disponibilidad:number;
        correo: string;
      };
  

