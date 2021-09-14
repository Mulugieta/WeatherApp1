
using App1.Models;
using App1.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.ViewModels
{
    public partial class ItemsViewModel
    {
        public class NavigationService : INavigationService
        {
            public Task GoToItemDetailPage(Item item)
            {
                return Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={item.Id}");
            }
        }

    }
}
