** install the EF Core CLI tools globally

dotnet tool install -g dotnet-ef

** use the following commands to manage your EF Core migrations and database updates
make sure to replace [MigrationNameGoesHere] with the actual name of your migration when running the commands

dotnet ef migrations add [MigrationNameGoesHere]
dotnet ef database update
dotnet ef database update [MigrationNameGoesHere]
dotnet ef migrations remove