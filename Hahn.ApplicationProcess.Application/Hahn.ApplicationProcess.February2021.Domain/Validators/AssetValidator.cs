using FluentValidation;
using Hahn.ApplicationProcess.February2021.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hahn.ApplicationProcess.February2021.Domain.Validators
{
    public class AssetValidator : AbstractValidator<AssetDTO>
    {
        public AssetValidator()
        {
            RuleFor(a => a.AssetName).MinimumLength(5);
            RuleFor(a => a.Department).Must(BeADepartment).WithMessage("Please set an valid index of enum members in depratment of asset");
            RuleFor(a => a.broken);//to do after found that provided in this task has wich biz rule
            RuleFor(a => a.EMailAdressOfDepartment).Matches(".+@.+");
            RuleFor(a => a.PurchaseDate).GreaterThan(DateTime.UtcNow.AddYears(-1));
            RuleFor(a => a.CountryOfDepartment).Must(BeAValidCountry).WithMessage("Please specify a valid country that exists in https://restcountries.eu/rest/v2/ url.");
        }
        private bool BeAValidCountry(string countryName)
        {
            // custom contry validating logic goes here by this rest url
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync("https://restcountries.eu/rest/v2/").Result;
            if (response.IsSuccessStatusCode)
            {

                var result = response.Content.ReadAsStringAsync();
                bool isValid = result.Result.ToLower().Contains("{\"name\":\"" + countryName.ToLower());
                return isValid;
            }
            return false;
        }

        private bool BeADepartment(int departmentCode)
        {

            if (Enum.IsDefined(typeof(Departments), departmentCode))
            {
                return true;
            }
            return false;
        }

    }
}
