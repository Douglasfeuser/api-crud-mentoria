```                
                         ________  ________  ___  ________  ________  ___  ___  ________     
                        |\   __  \|\   __  \|\  \|\   ____\|\   __  \|\  \|\  \|\   ___ \    
                        \ \  \|\  \ \  \|\  \ \  \ \  \___|\ \  \|\  \ \  \\\  \ \  \_|\ \   
                         \ \   __  \ \   ____\ \  \ \  \    \ \   _  _\ \  \\\  \ \  \ \\ \  
                          \ \  \ \  \ \  \___|\ \  \ \  \____\ \  \\  \\ \  \\\  \ \  \_\\ \ 
                           \ \__\ \__\ \__\    \ \__\ \_______\ \__\\ _\\ \_______\ \_______\
                            \|__|\|__|\|__|     \|__|\|_______|\|__|\|__|\|_______|\|_______|
```

**ApiCrud**

Projeto de API para livraria

## Arquitetura
Antes de entrarmos nos recursos, vamos explicar a organização do código:

**MODELS:**
Modelos são usados para definir suas futuras entidades de banco de dados. Usando o modelo BaseEntity para centralizar a lógica de dados, como IDs e datas de criação, para um código mais limpo.

**REPOSITORIES:**
Repositórios são utilizados para interagir diretamente com o banco de dados usando uma camada de abstração para comunicação.

**SERVICES:**
Serviços são empregados para manipular dados do cliente usando DTOs (Data Transfer Objects) e interagir com o banco de dados usando métodos de repositório.

**CONTROLLERS:**
Controladores são responsáveis por interagir com sua API através de endpoints e recuperar dados.

**MIGRATIONS :**
Migrações são usadas para interagir com o banco de dados, criando seus Modelos nele.

Criar migrações : `dotnet ef migrations add <migration_name>`

---

## EF Core vs. .NET Framework

| Característica | EF Core | .NET Framework (EF6) |
|---|---|---|
| Plataforma | Multiplataforma | Principalmente Windows |
| Leveza | Mais leve e modular | Mais pesado e monolítico |
| Desenvolvimento | Orientado a convenções e dados | Mais flexível, mas com mais configuração |
| Suporte a Banco de Dados | Amplo suporte a diversos bancos de dados | Foco principal em SQL Server |
| Async/Await | Suporte nativo e recomendado | Suporte através de bibliotecas de terceiros |
| Injeção de Dependência | Fortemente integrado | Requer configurações adicionais |
| Ciclo de Vida | Ativo e em constante desenvolvimento | Manutenção limitada, com foco em correções de bugs |

**Quando usar o EF Core:**

* Novos projetos
* Aplicações que exigem alta performance e escalabilidade
* Desenvolvimento de APIs RESTful

**Quando usar o .NET Framework (EF6):**

* Projetos legados
* Quando é necessário utilizar funcionalidades específicas do EF6
* Em cenários onde a migração para o EF Core não é viável devido à complexidade do projeto

Documentação: https://learn.microsoft.com/en-us/ef/efcore-and-ef6/

## LINQ vs. EF Core LINQ

LINQ, que significa Language Integrated Query, é uma tecnologia desenvolvida pela Microsoft que possibilita a formulação de consultas em bancos de dados utilizando a sintaxe da própria linguagem de programação, como o C#, de maneira integrada ao código. O EF Core LINQ é a versão do LINQ adaptada para o Entity Framework Core, um popular mapeador objeto-relacional (ORM) voltado para o .NET.

| Característica | LINQ | CoreLINQ |
|---|---|---|
| Abrangência | Pode ser usado com diversas fontes de dados (coleções em memória, XML, bancos de dados, etc.) | Especificamente projetado para consultar dados em bancos de dados relacionais através do EF Core. |
| Provedor | Requer um provedor LINQ específico para cada tipo de fonte de dados. | Utiliza o provedor LINQ to Entities, integrado ao EF Core, para traduzir as consultas em SQL e executá-las no banco de dados. |
| Abstração | Permite abstrair a lógica de acesso a dados, tornando o código mais limpo e legível. | Oferece uma camada de abstração mais alta, permitindo trabalhar com objetos .NET em vez de diretamente com tabelas e colunas do banco de dados. |
| Mapeamento Objeto-Relacional | Não possui mapeamento objeto-relacional por padrão. | Realiza o mapeamento entre objetos .NET e tabelas do banco de dados, facilitando a persistência e recuperação de dados. |
| Funcionalidades Específicas | Pode ser usado para realizar consultas em diversas fontes de dados, mas não possui funcionalidades específicas para ORM, como tracking de mudanças, lazy loading, etc. | Oferece um conjunto completo de funcionalidades para trabalhar com dados relacionais, incluindo tracking de mudanças, lazy loading, eager loading, etc. |
| Usos | Consultas em coleções em memória, Integração com outras fontes de dados que suportam LINQ, Cenários onde não é necessário um ORM completo | Desenvolvimento de aplicações de acesso a dados com banco de dados relacional, Utilização de um ORM para abstrair a complexidade do acesso a dados, Beneficiar-se das funcionalidades específicas do EF Core, como tracking de mudanças, lazy loading, etc. |

