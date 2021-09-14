
using App1.Models;
using System.Threading.Tasks;

namespace App1.ViewModels
{
    public partial class ItemsViewModel
    {
        public interface INavigationService
        {
            Task GoToItemDetailPage(Item item);
        }

    }
}
