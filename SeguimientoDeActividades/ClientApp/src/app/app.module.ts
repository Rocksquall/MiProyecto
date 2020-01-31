import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
//rutas
import {APP_ROUTING} from './app.routes'
//componentes
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { RecursoComponent } from './components/recurso/recurso.component';
import { RecursoService } from './services/recurso.services';
import { RecursoFormComponent } from './components/recurso/recurso-form/recurso-form.component';


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    RecursoComponent,
    RecursoFormComponent,
      ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    APP_ROUTING
  ],
  providers: [
    RecursoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
