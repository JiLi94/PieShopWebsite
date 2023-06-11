using Microsoft.EntityFrameworkCore;

namespace PieShopWebsite.Models
{
    public class PieRepository: IPieRepository
    {
        // store an instance of the PieShopDbContext class, which represents the database context.
        private readonly PieShopDbContext _pieShopDbContext;

        //inject the database context into the repository class.
        // contructor injection
        public PieRepository(PieShopDbContext pieShopDbContext)
        {
            _pieShopDbContext = pieShopDbContext;
        }

        public IEnumerable<Pie> AllPies
        {
            get
            {
                return _pieShopDbContext.Pies.Include(c => c.Category);
            }
        }

        public IEnumerable<Pie> PiesOfTheWeek
        {
            get
            {
                return _pieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
            }
        }

        // this is a method instead of property, so there is no 'get'
        public Pie? GetPieById(int pieId)
        {
            return _pieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
        }
    }
}
