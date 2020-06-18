using Excel.Application.Application.Contracts;
using Excel.Application.Mapping.Param;
using Excel.WebApi.Common;
using System.Threading.Tasks;
using System.Web.Http;

namespace Excel.WebApi.Controllers.v1
{
    [RoutePrefix("api/operation")]
    public class OperationController : ApiController
    {
        private readonly IOperationAppService _operationAppService;
        private readonly ILog _log;

        public OperationController(IOperationAppService operationAppService,
            ILog log)
        {
            _log = log;
            _operationAppService = operationAppService;
        }

        [HttpPost]
        [Route("data")]
        public async Task<IHttpActionResult> GenerateData()
        {
            try
            {
                _log.LogInformation($"Inicio Processo - {nameof(GenerateData)}");

                await _operationAppService.GenerateData();

                _log.LogInformation($"Fim Processo - {nameof(GenerateData)}");

                return Ok();
            }
            catch (System.Exception ex)
            {
                _log.LogError($"Fail in {nameof(GenerateData)} - {ex.Message}");
                throw ex;
            }
        }

        [HttpPost]
        [Route("file")]
        public async Task<IHttpActionResult> CreateFile(CreateFileParam param)
        {
            try
            {              
                _log.LogInformation($"Inicio Processo - {nameof(CreateFile)}");

                await _operationAppService.CreateFile(param);

                _log.LogInformation($"Fim Processo - {nameof(CreateFile)}");

                return Ok();
            }
            catch (System.Exception ex)
            {
                _log.LogError($"Fail in {nameof(CreateFile)} - {ex.Message}");
                throw ex;
            }
        }
      
        [HttpPost]
        [Route("")]
        public async Task<IHttpActionResult> GetOperations(GetOperationsParam param)
        {
            try
            {
                _log.LogInformation($"Inicio Processo - {nameof(GetOperations)}");

                var operation = await _operationAppService.GetOperations(param);

                _log.LogInformation($"Fim Processo - {nameof(GetOperations)}");

                return Ok(operation);
            }
            catch (System.Exception ex)
            {
                _log.LogError($"Fail in {nameof(GetOperations)} {param.DisplayType} - {ex.Message}");
                throw ex;
            }
        }
    }
}
