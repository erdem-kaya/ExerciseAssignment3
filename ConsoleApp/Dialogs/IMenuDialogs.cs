using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

  namespace ConsoleApp.Dialogs
{
    public interface IMenuDialogs
    {
        void MenuOptions();
        void NewUser();
        Task ViewAllUsers();
    }
}

