﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using RichardSzalay.MockHttp.Matchers;

namespace RichardSzalay.MockHttp
{
    /// <summary>
    /// Provides extension methods for <see cref="T:MockHttpMessageHandler"/>
    /// </summary>
    public static class MockHttpMessageHandlerExtensions
    {
        /// <summary>
        /// Adds a backend definition 
        /// </summary>
        /// <param name="handler">The source handler</param>
        /// <param name="method">The HTTP method to match</param>
        /// <param name="url">The URL (absolute or relative, may contain * wildcards) to match</param>
        /// <returns>The <see cref="T:MockedRequest"/> instance</returns>
        public static MockedRequest When(this MockHttpMessageHandler handler, HttpMethod method, string url)
        {
            var message = new MockedRequest(url, handler);
            message.With(new MethodMatcher(method));

            handler.AddBackendDefinition(message);

            return message;
        }

        /// <summary>
        /// Adds a backend definition 
        /// </summary>
        /// <param name="handler">The source handler</param>
        /// <param name="url">The URL (absolute or relative, may contain * wildcards) to match</param>
        /// <returns>The <see cref="T:MockedRequest"/> instance</returns>
        public static MockedRequest When(this MockHttpMessageHandler handler, string url)
        {
            var message = new MockedRequest(url, handler);

            handler.AddBackendDefinition(message);

            return message;
        }

        /// <summary>
        /// Adds a request expectation
        /// </summary>
        /// <param name="handler">The source handler</param>
        /// <param name="method">The HTTP method to match</param>
        /// <param name="url">The URL (absolute or relative, may contain * wildcards) to match</param>
        /// <returns>The <see cref="T:MockedRequest"/> instance</returns>
        public static MockedRequest Expect(this MockHttpMessageHandler handler, HttpMethod method, string url)
        {
            var message = new MockedRequest(url, handler);
            message.With(new MethodMatcher(method));

            handler.AddRequestExpectation(message);

            return message;
        }

        /// <summary>
        /// Adds a request expectation
        /// </summary>
        /// <param name="handler">The source handler</param>
        /// <param name="url">The URL (absolute or relative, may contain * wildcards) to match</param>
        /// <returns>The <see cref="T:MockedRequest"/> instance</returns>
        public static MockedRequest Expect(this MockHttpMessageHandler handler, string url)
        {
            var message = new MockedRequest(url, handler);

            handler.AddRequestExpectation(message);

            return message;
        }

        /// <summary>
        /// Creates an HttpClient instance from the current MockHttpMessageHandler
        /// </summary>
        /// <param name="handler">The source handler</param>
        /// <returns>An HttpClient that can be used to make requests using the mock configuration</returns>
        public static HttpClient AsHttpClient(this MockHttpMessageHandler handler)
        {
            return new HttpClient(handler);
        }
    }
}