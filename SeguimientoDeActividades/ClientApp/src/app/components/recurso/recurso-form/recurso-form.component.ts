import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Recurso, RecursoService } from 'src/app/services/recurso.services';
import { Router } from '@angular/router';

@Component({
  selector: 'app-recurso-form',
  templateUrl: './recurso-form.component.html',
  styleUrls: ['./recurso-form.component.css']
})
export class RecursoFormComponent implements OnInit {

  constructor(private fb: FormBuilder, private recursoService: RecursoService, private router: Router) { }


  
  formGroup:FormGroup;
  ngOnInit() {
    this.formGroup=this.fb.group({
      idrecurso:'',
      recursoNombre:'',
      Recursodisponibilidad:'',
      Recursocorreo:''
    })
  }
  save() {
    this.ignorarExistenCambiosPendientes = true;
    let recurso: Recurso = Object.assign({}, this.formGroup.value);
    console.table(recurso);

    if (this.modoEdicion) {
       // editar el registro
       recurso.idrecurso = this.personaId;
      this.recursoService.updatePersona(recurso)
        .subscribe(persona => this.borrarPersonas(),
          error => console.error(error));
    } else {
      // agregar el registro
    
    this.recursoService.createPersona(recurso)
      .subscribe(persona => this.onSaveSuccess(),
        error => console.error(error));
    }
  }
  onSaveSuccess() {
    this.router.navigate(["/personas"]);
  }
}
