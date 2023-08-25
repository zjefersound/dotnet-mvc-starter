# Tutorial projeto ASP.NET MVC 

Neste tutorial iremos criar um projeto MVC em asp.net com Entity Framework e SQL Server

## Get started

### 1º passo:

Para criar o projeto inicialize com o comando no seu terminal:

```bash
dotnet new mvc --no-https --output NomeDoProjeto
```

### 2ºpasso:

Adicione as dependências necessárias para o projeto:

```bash
dotnet add package Microsoft.EntityFrameworkCore --version 7.0.10
dotnet add package Microsoft.EntityFrameworkCore.Design --version 7.0.10
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 7.0.10
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 7.0.10
```

### 3ºpasso:

Crie seu model:

Exemplo:

```csharp
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PjJefersonSouza.Models
{
    public class Psychologist
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Crp requerido.")]
        [Display(Name = "Crp")]
        public string? Crp { get; set; }

        [Required(ErrorMessage = "especialidade requerido.")]
        [Display(Name = "Especialidade")]
        public string? Specialty { get; set; }

    }
}

```

Defina seu DbContext: 

```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PjJefersonSouza.Models;

namespace PjJefersonSouza.Data
{
    public class AppDbContext :
        IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Psychologist>? Psychologists { get; set; }

    }
}
```

### 4º passo: 

Configure a conexão do banco no ```appsettings.json``` 

```json
{
    ...
    "ConnectionStrings": {
        "DefaultContext": "Server=(localdb)\\MSSQLLocalDB;Database=PJJEFERSONSOUZADB;Trusted_Connection=True;MultipleActiveResultSets=True"
    }
}
```

### 5º passo:

No arquivo ```Program.cs``` defina o DbContext no builder:

```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PjJefersonSouza.Data;
using PjJefersonSouza.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.
            GetConnectionString("DefaultContext")
    )
);

```

### 6º passo

Para configurar e atualizar o banco:

Instale o Entity Framework tool 

```bash
dotnet tool install --global dotnet-ef
```

Crie sua migration inicial:

```bash
dotnet ef migrations add InitialCreate
```

Para atualizar o banco:

```bash
dotnet ef database update
```
