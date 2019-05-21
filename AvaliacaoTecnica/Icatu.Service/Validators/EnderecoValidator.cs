using FluentValidation;
using Icatu.Domain.Entities;
using System;

namespace Icatu.Service.Validators
{
    public class EnderecoValidator : AbstractValidator<Endereco>
    {
        public EnderecoValidator()
        {
            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Objeto não encontrado.");
                    });

            RuleFor(c => c.Logradouro)
                .NotEmpty().WithMessage("O Logradouro é obrigatório.")
                .NotNull().WithMessage("O Logradouro é obrigatório.")
                .Length(3, 50).WithMessage("O Logradouro deve ter no máximo 50 caracteres.");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("O Bairro é obrigatório.")
                .NotNull().WithMessage("O Bairro é obrigatório.")
                .Length(3, 40).WithMessage("O Bairro deve ter no máximo 40 caracteres.");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("A Cidade é obrigatória.")
                .Length(3, 40).WithMessage("A Cidade deve ter no máximo 40 caracteres.");

            RuleFor(c => c.Estado)
               .NotEmpty().WithMessage("O Estado é obrigatório.")
               .NotNull().WithMessage("O Estado é obrigatório.")
               .Length(3, 40).WithMessage("O Estado deve ter no máximo 40 caracteres.");
        }
    }
}
