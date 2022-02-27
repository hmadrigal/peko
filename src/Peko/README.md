## Entity Framework

- To create a migration. Assuming current directory is `.\src\Peko.AvaloniaApp`

```shell
dotnet ef migrations add InitialCreate --project ..\Peko\
```

- To remove a migration
```shell
dotnet ef migrations remove
```

- To apply database update in code 
```shell
dotnet ef database update
```

