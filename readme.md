# Desafio Técnico de Web Scraping

Este projeto é composto por um backend em .NET e um frontend em React com TypeScript. O objetivo é realizar web scraping de informações nutricionais de alimentos e exibi-las em uma interface web.

## Estrutura do Projeto

## Backend

O backend é desenvolvido em .NET 6 e está localizado na pasta `WebScrapping-Backend`. Ele é responsável por realizar o web scraping e fornecer uma API para o frontend consumir.

### Estrutura em camadas do Backend

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
2. No Visual Studio, `ferramentas -> Gerenciador de Pacotes NuGet -> Console de Gerencidor de Pacotes`.

![image](https://github.com/user-attachments/assets/90ce12ab-53b2-457d-bd25-15fcf1022050)

3. Execute o comando `Update-Database` para executar as Migrations e criar as tabelas no banco de dados.

![image](https://github.com/user-attachments/assets/5ef8a444-454e-46b2-9f94-2195b3059d15)
 
4. Compile e execute o projeto.

## Frontend

O frontend é desenvolvido em React com TypeScript e está localizado na pasta `WebScrapping-Frontend`. Ele consome a API fornecida pelo backend para exibir as informações nutricionais dos alimentos.

### Estrutura do Frontend

- **src/api**: Contém as funções para realizar requisições à API.
- **src/components**: Contém os componentes reutilizáveis.
- **src/pages**: Contém as páginas da aplicação.
- **src/types**: Contém as definições de tipos TypeScript.

### Tecnologias utilizadas:

1. TailwindCSS - para estilização.
2. DaisyUi - Biblioteca de componentes.
3. Axios - Ferramenta para realizar requisições HTTP

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

## Exemplos do Projeto Rodando

1. Caso o Front-end esteja rodando e o back-end não.
   
![image](https://github.com/user-attachments/assets/e25eaac0-a4ed-425c-a006-f69361c22ef8)

3. Fron-end e Back-end rodando.
   
![image](https://github.com/user-attachments/assets/cfbba37f-1788-49da-9f93-62572f032aa4)

4. Entrando em uma Comida, se ela não esstiver cadastrada no banco.
   
![image](https://github.com/user-attachments/assets/60e6641d-33e7-49d0-a59a-2124977375e3)

6. Clicando em `captura de alimentos` deverá aparecer assim:
   
![image](https://github.com/user-attachments/assets/d6426db9-c58b-47c7-bd27-98012b0c777d)
