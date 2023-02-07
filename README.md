## Desafio para Back-end Developer no Intrabank - C# .NET 6.0

#### Requisitos Gerais

Uma _fintech_ precisa sistematizar seu negócio de atencipação de recebíveis, onde passará ser necessário ter um controle dos clientes empresarias que possuem crédito concedido. Para isso, foi solicitado a você desenvolver uma aplicação em formato de API REST/JSON para gerenciar estes clientes. Requisitos:

- O sistema deverá mostrar todos os clientes empresariais cadastrados ordenados de forma ascendente pela razão social.
- Ao persistir, validar se o cliente já foi cadastrado anteriormente.
- O sistema deverá permitir consultar, criar, editar e excluir um cliente.
- Os clientes devem ser persistidos em um banco de dados.
- Criar algum mecanismo de log de registro e de erro.

#### Requisitos Técnicos

- Incluir mecanismo de autenticação no Swagger, usando Token JWT (Bearer).
- Para a persistência dos dados deve ser utilizado o Entity Framework.
- Como banco de dados, pode ser usado MySQL, PostgreSQL ou SQL Server.
- Utilizar migrations ou Gerar Scripts e disponibilizá-los um uma pasta.

#### Observações

- O sistema deverá ser desenvolvido na plataforma .NET 6.0 com C#.  
- Atenção aos princípio do SOLID e Clean Architecture.
- Não é necessária a criação de front-end, o teste será feito pelo Swagger UI.

#### Diferenciais do desafio

- Aplicação das boas práticas do DDD, TDD, Design Patterns, SOLID e Clean Code.
- Intencionalmente a modelagem dos dados não será fornecida, já que desejamos avaliar a sua capacidade de abstração.
- A API deverá realizar tratamento de entrada de dados e retornar códigos de erro quando aplicáveis.
- Criar massa de dados para que seja possível verificar o funcionamento das lógicas propostas.
- Incluir parâmetros de paginação e campos de filtro nos métodos de consulta (GET).
- Documentar, via código-fonte, os campos, parâmetros e dados de retorno da API para exibição no Swagger.
- Dockerizar a aplicação e disponibilizar instruções para deploy em uma nuvem pública.

## Como deverá ser entregues

    1. Faça um fork deste repositório;
    2. Realize o desenvolvimento proposto no desafio;
    3. Adicione seu currículo na raiz do repositório ou endereço LinkeIn no README.md;
    4. Nos envie um PR para que seja avaliado.
