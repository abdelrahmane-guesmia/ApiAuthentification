using ApiAuthentification.Model;
using ApiAuthentification.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTestApiAuthentification
{
    public class FacesnapServiceFake : IFacesnapService
    {
        private readonly List<Facesnap> _facesnaps;
        public FacesnapServiceFake()
        {
            _facesnaps = new List<Facesnap>()
            {
                new Facesnap() { id = new Guid("a9678c7a-ae8a-490d-8562-c88620515f12"),
                    title = "test", description="test", imageUrl = "test", snaps = 0, 
                    location = "test", createdAt = new DateTime(2023,1,31,15,1,35,124) },
            };
        }
        public List<Facesnap> GetFacesnaps()
        {
            return _facesnaps.ToList();
        }
        public void AddFacesnap(Facesnap newItem)
        {
            newItem.id = Guid.NewGuid();
            _facesnaps.Add(newItem);
        }
        public Facesnap GetSingleFacesnap(Guid id)
        {
            return _facesnaps.Where(a => a.id == id).FirstOrDefault();
        }
        public void DeleteFacesnap(Guid id)
        {
            var existing = _facesnaps.First(a => a.id == id);
            _facesnaps.Remove(existing);
        }

        public void UpdateFacesnap(Facesnap facesnap)
        {
        }
    }
}
