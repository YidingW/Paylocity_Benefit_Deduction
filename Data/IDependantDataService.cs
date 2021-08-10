using System.Threading.Tasks;
using Domain;

namespace Data
{
    public interface IDependantDataService
    {
        Task AddDependant(Dependant dependant);
    }
}