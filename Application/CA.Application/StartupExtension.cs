using CA.Application.UseCases.AddEmployee;
using CA.Application.UseCases.EditEmployee;
using CA.Application.UseCases.GetEmployee;
using CA.Application.UseCases.GetEmployeeTypes;
using CA.Application.UseCases.SearchEmployee;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Application
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ISearchEmployeesUseCase, SearchEmployeesUseCase>();
            services.AddTransient<ISeedDataUseCase, SeedDataUseCase>();
            services.AddTransient<IGetEmployeeTypesUseCase, GetEmployeeTypesUseCase>();
            services.AddTransient<IAddEmployeeUseCase, AddEmployeeUseCase>();
            services.AddTransient<IEditEmployeeUseCase, EditEmployeeUseCase>();
            services.AddTransient<IGetEmployeeUseCase, GetEmployeeUseCase>();
            return services;
        }
    }
}
