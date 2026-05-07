using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.Sqlite;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

// https://www.connectionstrings.com/ - great source for connection strings
// https://sqlitestudio.pl/ - great tool to manage SQLite databases

string cs = "Data Source=mydb.db;";
InitDB(cs);

app.MapGet("/", () => "This is my api");

app.MapGet("/users/unsafe", (string userName) => {
    using var connection = new SqliteConnection(cs);
    connection.Open();

    using var cmd = connection.CreateCommand();
    cmd.CommandText = $"""
        SELECT
            *
        FROM
            Users
        WHERE
            Username = '{userName}'
    """;

    using var reader = cmd.ExecuteReader();

    var users = new List<User>();

    while (reader.Read()) {
        users.Add(new User(
            reader.GetInt32(0),
            reader.GetString(1),
            reader.GetString(2),
            reader.GetString(3),
            reader.GetBoolean(4)
        ));
    }

    return Results.Ok(users);
});

app.MapGet("/users/safe", (string userName) => {
    using var connection = new SqliteConnection(cs);

    connection.Open();

    using var cmd = connection.CreateCommand();

    cmd.CommandText = """
        SELECT
            *
        FROM
            Users
        WHERE
            Username = @UserName
    """;

    cmd.Parameters.AddWithValue("@UserName", userName);

    using var reader = cmd.ExecuteReader();

    var users = new List<User>();

    while (reader.Read()) {
        users.Add(new User(
            reader.GetInt32(0),
            reader.GetString(1),
            reader.GetString(2),
            reader.GetString(3),
            reader.GetBoolean(4)
        ));
    }

    return Results.Ok(users);

});


app.Run();


static void InitDB(string connectionString) {
    using var connection = new SqliteConnection(connectionString);

    connection.Open();

    using var cmd = connection.CreateCommand();

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

record User(int Id, string Username, string Email, string PasswordHash, bool IsAdmin);