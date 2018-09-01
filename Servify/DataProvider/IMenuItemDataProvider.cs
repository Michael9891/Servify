using Servify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servify.DataProvider
{
    interface IMenuItemDataProvider
    {
        Task<IEnumerable<MenuItem>> GetMenuItems();

        Task<MenuItem> GetMenuItem(int menuItemId);

        Task AddMenuItem(MenuItem product);

        Task UpdateMenuItem(MenuItem product);

        Task DeleteMenuItem(int menuItemId);
    }
}
