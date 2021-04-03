
using AutoMapper;
using FluentValidation;
using Hahn.ApplicationProcess.February2021.Data.Interfaces;
using Hahn.ApplicationProcess.February2021.Data.IRepositories;
using Hahn.ApplicationProcess.February2021.Data.Models;
using Hahn.ApplicationProcess.February2021.Data.Repository;
using Hahn.ApplicationProcess.February2021.Domain.DTO;
using Hahn.ApplicationProcess.February2021.Domain.Transformer;
using Hahn.ApplicationProcess.February2021.Domain.Validators;
using System.Linq;

namespace Hahn.ApplicationProcess.February2021.Domain.Services
{
    public class AssetService : IAssetService
    {
        private readonly IUnitOfWork _unitOfWork; 

        private readonly AssetValidator _validator;

        private readonly AssetTransformer _transformer; 
        public AssetService(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
            _validator = new AssetValidator();
            _transformer = new AssetTransformer();
        }
        public void Create(AssetDTO assetDTO)
        {
            _validator.Validate(assetDTO, options => { options.ThrowOnFailures();   });
            this._unitOfWork.Repository<Asset>().Create(_transformer.toModel(assetDTO));
            _unitOfWork.Save();
        }

        public void Delete(int id)
        {
            
            Asset deleteResult = this._unitOfWork.Repository<Asset>().GetByID(id);
            this._unitOfWork.Repository<Asset>().Delete(deleteResult);
            _unitOfWork.Save();
        }

        public IQueryable<AssetDTO> GetAll()
        {
            //todo 
            return null;
        }

        public AssetDTO GetByID(object id)
        {
            Asset result = this._unitOfWork.Repository<Asset>().GetByID(id);
            return _transformer.toDTO(result);
        }

        public void Save()
        {
            this._unitOfWork.Save();
        }

        public void Update(AssetDTO assetDTO)
        {
            _validator.Validate(assetDTO, options => { options.ThrowOnFailures(); });
            this._unitOfWork.Repository<Asset>().Update(_transformer.toModel(assetDTO));
            _unitOfWork.Save();
        }
    }
}
