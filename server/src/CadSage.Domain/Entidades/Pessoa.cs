using System;
using FluentValidation;
using CadSage.Domain.Core.Constantes;
using CadSage.Domain.Core.Models;

namespace CadSage.Domain.Entidades
{
    public class Pessoa : Entity<Pessoa>
    {
        public Pessoa(Guid? id, string nome, string email, string cpf, string rua, string cep, string bairro, string cidade,
            string uf)
        {
            Id = id ?? Guid.NewGuid();
            Nome = nome;
            Email = email;
            CPF = cpf;
            Rua = rua;
            CEP = cep;
            Bairro = bairro;
            Cidade = cidade;
            UF = uf;
        }

        // EF Construtor
        protected Pessoa() { }

        public string Nome { get; private set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Rua { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }

        // EF Propriedade de Navegação

        public override bool EhValido()
        {
            Validar();
            return ValidationResult.IsValid;
        }

        #region Validações

        private void Validar()
        {
            ValidarNome();
            ValidarCPF();
            ValidarEmail();
            ValidarRua();
            ValidarCEP();
            ValidarBairro();
            ValidarCidade();
            ValidarUF();
            ValidationResult = Validate(this);
        }

        private void ValidarNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage(string.Format(Mensagens.CampoRequerido, "Nome"))
                .Length(2, 50).WithMessage(string.Format(Mensagens.CampoTamanho, "Nome", "50", "2"));
        }
        private void ValidarCPF()
        {
            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage(string.Format(Mensagens.CampoRequerido, "CPF"))
                .Length(11).WithMessage(string.Format(Mensagens.CampoTamanhoFixo, "CPF", "11"));
        }
        private void ValidarEmail()
        {
            RuleFor(c => c.Email)
                .NotEmpty().WithMessage(string.Format(Mensagens.CampoRequerido, "Email"))
                .Length(2, 50).WithMessage(string.Format(Mensagens.CampoTamanhoFixo, "Email", "50", "2"));
        }
        private void ValidarRua()
        {
            RuleFor(c => c.Rua)
                .NotEmpty().WithMessage(string.Format(Mensagens.CampoRequerido, "Rua"))
                .Length(2, 100).WithMessage(string.Format(Mensagens.CampoTamanho, "Rua", "100", "2"));
        }
        private void ValidarCEP()
        {
            RuleFor(c => c.CEP)
                .NotEmpty().WithMessage(string.Format(Mensagens.CampoRequerido, "CEP"))
                .Length(8).WithMessage(string.Format(Mensagens.CampoTamanhoFixo, "CEP", "8"));
        }
        private void ValidarBairro()
        {
            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage(string.Format(Mensagens.CampoRequerido, "Bairro"))
                .Length(2, 50).WithMessage(string.Format(Mensagens.CampoTamanho, "Bairro", "50", "2"));
        }
        private void ValidarCidade()
        {
            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage(string.Format(Mensagens.CampoRequerido, "Cidade"))
                .Length(2, 50).WithMessage(string.Format(Mensagens.CampoTamanho, "Cidade", "50", "2"));
        }
        private void ValidarUF()
        {
            RuleFor(c => c.UF)
                .NotEmpty().WithMessage(string.Format(Mensagens.CampoRequerido, "UF"))
                .Length(2).WithMessage(string.Format(Mensagens.CampoTamanhoFixo, "UF", "2"));
        }
        #endregion
    }
}