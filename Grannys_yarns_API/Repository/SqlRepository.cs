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
            Yarn existingYarn = context.Yarns.FirstOrDefault(x => x.yid == updatedYarn.yid);
            if (existingYarn == null)
            {
                throw new Exception("Yarn not found");
            }

            if (existingYarn.did != updatedYarn.did)
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
            return context.Yarns.FirstOrDefault(x => x.yid == id);
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
            Distributor existingDistributor = context.Distributors.FirstOrDefault(x => x.did == updatedDistributor.did);
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
            return context.Distributors.FirstOrDefault(x => x.did == id);
        }

        public List<Distributor> GetAllDistributors() 
        { 
            return context.Distributors.ToList();
        }

        public void RemoveSession(int distributorId)
        {
            var sessionToRemove = context.Session.FirstOrDefault(x => x.did == distributorId);
            if (sessionToRemove == null)
            {
                throw new Exception("Session not found");
            }
            context.Session.Remove(sessionToRemove);
            context.SaveChanges();
        }

        public void AddSession(Session session)
        {
            if (context.Session.Any(s => s.did == session.did))
            {
                RemoveSession(session.did);
            }
            context.Session.Add(session);
            context.SaveChanges();
        }

        public bool ValidToken(string token)
        {
            return context.Session.Any(s => s.token == token);
        }

        public Distributor GetDistributorByUsername(string username)
        {
            var distributor = context.Distributors.FirstOrDefault(x => x.username == username);
            if (distributor == null)
            {
                throw new Exception("Distributor not found");
            }
            return distributor;
        }

    }
}
