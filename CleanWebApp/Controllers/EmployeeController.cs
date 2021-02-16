using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CleanWebApp.Models;
using CA.Application.UseCases.SearchEmployee;
using CA.WebApp.ViewModels;
using CA.Domain.EmployeeTypes;
using AutoMapper;
using CA.Application.UseCases.GetEmployee;
using CA.Application.UseCases.GetEmployeeTypes;
using CA.Application.UseCases.AddEmployee;
using CA.Application.UseCases.EditEmployee;
using CA.Domain.Employees;
using CA.Domain.Helpers;

namespace CleanWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly ISearchEmployeesUseCase _searchEmployeesUseCase;
        private readonly IMapper _mapper;
        private readonly IGetEmployeeUseCase _getEmployeeUseCase;
        private readonly IGetEmployeeTypesUseCase _getEmployeeTypesUseCase;
        private readonly IAddEmployeeUseCase _addEmployeeUseCase;
        private readonly IEditEmployeeUseCase _editEmployeeUseCase;

        public EmployeeController(ILogger<EmployeeController> logger,
                                  IMapper mapper,
                                  ISearchEmployeesUseCase searchEmployeesUseCase,
                                  IGetEmployeeUseCase getEmployeeUseCase,
                                  IGetEmployeeTypesUseCase getEmployeeTypesUseCase,
                                  IAddEmployeeUseCase addEmployeeUseCase,
                                  IEditEmployeeUseCase editEmployeeUseCase)
        {
            _logger = logger;
            _mapper = mapper;
            _searchEmployeesUseCase = searchEmployeesUseCase;
            _getEmployeeUseCase = getEmployeeUseCase;
            _getEmployeeTypesUseCase = getEmployeeTypesUseCase;
            _addEmployeeUseCase = addEmployeeUseCase;
            _editEmployeeUseCase = editEmployeeUseCase;
            
        }

        public async Task<IActionResult> Index(SearchInputViewModel input)
        {
            var result = await _searchEmployeesUseCase.Execute(new SearchEmployeesInput() { Name = input.Name });
            var searchEmployee = new SearchEmployeeViewModel()
            {
                input = input,
                output = result
            };
            return View(searchEmployee);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var model = new EmployeeAddViewModel();
            var employeeTypes = await _getEmployeeTypesUseCase.Execute();
            model.EmployeeTypeList = GenerateEmployeeTypeList(employeeTypes);
            model.Item = new EmployeeViewModel();
            model.Item.Id = 0;
            model.Item.BirthDate = DateTime.Now;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeAddViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var employee =  Employee.Create(viewModel.Item.Name,
                                                viewModel.Item.BirthDate,
                                                viewModel.Item.TIN,
                                                viewModel.Item.EmployeeTypeId); 
                var result = await _addEmployeeUseCase.Execute(employee);
                if (result.Status.Equals(CommandStatus.Success))
                {
                    return Ok();
                }
                else
                {
                    viewModel.ErrorMessage = result.ErrorMessage;
                    return StatusCode(400);
                }
            }
            else
            {
                return StatusCode(400);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var model = new EmployeeUpdateViewModel();
            model.Item = new EmployeeViewModel();
            var employee = await _getEmployeeUseCase.Execute(id);
            if (employee == null)
            {
                return NotFound();
            }
            var employeeTypes = await _getEmployeeTypesUseCase.Execute();
            model.EmployeeTypeList = GenerateEmployeeTypeList(employeeTypes);
            model.Item = _mapper.Map<EmployeeViewModel>(employee);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(EmployeeUpdateViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var employee = Employee.Update(viewModel.Item.Id,
                                               viewModel.Item.Name,
                                               viewModel.Item.BirthDate,
                                               viewModel.Item.TIN,
                                               viewModel.Item.EmployeeTypeId);
                var result = await _editEmployeeUseCase.Execute(employee);
                if (result.Status.Equals(CommandStatus.Success))
                {
                    return Ok();
                }
                else
                {
                    viewModel.ErrorMessage = result.ErrorMessage;
                    return StatusCode(400);
                }
            }
            else
            {
                return StatusCode(400);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Payroll(int id)
        {
            var model = new EmployeePayrollViewModel();
            var employee = await _getEmployeeUseCase.Execute(id);
            if (employee == null)
            {
                return NotFound();
            }
           
            model.employee = employee;
            model.Id = employee.Id;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Payroll(EmployeePayrollViewModel viewModel)
        {
            var model = new EmployeePayrollViewModel();
            var employee = await _getEmployeeUseCase.Execute(viewModel.Id);
            if (employee == null)
            {
                return NotFound();
            }

            model.employee = employee;
            model.Id = employee.Id;
            model.SalaryAmount = employee.CalculatePayrol(viewModel.Absent, viewModel.WorkingDays);
            return View(model);
        }


        private List<dynamic> GenerateEmployeeTypeList(List<EmployeeType> employeeTypes)
        {
            var resultList = new List<dynamic>();
            resultList.Add(new { Text = "Select One", Value = string.Empty });
            foreach (var item in employeeTypes)
            {
                resultList.Add(new { Text = item.Description, Value = item.Id });

            }
            return resultList;
        }
    }
}
