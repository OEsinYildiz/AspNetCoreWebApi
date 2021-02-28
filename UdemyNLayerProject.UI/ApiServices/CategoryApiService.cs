using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UdemyNLayerProject.UI.DTOs;

namespace UdemyNLayerProject.UI.ApiServices
{
    public class CategoryApiService
    {
        private readonly HttpClient _httpClient;

        public CategoryApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ICollection<CategoryDto>> GetAllAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("category");

            response.EnsureSuccessStatusCode();
            string responseStream = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ICollection<CategoryDto>>(responseStream);
        }

        public async Task<CategoryDto> AddAsync(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8,"application/json"); //Todo:Bunu Startup`da yapabilirdik.
            var response = await _httpClient.PostAsync("category", stringContent);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<CategoryDto>( await response.Content.ReadAsStringAsync());
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"category/{id}");
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<CategoryDto>(await response.Content.ReadAsStringAsync());
        }

        public async Task<bool> Update(CategoryDto categoryDto)
        {
            var stringContent = new StringContent(JsonConvert.SerializeObject(categoryDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync("category", stringContent);
            response.EnsureSuccessStatusCode();
            return true;
        }

        public async Task<bool> Remove(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"category/{id}");
            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}