import { Component, OnInit } from '@angular/core';
import { Recurso } from 'src/app/services/recurso.services';
import { RecursoService } from 'src/app/services/recurso.services';
import { error } from 'protractor';

@Component({
  selector: 'app-recurso',
  templateUrl: './recurso.component.html',
  styleUrls: ['./recurso.component.css']
})
export class RecursoComponent implements OnInit {

  recursos : Recurso[];

  constructor( private RecursoService:RecursoService) { }

  ngOnInit() {
    this.RecursoService.PruebaConexion().subscribe(recursodesdews => this.recursos = recursodesdews,
      error => console.error(error));
  }

}
