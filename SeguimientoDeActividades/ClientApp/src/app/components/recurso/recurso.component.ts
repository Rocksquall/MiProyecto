import { Component, OnInit } from '@angular/core';
import { Recurso } from 'src/app/services/recurso.services';
import { RecursoService } from 'src/app/services/recurso.services';

@Component({
  selector: 'app-recurso',
  templateUrl: './recurso.component.html',
  styleUrls: ['./recurso.component.css']
})
export class RecursoComponent implements OnInit {

  recurso : Recurso[];

  constructor( private RecursoService:RecursoService) { }

  ngOnInit() {
  }

}
 