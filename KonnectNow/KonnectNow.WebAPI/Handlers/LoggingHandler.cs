using KonnectNow.Common.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace KonnectNow.WebAPI.Handlers
{
    /// <summary>
    /// Handles  all exceptions and trace logging.
    /// </summary>
    public class LoggingHandler : DelegatingHandler
    {
        /// <summary>
        /// Logs the request persist information
        /// </summary>
        /// <param name="request">request object</param>
        /// <param name="cancellationToken">cancel token object</param>
        /// <returns>HttpResponseMessag object</returns>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Log the request information
            LogRequestLoggingInfo(request);

            // Execute the request
            return base.SendAsync(request, cancellationToken).ContinueWith(task =>
            {
                var response = task.Result;
                // Extract the response logging info then persist the information
                LogResponseLoggingInfo(response);
                return response;
            });
        }

        /// <summary>
        /// Logs the request  information.
        /// </summary>
        /// <param name="request">HttpRequestMessage object</param>
        private void LogRequestLoggingInfo(HttpRequestMessage request)
        {
            if (Logger.Instance.IsDebugEnabled)
            {
                if (request.Content != null)
                {
                    request.Content.ReadAsByteArrayAsync()
                        .ContinueWith(task =>
                        {
                            var token = request.Headers.Contains("AccessToken") ? ((string[])(request.Headers.GetValues("AccessToken")))[0] : string.Empty;
                            var result = Encoding.UTF8.GetString(task.Result);
                            Logger.Instance.Log(string.Format("Message :Entered with Request: {0} || Method : {1} ||  Request Body: {2} || Token : {3}"
                                                              , request.RequestUri.AbsolutePath
                                                              , request.Method
                                                              , result
                                                              , token)
                                                , LogLevel.Debug);
                        }).Wait();
                }
            }
        }

        /// <summary>
        /// Logs the response  information
        /// </summary>
        /// <param name="response">HttpRequestMessage object</param>
        private void LogResponseLoggingInfo(HttpResponseMessage response)
        {
            if (Logger.Instance.IsDebugEnabled)
            {
                var token = response.RequestMessage.Headers.Contains("AccessToken") ? ((string[])(response.RequestMessage.Headers.GetValues("AccessToken")))[0] : string.Empty;
                if (response.Content != null)
                {
                    response.Content.ReadAsByteArrayAsync()
                        .ContinueWith(task =>
                        {
                            var responseMsg = Encoding.UTF8.GetString(task.Result);
                            Logger.Instance.Log(string.Format("Message :Exited from Request: {0} || Method : {1} ||  Response Body: {2} || Token : {3}"
                                                             , response.RequestMessage.RequestUri.AbsolutePath
                                                             , response.RequestMessage.Method
                                                             , responseMsg
                                                             , token)
                                                             , LogLevel.Debug);
                        });
                }
                else
                {
                    Logger.Instance.Log(string.Format("Message :Exited from Request: {0} || Method : {1} ||  Response Body: {2} || Token : {3}"
                                                      , response.RequestMessage.RequestUri.AbsolutePath
                                                      , response.RequestMessage.Method
                                                      , response.StatusCode
                                                      , token)
                                                      , LogLevel.Debug);
                }
            }
        }
    }
}