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
