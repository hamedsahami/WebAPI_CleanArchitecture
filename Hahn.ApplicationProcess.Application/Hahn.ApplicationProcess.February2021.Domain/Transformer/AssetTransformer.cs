using AutoMapper;
using Hahn.ApplicationProcess.February2021.Data.Models;
using Hahn.ApplicationProcess.February2021.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Transformer
{
    public class AssetTransformer
    {
        private readonly IMapper _mapper;
        public Asset toModel(AssetDTO assetDto)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AssetDTO, Asset>(MemberList.Destination));
            Asset asset= config.CreateMapper().Map<Asset>(assetDto);
            return asset;
        }
        public AssetDTO toDTO(Asset asset)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Asset, AssetDTO>(MemberList.Destination));
            AssetDTO assetDTO= config.CreateMapper().Map<AssetDTO>(asset);
            return assetDTO;
        }
    }
}
