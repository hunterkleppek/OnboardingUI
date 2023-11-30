using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace OnboardingUI.Test.DomainTestCases
{
    public class SoftwareTestCases
    {
        private Mock<HttpMessageHandler> _mockHandler;
        private HttpClient _client;
        private string _url = "https://localhost:7229/api/ScriptGenerator/GetListOfSoftware";

        [SetUp]
        public void Setup()
        {
            _mockHandler = new Mock<HttpMessageHandler>();
            _client = new HttpClient(_mockHandler.Object);
        }

        [Test]
        public async Task TestEndpointHealth()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _url);
            _mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("[]") });
            var response = await _client.SendAsync(request);
            Assert.That(response.IsSuccessStatusCode, Is.True);
        }

        [Test]
        public async Task TestGetListOfSoftwareReturnsEmptyList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _url);
            _mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.OK, Content = new StringContent("[]") });
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content, Is.EqualTo("[]"));
        }

        [Test]
        public async Task TestGetListOfSoftwareReturnsNonEmptyList()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _url);
            _mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(),
                                       ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(
                                               "[{\"softwareId\":1,\"softwareName\":\"Software 1\"},{\"softwareId\":2,\"softwareName\":\"Software 2\"},{\"softwareId\":3,\"softwareName\":\"Software 3\"},{\"softwareId\":4,\"softwareName\":\"Software 4\"},{\"softwareId\":5,\"softwareName\":\"Software 5\"},{\"softwareId\":6,\"softwareName\":\"Software 6\"},{\"softwareId\":7,\"softwareName\":\"Software 7\"},{\"softwareId\":8,\"softwareName\":\"Software 8\"},{\"softwareId\":9,\"softwareName\":\"Software 9\"}]")
                });
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(content, Is.EqualTo("[{\"softwareId\":1,\"softwareName\":\"Software 1\"},{\"softwareId\":2,\"softwareName\":\"Software 2\"},{\"softwareId\":3,\"softwareName\":\"Software 3\"},{\"softwareId\":4,\"softwareName\":\"Software 4\"},{\"softwareId\":5,\"softwareName\":\"Software 5\"},{\"softwareId\":6,\"softwareName\":\"Software 6\"},{\"softwareId\":7,\"softwareName\":\"Software 7\"},{\"softwareId\":8,\"softwareName\":\"Software 8\"},{\"softwareId\":9,\"softwareName\":\"Software 9\"}]"));
        }

        [Test]
        public async Task TestGetListOfSoftwareReturnsServerError()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _url);
            _mockHandler.Protected()
                .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                .ReturnsAsync(new HttpResponseMessage { StatusCode = HttpStatusCode.InternalServerError });
            var response = await _client.SendAsync(request);
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.InternalServerError));
        }

    }
}
