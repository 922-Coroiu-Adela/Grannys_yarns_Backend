using Grannys_yarns_API.Model;
using Grannys_yarns_API.Repository;

namespace Grannys_yarns_API.Service
{
    public class Service: iService
    {
        private iRepository repository;

        public Service(iRepository repository)
        {
            this.repository = repository;
        }

        public void AddYarn(Yarn yarn)
        {
            yarn.id = repository.GetAllYarns().Max(p => p.id) + 1;
            repository.AddYarn(yarn);
        }

        public void UpdateYarn(Yarn updatedYarn)
        {
            repository.UpdateYarn(updatedYarn);
        }

        public void DeleteYarn(int id)
        {
            repository.DeleteYarn(id);
        }

        public List<Yarn> GetAllYarns()
        {
            return repository.GetAllYarns();
        }

        public Yarn GetYarn(int id)
        {
            return repository.GetYarn(id);
        }
    }
}
