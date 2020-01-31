import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { RecursoComponent } from './components/recurso/recurso.component';

const APP_ROUTES: Routes = [
    { path: 'recurso', component: RecursoComponent },
   { path: '**', pathMatch:'full',redirectTo:'recurso' }

];

export const APP_ROUTING = RouterModule.forRoot(APP_ROUTES)
