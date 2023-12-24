# Database

### Run Postgres in Docker
1.
```bash
docker volume create harvesitpostgres

docker volume ls

docker run --name harvesit-postgres -e POSTGRES_PASSWORD=harves1t -d postgres
docker run -d -v harvesitpostgres:/data/db -e POSTGRES_PASSWORD=harves1t --name harvesit-postgres -p 5432:5432 postgres
```

### Run PgAdmin in Docker
1.
```bash
docker run --name harvesit-pgadmin -e "PGADMIN_DEFAULT_EMAIL=ryan@harvesit.com" -e "PGADMIN_DEFAULT_PASSWORD=harves1t" -p 5050:80 -d dpage/pgadmin4 
```
2. Browse http://localhost:5050/login
- user: ryan@harvesit.com
- pass: harves1t


### Link to Postgres and PgAdmin
```bash
docker network create --driver bridge harvesit-db-network

docker network connect harvesit-db-network harvesit-pgadmin
docker network connect harvesit-db-network harvesit-postgres
docker network inspect harvesit-db-network
```

### Connection String
`http://localhost:5432/`

```bash
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design (host project)
dotnet add package Microsoft.EntityFrameworkCore.Tools (ef project)
dotnet ef migrations add InitialCreate --project ..\Harvesit.AdministratorServices.Infrastructure\Harvesit.AdministratorServices.Infrastructure.csproj (host project)
dotnet ef database update (host project)
```