using Excel.Application.Application.Contracts;
using Excel.Application.Application.Implements;
using Excel.Application.Strategy;
using Excel.Application.Strategy.Contracts;
using Excel.Application.Strategy.Handler;
using Excel.Domain.Contracts;
using Excel.Infrastructure.Repositories;
using Excel.Infrastructure.Service.Implementation;
using Excel.Infrastructure.Service.Interface;
using Excel.WebApi.Common;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace Excel.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IOperationRepository, OperationRepository>();
            container.RegisterType<IOperationInfrastructureService, OperationInfrastructureService>();
            container.RegisterType<IWorksheetInfrastructureService, WorksheetInfrastructureService>();
            container.RegisterType<ICsvInfrastructureService, CsvInfrastructureService>();
            container.RegisterType<IFileStrategyHandler, FileStrategyHandler>();
            container.RegisterType<IOperationGroupByAccountStrategy, OperationGroupByAccountStrategy>();
            container.RegisterType<IOperationGroupByAssetStrategy, OperationGroupByAssetStrategy>();
            container.RegisterType<IOperationGroupByTypeStrategy, OperationGroupByTypeStrategy>();
            container.RegisterType<IFileExcelStrategy, FileExcelStrategy>();            
            container.RegisterType<IFileCsvStrategy, FileCsvStrategy>();
            container.RegisterType<IOperationStrategyHandler, OperationStrategyHandler>();
            container.RegisterType<IOperationAppService, OperationAppService>();
            container.RegisterType<ILog, Log>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}