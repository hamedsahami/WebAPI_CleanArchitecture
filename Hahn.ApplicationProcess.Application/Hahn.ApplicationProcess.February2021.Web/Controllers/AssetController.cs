using Hahn.ApplicationProcess.February2021.Domain.DTO;
using Hahn.ApplicationProcess.February2021.Domain.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Web.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class AssetController : ControllerBase
    {
        private readonly ILogger<AssetController> _logger;
        private readonly IAssetService _service;
        public AssetController(IAssetService assetService, ILogger<AssetController> logger)
        {
            _logger = logger;
            _service = assetService;
        }

        [HttpGet]
        public AssetDTO Get(int Id)
        {
            AssetDTO assetDTO = null;
            try
            {
                _logger.LogInformation("Start processing request from {Address}", ControllerContext.HttpContext.Request.Path);
                assetDTO = _service.GetByID(Id);
                _logger.LogInformation("Process is Completed request from {Address}", ControllerContext.HttpContext.Request.Path);
            }
            catch (Exception ex)
            {
                _logger.LogError("Process is Stoped for this url {0},Message: {1}", ControllerContext.HttpContext.Request.Path, ex.Message);
            }
            return assetDTO;
        }




        [HttpPost]
        public HttpStatusCode Create(AssetDTO dto)
        {
            AssetDTO assetDTO = null;
            try
            {
                _logger.LogInformation("Start processing request from {Address}", ControllerContext.HttpContext.Request.Path);
                _service.Create(dto);
                _logger.LogInformation("Process is Completed request from {Address}", ControllerContext.HttpContext.Request.Path);
            }
            catch (Exception ex)
            {
                _logger.LogError("Process is Stoped for this url {0},Message: {1}", ControllerContext.HttpContext.Request.Path, ex.Message);
                return (HttpStatusCode)500;
            }
            return HttpStatusCode.Created;
        }


        [HttpPut]
        public HttpStatusCode Update(AssetDTO dto)
        {
            try
            {
                _logger.LogInformation("Start processing request from {Address}", ControllerContext.HttpContext.Request.Path);
                _service.Update(dto);
                _logger.LogInformation("Process is Completed request from {Address}", ControllerContext.HttpContext.Request.Path);
            }
            catch (Exception ex)
            {
                _logger.LogError("Process is Stoped for this url {0},Message: {1}", ControllerContext.HttpContext.Request.Path, ex.Message);
                return (HttpStatusCode)500;
            }
            return HttpStatusCode.OK;
        }

        [HttpDelete]
        public HttpStatusCode Delete(int id)
        {
            try
            {
                _logger.LogInformation("Start processing request from {Address}", ControllerContext.HttpContext.Request.Path);
                _service.Delete(id);                      
                _logger.LogInformation("Process is Completed request from {Address}", ControllerContext.HttpContext.Request.Path);
            }
            catch (Exception ex)
            {
                _logger.LogError("Process is Stoped for this url {0},Message: {1}", ControllerContext.HttpContext.Request.Path, ex.Message);
                return (HttpStatusCode)500;
            }
            return HttpStatusCode.OK;
        }
    }
}
