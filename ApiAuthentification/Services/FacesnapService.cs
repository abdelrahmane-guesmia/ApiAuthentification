using ApiAuthentification.Model;
using ApiAuthentification.Auth;

namespace ApiAuthentification.Services
{
    public class FacesnapService : IFacesnapService
    {
        private readonly ApplicationDbContext _context;

        public FacesnapService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddFacesnap(Facesnap facesnap)
        {
            _context.facesnaps.Add(facesnap);
            _context.SaveChanges();
        }

        public void UpdateFacesnap(Facesnap facesnap)
        {
            _context.facesnaps.Update(facesnap);
            _context.SaveChanges();
        }

        public void DeleteFacesnap(Guid id)
        {
            var entity = _context.facesnaps.FirstOrDefault(t => t.id == id);
            if(entity != null)
            {
                _context.facesnaps.Remove(entity);
            }
            _context.SaveChanges();
        }

        public Facesnap GetSingleFacesnap(Guid id)
        {
            return _context.facesnaps.FirstOrDefault(t => t.id == id);
        }

        public List<Facesnap> GetFacesnaps()
        {
            return _context.facesnaps.ToList();
        }
    }
}
