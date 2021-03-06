﻿using System;
using System.ComponentModel.DataAnnotations;

namespace CadSage.Domain.Core.ViewModels
{
    public class PessoaViewModel
    {
        public PessoaViewModel()
        {
        }

        [Key]
        public Guid? Id { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Rua { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
    }
}