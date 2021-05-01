namespace Infrastructure.Repositories.Queries
{
    public static class UserQueries
    {
        public static string INSERT = @"INSERT INTO accounts (Username, Password, Role, created_on) 
            VALUES (@Username, @Password, @Role, now()) RETURNING ID;";
        public static string GET_USER_BY_USERNAME = @"select * from accounts where username = @username;";
    }
}