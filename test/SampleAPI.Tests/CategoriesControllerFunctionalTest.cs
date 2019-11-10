using Newtonsoft.Json;
using SampleAPI.Commands;
using SampleAPI.Domain;
using SampleAPI.Infrastructure;
using SampleAPI.Tests.Common;
using SampleAPI.Tests.Util;
using SampleAPI.ViewModels;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace SampleAPI.Tests
{
    public class CategoriesControllerFunctionalTest : WebTest
    {
        [Fact]
        public async Task Create_ReturnsCategory()
        {
            // Prepare
            var createCategoryCommand = new CreateCategoryCommand
            {
                Name="Prueba unitaria",
                Description="prueba de ejemplo"
            };

            // Execute
            var responseCreate = await _client.PostAsJsonAsync(Endpoints.CATEGORIES, createCategoryCommand);
            var contentCreate = await responseCreate.Content.ReadAsStringAsync();

            // Check
            var expectedBasicCategory = new BasicCategoryViewModel
            {
               Name=createCategoryCommand.Name,
               Description=createCategoryCommand.Description,
               IsActive=true
            };
            Assert.Equal(HttpStatusCode.Created, responseCreate.StatusCode);
            Assert.Equal(expectedBasicCategory.Serialize(), contentCreate);

        }
    }
}
