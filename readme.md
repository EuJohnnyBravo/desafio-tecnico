# Desafio Técnico de Web Scraping

Este projeto é composto por um backend em .NET e um frontend em React com TypeScript. O objetivo é realizar web scraping de informações nutricionais de alimentos e exibi-las em uma interface web.

## Estrutura do Projeto

## Backend

O backend é desenvolvido em .NET 6 e está localizado na pasta `WebScrapping-Backend`. Ele é responsável por realizar o web scraping e fornecer uma API para o frontend consumir.

### Estrutura do Backend

- **WebScrapping.API**: Contém os controladores e a configuração da API.
- **WebScrapping.Application**: Contém os casos de uso e a lógica de aplicação.
- **WebScrapping.Communication**: Contém as classes de comunicação e DTOs.
- **WebScrapping.Domain**: Contém as entidades e interfaces de repositório.
- **WebScrapping.Exception**: Contém as exceções personalizadas.
- **WebScrapping.Infrastructure**: Contém a implementação dos repositórios e a configuração do banco de dados.

### Configuração

1. Certifique-se de ter o Docker instalado.
2. Execute o comando `docker-compose up -d` na raíz do projeto para iniciar o banco de dados PostgreSQL.

### Executando o Backend

1. Abra a solução `desafio-webscrapping-backend.sln` no Visual Studio.
2. Compile e execute o projeto.

## Frontend

O frontend é desenvolvido em React com TypeScript e está localizado na pasta `WebScrapping-Frontend`. Ele consome a API fornecida pelo backend para exibir as informações nutricionais dos alimentos.

### Estrutura do Frontend

- **src/api**: Contém as funções para realizar requisições à API.
- **src/components**: Contém os componentes reutilizáveis.
- **src/pages**: Contém as páginas da aplicação.
- **src/types**: Contém as definições de tipos TypeScript.

### Configuração

1. Certifique-se de ter o Node.js instalado.
2. Navegue até a pasta `WebScrapping-Frontend` e execute `npm install` para instalar as dependências.

### Executando o Frontend

1. Navegue até a pasta `WebScrapping-Frontend`.
2. Execute `npm run dev` para iniciar o servidor de desenvolvimento.

## Endpoints da API

### FoodController

- `POST /api/food/`: Realiza o web scraping de alimentos.
- `GET /api/food/`: Retorna todos os alimentos.
- `GET /api/food/code/{code}`: Retorna um alimento pelo código.

### FoodCompositionController

- `POST /api/foodComposition/code/{code}`: Realiza o web scraping da composição de um alimento pelo código.
- `GET /api/foodComposition/code/{code}`: Retorna a composição de um alimento pelo código.

## Contribuição

Sinta-se à vontade para contribuir com este projeto. Para isso, siga os passos abaixo:

1. Faça um fork do repositório.
2. Crie uma branch para sua feature (`git checkout -b feature/nova-feature`).
3. Commit suas mudanças (`git commit -m 'Adiciona nova feature'`).
4. Faça o push para a branch (`git push origin feature/nova-feature`).
5. Abra um Pull Request.
