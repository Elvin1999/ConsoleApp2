using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp2
{
    class User {
        public User(string name, string surname, int myProperty)
        {
            Name = name;
            Surname = surname;
            MyProperty = myProperty;
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int MyProperty { get; set; }
    }
    class Controller {
        Logger log = LogManager.GetCurrentClassLogger();
        List<User> users = new List<User>();

        public void AddUser(User user)
        {
            users.Add(user);
            log.Info("User was added");
        }
        public void Removed(string name)
        {
            var item = users.SingleOrDefault(x => x.Name == name);
            if (item == null)
            {
                log.Error("User did not find");
            }
            else
            {
                log.Debug("User removed");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Elvin", "Camalzade", 19);
            Controller controller = new Controller();
            controller.AddUser(user);
            controller.Removed("Elvin");
        }
    }
}
