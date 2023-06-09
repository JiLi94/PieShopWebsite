using PieShopWebsite.Models;

namespace PieShopWebsite.ViewModels
{
    public class PieListViewModel
    {
        public IEnumerable<Pie> Pies { get;}
        public string ? CurrentCategoty { get;}

        public PieListViewModel(IEnumerable<Pie> pies, string? currentCategoty)
        {
            Pies = pies;
            CurrentCategoty = currentCategoty;
        }
    }
}
