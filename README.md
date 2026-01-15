# TerminalLog API

API para gerenciamento de logística e terminais, desenvolvida com .NET seguindo padrões de arquitetura desacoplada.

## Tecnologias Utilizadas
* ASP.NET Core Web API
* Entity Framework Core (ORM)
* SQL Server (Banco de Dados)
* Swagger/OpenAPI (Documentação)

## Arquitetura e Padroes
O projeto segue princípios de design para garantir manutenção e escalabilidade:

* Repository Pattern: Desacoplamento da lógica de acesso a dados da camada de controle.
* Injeção de Dependencia (DI): Gerenciamento de ciclo de vida de objetos via container nativo do .NET.
* Principios SOLID:
    * Responsabilidade Unica (SRP): Classes com funções bem definidas.
    * Inversao de Dependencia (DIP): Dependência de interfaces, não de implementações concretas.
* Configuração de Segurança (JWT)
    * Como a API exige Token, explique como o usuário deve se autenticar no Swagger.
 
## 📁 Estrutura do Projeto
* `Controllers/`: Endpoints da API.
* `Data/`: Contexto do banco de dados (EF Core).
* `Repositories/`: Implementação do padrão Repository.
* `Interfaces/`: Contratos de abstração.
* `Services/`: Lógica de negócio e JWT.
* `Models/`: Entidades de domínio.
* `Configuration/`: Configurações adicionais.
