import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { RecursoComponent } from './components/recurso/recurso.component';
import { RecursoFormComponent } from './components/recurso/recurso-form/recurso-form.component';

const APP_ROUTES: Routes = [
    { path: 'recursos', component: RecursoComponent },
    { path: 'recursos-agregar', component: RecursoFormComponent },
   { path: '**', pathMatch:'full',redirectTo:'recursos' }

];

export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES)
