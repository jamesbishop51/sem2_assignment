using System;
using System.Threading.Tasks;
using Dropbox.Api;

class Program
{
    static string Token = "P1OdET-_KgcAAAAAAAAAFe7kLF-CVqXd--Rbt1RYFNZZmyQNiwLm6A1jLiPP0YqV";
    static void Main(string[] args)
    {
        var task = Task.Run((Func<Task>)Program.Run);
        task.Wait();
    }

    static async Task Run()
    {
        using (var dbx = new DropboxClient(Token))
        {
            var full = await dbx.Users.GetCurrentAccountAsync();
            Console.WriteLine("{0} - {1}", full.Name.DisplayName, full.Email);
        }
    }

}