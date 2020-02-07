import { NgModule } from '@angular/core';
import { RouterModule, Routes, PreloadAllModules } from '@angular/router';
import { AdicionarPessoaComponent } from './pessoa/adicionar/adicionar-pessoa.component';
import { ListarPessoaComponent } from './pessoa/listar/listar-pessoa.component';

const routes: Routes = [
  {
    path: '',
    children: [
      {
        path: 'pessoas',
        component: ListarPessoaComponent
      },
      {
        path: 'pessoa/:id',
        component: AdicionarPessoaComponent
      },
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
