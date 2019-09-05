using FluentValidation;
using Avaliacao.Domain.Entities;
using Avaliacao.Infra.CrossCutting;
using System;

namespace Avaliacao.Service.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Objeto não encontrado.");
                    });

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .NotNull().WithMessage("O CPF é obrigatório.")
                .Length(11).WithMessage("O Cpf deve ter 11 dígitos.")
                .Must(Util.ValidarCpf).WithMessage("O CPF não é valido.");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O Nome é obrigatório.")
                .NotNull().WithMessage("O Nome é obrigatório.")
                .Length(3, 30).WithMessage("O Nome deve ter no máximo 30 caracteres.");

            RuleFor(c => c.Idade)
                .NotEmpty().WithMessage("A Idade é obrigatória.")
                .NotNull().WithMessage("A Idade é obrigatória.");
        }
    }
}
