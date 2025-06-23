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
## Exemplos de request

Adicionar Contato a um Cliente
POST /clientes/{id}/contatos

```json
{
   "tipo": "email",
   "texto": "joao@email.com"
}
```
Alterar Contato de um Cliente
PUT /clientes/{id}/contatos/{contatoId}

```json
{
   "tipo": "email",
   "texto": "joao@email.com"
}
```

DELETE /clientes/3fa85f64-5717-4562-b3fc-2c963f66afa6/contatos/7fa85f64-5717-4562-b3fc-2c963f66afa6


Adicionar Cliente<br>
POST /clientes

```json
{
  "nome": "João da Silva",
  "cep": "12345678",
  "numero": "100",
  "contatos": [
    {
      "tipo": "email",
      "texto": "joao@email.com"
    },
    {
      "tipo": "telefone",
      "texto": "11999999999"
    }
  ]
}
```

Alterar Cliente<br>
PUT /clientes/{id}

```json
{
  "nome": "João da Silva",
  "cep": "87654321",
  "numero": "200"
}
```


DELETE /clientes/3fa85f64-5717-4562-b3fc-2c963f66afa6 <br>
GET /clientes?pagina=1&tamanho=10<br>
GET /clientes/nome/João%20da%20Silva<br>
<br>

## 🕹 Como executar o banco de dados 
- Siga a instalação do docker no site: https://docs.docker.com/desktop/install/windows-install/
- Após baixar o Docker, clone o projeto e acesse o terminal no diretório do projeto.
- Para executar o projeto execute o comando:
```
docker compose up 
```
Ou 
```
docker compose up -d
```
Para habilitar o terminal após iniciar :)
