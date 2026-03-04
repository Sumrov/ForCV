using System.Net.Http;
using System.Threading.Tasks;

#nullable enable

namespace EslOnline.SharedKernel.Application.Interfaces;

public interface IHttpClient
{
    Task<(byte[] Data, int StatusCode)> SendAsync(string url, HttpMethod method, object? payload = null);
}
