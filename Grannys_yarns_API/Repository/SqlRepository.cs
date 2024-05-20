using Grannys_yarns_API.Data;
using Grannys_yarns_API.Model;

namespace Grannys_yarns_API.Repository
{
    public class SqlRepository: iRepository
    {
        public readonly DataContext context;

        public SqlRepository(DataContext context)
        {
            this.context = context;
        }

        

        public void AddYarn(Yarn yarn)
        {
            context.Yarns.Add(yarn);
            context.SaveChanges();
        }

        public void UpdateYarn(Yarn updatedYarn)
        {
            Yarn existingYarn = context.Yarns.FirstOrDefault(x => x.id == updatedYarn.id);
            if (existingYarn == null)
            {
                throw new Exception("Yarn not found");
            }

            if (existingYarn.distributorId != updatedYarn.distributorId)
            {
                throw new Exception("You are not allowed to change the distributor of the yarn");
            }
            context.Entry(existingYarn).CurrentValues.SetValues(updatedYarn);
            context.SaveChanges();
        }

        public void DeleteYarn(int id)
        {
            var yarnToDelete = GetYarn(id);
            if (yarnToDelete == null)
            {
                throw new Exception("Yarn not found");
            }
            context.Yarns.Remove(yarnToDelete);
            context.SaveChanges();
        }

        public Yarn GetYarn(int id)
        {
            return context.Yarns.FirstOrDefault(x => x.id == id);
        }

        public List<Yarn> GetAllYarns()
        {
            return context.Yarns.ToList();
        }

        public void AddDistributor(Distributor distributor)
        {
            context.Distributors.Add(distributor);
            context.SaveChanges();
        }

        public void UpdateDistributor(Distributor updatedDistributor)
        {
            Distributor existingDistributor = context.Distributors.FirstOrDefault(x => x.id == updatedDistributor.id);
            if (existingDistributor == null)
            {
                throw new Exception("Distributor not found");
            }
            context.Entry(existingDistributor).CurrentValues.SetValues(updatedDistributor);
            context.SaveChanges();
        }

        public void DeleteDistributor(int id)
        {
            var distributorToDelete = GetDistributor(id);
            if (distributorToDelete == null)
            {
                throw new Exception("Distributor not found");
            }
            context.Distributors.Remove(distributorToDelete);
            context.SaveChanges();
        }

        public Distributor GetDistributor(int id)
        {
            return context.Distributors.FirstOrDefault(x => x.id == id);
        }

        public List<Distributor> GetAllDistributors() 
        { 
            return context.Distributors.ToList();
        }

        

        

    }
}
