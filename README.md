# 🎬 CRUD Filmes API

Este projeto é uma **Minimal API** desenvolvida em **.NET 8** utilizando **Entity Framework Core** com **SQLite** como banco de dados.  
O objetivo é **praticar lógica de programação** e a criação de APIs minimalistas com suporte a **CRUD** completo para gerenciamento de filmes.

## 🚀 Funcionalidades

- **Adicionar filme** com título, ano, gênero, diretor e status "assistido".
- **Listar filmes assistidos**.
- **Buscar filmes por gênero**.
- **Atualizar título de um filme**.
- **Soft Delete** (marcar como inativo).
- **Delete físico** (remoção definitiva do banco).

## 🛠 Tecnologias Utilizadas

- [.NET 8 Minimal API](https://learn.microsoft.com/aspnet/core/fundamentals/minimal-apis)
- [Entity Framework Core](https://learn.microsoft.com/ef/core/)
- [SQLite](https://www.sqlite.org/)

## 📂 Estrutura do Projeto

- **Data/** → Contexto do banco de dados.  
- **Migrations/** → Migrações do Entity Framework.  
- **Models/** → Entidades, DTOs e requisições.  
- **Program.cs** → Configuração da API.  

## 📌 Rotas da API

| Método | Endpoint | Descrição |
|--------|----------|-----------|
| **POST** | `/Filmes` | Adicionar um novo filme |
| **GET** | `/Filmes` | Listar todos os filmes assistidos |
| **GET** | `/Filmes/BuscaGenero/{genero}` | Buscar filmes por gênero |
| **PUT** | `/Filmes/Atualizar/{Title}` | Atualizar título de um filme |
| **DELETE** | `/Filmes/SoftDelete/{Title}` | Soft delete de um filme |
| **DELETE** | `/Filmes/DeletarFilme/{id}` | Exclusão física de um filme |

## 📖 Observação

> Este é um projeto **exclusivamente para fins de estudo**, com foco no aprendizado de **Minimal API** e **ORM**. Não é recomendado para uso em produção sem as devidas validações e melhorias de segurança.
