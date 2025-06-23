# API de Clientes e Contatos

Este projeto expõe endpoints para gerenciamento de **Clientes** e seus **Contatos** utilizando Minimal APIs no ASP.NET Core (.NET 9).

---

## Endpoints de Clientes

| Método | Rota                      | Descrição                        | Corpo/Requisição         |
|--------|---------------------------|----------------------------------|--------------------------|
| POST   | `/clientes`               | Adiciona um novo cliente         | `ClienteDto`             |
| PUT    | `/clientes/{id}`          | Altera um cliente existente      | `AlterarClienteDto`      |
| DELETE | `/clientes/{id}`          | Remove um cliente                | -                        |
| GET    | `/clientes`               | Lista clientes paginados         | Query: `pagina`, `tamanho`|
| GET    | `/clientes/nome/{nome}`   | Busca cliente pelo nome          | -                        |

---

## Endpoints de Contatos

| Método | Rota                                      | Descrição                          | Corpo/Requisição   |
|--------|-------------------------------------------|------------------------------------|--------------------|
| POST   | `/clientes/{id}/contatos`                 | Adiciona um contato ao cliente     | `ContatoDto`       |
| PUT    | `/clientes/{id}/contatos/{contatoId}`     | Altera um contato do cliente       | `ContatoDto`       |
| DELETE | `/clientes/{id}/contatos/{contatoId}`     | Remove um contato do cliente       | -                  |

---

## Observações

- Todos os endpoints retornam respostas padronizadas com status HTTP e mensagens.
- Validações são aplicadas via FluentValidation e retornam erros detalhados em caso de dados inválidos.
- Os endpoints de contatos estão agrupados sob `/clientes/{id}/contatos`, sempre vinculados a um cliente específico.

---

