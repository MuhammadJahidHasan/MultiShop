import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {PaginationModule} from 'ngx-bootstrap';
import { PaigingHeaderComponent } from './components/paiging-header/paiging-header.component';
import { PaggerComponent } from './components/pagger/pagger.component';


@NgModule({
  declarations: [PaigingHeaderComponent, PaggerComponent],
  imports: [
    CommonModule,
    PaginationModule.forRoot()
  ],
  exports: [PaginationModule,
           PaigingHeaderComponent,
           PaggerComponent
  ]
})
export class SharedModule { }
