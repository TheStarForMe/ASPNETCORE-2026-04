using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// https://www.connectionstrings.com/ - great source for connection strings
InitDB("Data Source=mydb.db;");


app.Run();



static void InitDB(string connectionString) {
    using var connection = new SqliteConnection(connectionString);

    connection.Open();

    var cmd = connection.CreateCommand();

    cmd.CommandText = """

        DROP TABLE IF EXISTS Users;

        CREATE TABLE Users (
            Id INTEGER PRIMARY KEY AUTOINCREMENT,
            Username TEXT NOT NULL,
            Email TEXT NOT NULL,
            PasswordHash TEXT NOT NULL,
            IsAdmin BOOLEAN NOT NULL DEFAULT 0
        );

            INSERT INTO
                Users
            (Username, Email, PasswordHash, IsAdmin)
            VALUES
                ('admin', 'admin@example.com', 'HAHHBJSDDSDS', 1),
                ('simon', 'simon@example.com', 'ABCDFHSOKDJK', 0),
                ('john', 'john@example.com', 'HJSSDSGDSGDSD', 0);

        """;

    cmd.ExecuteNonQuery();
}
