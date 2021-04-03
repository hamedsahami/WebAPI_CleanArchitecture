using Hahn.ApplicationProcess.February2021.Domain.DTO;
using System.Linq;

namespace Hahn.ApplicationProcess.February2021.Domain.Services
{
    public interface IAssetService
    {
        void Create(AssetDTO assetDTO);
        IQueryable<AssetDTO> GetAll();
        AssetDTO GetByID(object id);
        void Update(AssetDTO assetDTO);
        void Delete(int id);
        void Save();
    }
}