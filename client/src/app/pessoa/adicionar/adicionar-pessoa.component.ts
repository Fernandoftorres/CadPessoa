import { Component, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { StepState } from '@angular/cdk/stepper';
import { PessoaService } from 'src/app/services/pessoa.service';
import { Pessoa } from 'src/app/models/pessoa.model';
import { Router, ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'adicionar-pessoa',
  templateUrl: './adicionar-pessoa.component.html',
  styleUrls: ['./adicionar-pessoa.component.scss']
})
export class AdicionarPessoaComponent {

  name = 'SAGE - Cadastro Pessoas';
  pessoa: Pessoa;

  state1: StepState = "none";
  state2: StepState = "none";

  @ViewChild('form1', { static: true }) _form1: NgForm;
  @ViewChild('form2', { static: true }) _form2: NgForm;

  states: string[] = ['AC', 'AL', 'AP', 'AM', 'BA', 'CE', 'DF', 'ES', 'GO', 'MA', 'MT', 'MS', 'MG', 'PA',
    'PB', 'PR', 'PE', 'PI', 'RJ', 'RN', 'RS', 'RO', 'RR', 'SC', 'SP', 'SE', 'TO'];

  constructor(public service: PessoaService,
    private router: Router,
    public toster: ToastrService,
    private route: ActivatedRoute) {

  }

  save() {

    if (this.pessoa.id) {
      this.service.salvarPessoa(this.pessoa)
        .subscribe(() => {
          this.toster.success('Pessoa salva com sucesso', 'Sucesso');
          this.router.navigate(['/pessoas']);
        }, () => {
          this.toster.error("Erro ao salvar pessoa.");
        });
    } else {
      this.service.adicionarPessoa(this.pessoa)
        .subscribe(() => {
          this.toster.success('Pessoa salva com sucesso', 'Sucesso');
          this.router.navigate(['/pessoas']);
        }, () => {
          this.toster.error("Erro ao salvar pessoa.");
        });
    }
  }

  update(step, isValid): void {
    switch (step) {
      case 1:
        if (isValid) {
          this.state1 = 'complete';
        } else {
          this.state1 = 'required';
        }
        break;
      case 2:
        if (isValid) {
          this.state2 = 'complete';
        } else {
          this.state2 = 'required';
        }
        break;
    }
  }

  ngOnInit() {
    // this.pessoa = {
    //   id: '',
    //   nome: '',
    //   email: '',
    //   cpf: '',
    //   rua: '',
    //   bairro: '',
    //   cidade: '',
    //   uf: '',
    //   cep: '',
    // };
    this.pessoa = new Pessoa();

    this.service.obterPessoa(this.route.snapshot.params['id'])
      .subscribe(pessoa => {

        if (pessoa) {
          this.pessoa = pessoa;

        }
        else {
          this.pessoa = new Pessoa();
        }

      });

  }
}
