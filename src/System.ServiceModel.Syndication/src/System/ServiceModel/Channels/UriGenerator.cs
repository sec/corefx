﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace System.ServiceModel.Channels
{
    using System.Threading;
    using System.Globalization;
    using Microsoft.ServiceModel;
    using Microsoft.ServiceModel.Syndication.Resources;

    internal class UriGenerator
    {
        private long _id;
        private string _prefix;

        public UriGenerator()
            : this("uuid")
        {
        }

        public UriGenerator(string scheme)
            : this(scheme, ";")
        {
        }

        public UriGenerator(string scheme, string delimiter)
        {
            if (scheme == null)
                throw new ArgumentException("scheme");
            //throw DiagnosticUtility.ExceptionUtility.ThrowHelperError(new ArgumentNullException("scheme"));

            if (scheme.Length == 0)
                throw new ArgumentException(string.Format(SR.UriGeneratorSchemeMustNotBeEmpty, "scheme"));

            _prefix = string.Concat(scheme, ":", Guid.NewGuid().ToString(), delimiter, "id=");
        }

        public string Next()
        {
            long nextId = Interlocked.Increment(ref _id);
            return _prefix + nextId.ToString(CultureInfo.InvariantCulture);
        }
    }
}
