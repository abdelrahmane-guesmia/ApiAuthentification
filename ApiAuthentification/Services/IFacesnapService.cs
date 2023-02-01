using ApiAuthentification.Model;

namespace ApiAuthentification.Services
{
    public interface IFacesnapService
    {
        void AddFacesnap(Facesnap facesnap);
        void UpdateFacesnap(Facesnap facesnap);
        void DeleteFacesnap(Guid id);
        Facesnap GetSingleFacesnap(Guid id);
        List<Facesnap> GetFacesnaps();
    }
}