```

// Usando LINQ para filtrar uma lista em memória
var numeros = new List<int> { 1, 2, 3, 4, 5 };
var numerosPares = numeros.Where(n => n % 2 == 0);

// Usando EF Core LINQ para consultar um banco de dados
using (var context = new MeuDbContext())
{
    var clientes = context.Clientes
        .Where(c => c.Idade > 18)
        .OrderBy(c => c.Nome)
        .ToList();
}

```

## .IEnumerable vs .IQueryable

As interfaces IEnumerable e IQueryable do C# representam sequências de dados, permitindo a iteração sobre coleções. No entanto, existem diferenças importantes entre elas no momento da execução da consulta e à flexibilidade que oferecem.

- **IEnumerable**: Refere-se a uma coleção de elementos que podem ser percorridos de maneira sequencial. A execução da consulta ocorre imediatamente ao começar a iterar sobre a coleção, tornando-a adequada para trabalhar com dados na memória.

- **IQueryable**: Refere-se a uma consulta que pode ser executada de forma atrasada. Ela é convertida em uma expressão e apenas é executada quando é realmente necessária, como ao utilizar os métodos ToList() ou FirstOrDefault(). É mais apropriada para interações com fontes de dados externas, como bancos de dados, onde a consulta pode ser otimizada e postponizada.

- **IQueryable deriva de IEnumerable**: Isso significa que você pode usar métodos de extensão de IEnumerable em objetos IQueryable, mas nem todos os métodos de IEnumerable são suportados por IQueryable.

| Característica | IEnumerable | IQueryable |
|---|---|---|
| Execução da consulta | Imediata, ao iterar sobre a coleção | Diferida, ao materializar a consulta (ToList, FirstOrDefault) |
| Flexibilidade | Menos flexível, as operações são executadas na memória | Mais flexível, permite construir consultas complexas que podem ser otimizadas pelo provedor de consultas (EF Core) |
| Fonte de dados | Qualquer coleção em memória | Principalmente bancos de dados, mas pode ser usado com outras fontes que implementem IQueryable |
| Otimização | Pouca ou nenhuma otimização | Permite otimizações, como tradução para SQL e execução no banco de dados |
| Usos | Coleções em memória, LINQ to Objects | LINQ to Entities, LINQ to SQL, outras fontes de dados remotas |
| LINQ | LINQ-to-object | LINQ-to-SQL |

```
// IEnumerable
IEnumerable<I> numeros = new List<int> { 1, 2, 3, 4, 5 };
IEnumerable<I> numerosPares = numeros.Where(n => n % 2 == 0); // Consulta executada imediatamente

// IQueryable (EF Core)
using (var context = new MeuDbContext())
{
    IQueryable<C> clientes = context.Clientes
        .Where(c => c.Idade > 18) // Consulta não executada ainda
        .OrderBy(c => c.Nome);

    // Ao chamar ToList(), a consulta é enviada para o banco de dados e os resultados são materializados
    IQueryable<C> Adultos = clientes.ToList();
}
```

## Migrations

É uma forma de versionar o schema de sua aplicação. As migrations no Entity Framework (EF) Core são um recurso que permite gerenciar e aplicar mudanças no esquema do banco de dados de maneira incremental, de acordo com as modificações feitas nos modelos de dados da aplicação. Esse processo garante que o banco de dados esteja sempre alinhado com a estrutura das entidades da aplicação, sem perder dados existentes.

Funcionamento básico das migrations:
* Criação de uma migration
* Aplicação da migration
* Reversibilidade
* Gerenciamento de migrações

# Seeders

Seeders no Entity Framework (EF) são utilizados para inserir dados iniciais no banco de dados, como registros padrão ou de teste, após a criação ou atualização do esquema. Eles garantem que o banco já contenha informações básicas sem a necessidade de inserir manualmente.

Esses dados podem ser inseridos durante o processo de migrations ou na inicialização do aplicativo, utilizando o método OnModelCreating ou uma classe dedicada para a tarefa. Seeders são úteis para populações iniciais de entidades como categorias, usuários ou permissões, garantindo que o banco esteja preparado para uso imediato após a criação.

## Code First Migrations

Code First Migrations é a forma recomendada de evoluir o esquema do seu banco de dados se você estiver utilizando esse fluxo.
As migrações permitem:

* Criar um banco de dados inicial compatível com seu modelo EF
* Gerar migrações para acompanhar as alterações que você faz no seu modelo EF
* Manter seu banco de dados atualizado com essas alterações

Gerando e Executando Migrações
* Pelo Rider existe um menu que faz as tratativas do EF, sendo possivel criar a migration e dar update no banco por esse menu.
* Execute o comando Update-Database para aplicar a migração inicial e criar o banco de dados.
* Para cada alteração no modelo, execute Add-Migration <MigrationName> para gerar uma nova migração e Update-Database para aplicá-la.

Migrando para uma Versão Específica ou Downgrade
* Use o comando Update-Database -TargetMigration <MigrationName> para migrar para uma versão específica.
* Para downgrade, use o parâmetro –TargetMigration: $InitialDatabase para reverter todas as migrações.

Observações
* Use a flag –Script se quiser receber um script da migração

