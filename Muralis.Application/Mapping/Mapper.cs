using Muralis.Application.Dtos;
using Muralis.Application.Services;
using Muralis.Domain.Entitiy;
using Muralis.Domain.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Muralis.Application.Mapping
{
    public static class Mapper
    {
        public static ClienteProps ToClienteProps(this ClienteDto cliente, CepResult viaCep)
        {
            ClienteProps clienteProps = new ClienteProps
            {
                Nome = cliente.Nome,
                Cep = viaCep.Cep,
                Numero = cliente.Numero,
                Logradouro = viaCep.Logradouro, // Ajuste conforme necessário
                Complemento = viaCep.Complemento, // Ajuste conforme necessário
                Cidade = viaCep.Cidade, // Ajuste conforme necessário
                Contatos = cliente.Contatos?.Select(c => new ContatoProps
                {
                    Tipo = c.Tipo,
                    Texto = c.Texto
                }).ToList() ?? []
            };

            return clienteProps;
        }
        public static ClienteProps ToClienteProps(this AlterarClienteDto cliente, CepResult viaCep)
        {
            ClienteProps clienteProps = new ClienteProps
            {
                Nome = cliente.Nome,
                Cep = viaCep.Cep,
                Numero = cliente.Numero,
                Logradouro = viaCep.Logradouro, // Ajuste conforme necessário
                Complemento = viaCep.Complemento, // Ajuste conforme necessário
                Cidade = viaCep.Cidade, // Ajuste conforme necessário
                Contatos = cliente.Contatos?.Select(c => new ContatoProps
                {
                    Tipo = c.Tipo,
                    Texto = c.Texto
                }).ToList() ?? []
            };

            return clienteProps;
        }
    }
}
