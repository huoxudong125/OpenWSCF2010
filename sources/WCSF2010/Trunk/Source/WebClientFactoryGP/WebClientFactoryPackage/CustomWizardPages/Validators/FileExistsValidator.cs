//===============================================================================
// Microsoft patterns & practices
// Web Client Software Factory 2010
//===============================================================================
// Copyright (c) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===============================================================================
//===============================================================================
// Microsoft patterns & practices
// Web Client Software Factory
//-------------------------------------------------------------------------------
// Copyright (C) Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//-------------------------------------------------------------------------------
// The example companies, organizations, products, domain names,
// e-mail addresses, logos, people, places, and events depicted
// herein are fictitious.  No association with any real company,
// organization, product, domain name, email address, logo, person,
// places, or events is intended or should be inferred.
//===============================================================================

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Microsoft.Practices.EnterpriseLibrary.Validation.Validators
{
	public class FileExistsValidator : Validator<string>
	{
        public const string DefaultFailureMessage = "File not exists";

        private string _basePath=String.Empty;
        
        public FileExistsValidator() : this(string.Empty)
        {
        }

        public FileExistsValidator(string basePath) : this(basePath,DefaultFailureMessage)
        {
        }

        public FileExistsValidator(string basePath, string errorMessage)
            : base(errorMessage, null)
        {
            _basePath=basePath;
        }

        protected override void DoValidate(string objectToValidate, object currentTarget, string key, ValidationResults validationResults)
        {
            if (!File.Exists(Path.Combine(_basePath,objectToValidate)))
            {
                this.LogValidationResult(validationResults, this.MessageTemplate, currentTarget, key);
            }
        }

        protected override string DefaultMessageTemplate
        {
            get { return DefaultFailureMessage; }
        }
	}
}
