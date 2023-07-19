
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Bogus.DataSets;

namespace Allegory.Module.PlugInRandomNames
{
    [Route("api/plug-in/random-name")]
    public class RandomNameController : AbpControllerBase
    {
        public RandomNameController()
        {
            
        }

        [HttpGet]
        public async Task<List<string>> GetAsync()
        {
            List<string> names = new List<string>();
            var faker = new Name();

            for (int i = 0; i < 100; i++)
            {
                names.Add(faker.FirstName());
            }

            return await Task.FromResult(names);
        }
    }
}
