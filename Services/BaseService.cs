using Ecommerce_DOT_NET.Services;
using Ecommerce_DOT_NET.Models;
public class BaseService
{
    // private UserService userService;
    // BaseService()
    // {
    //     this.userService = new UserService();
    // }
    static void Main(string[] args)
    {
        UserService userService = new UserService();
        UserModel user = new UserModel() { Username = "admin", Password = "admin", Email = "nclongkk@gmail.com", Role = RoleEnum.Admin };
        userService.add(user);
    }

    //     public void InsertData()
    //     {
    //         UserModel user = new UserModel
    //         {
    //             Username = "admin",
    //             Password = "admin",
    //             Email = "nclongkk@gmail.com",
    //             Role = RoleEnum.Admin
    //         };
    //         userService.add(user);
    //     }
}