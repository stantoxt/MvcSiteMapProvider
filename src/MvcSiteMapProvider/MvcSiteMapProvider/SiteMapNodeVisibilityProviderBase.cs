﻿using System;
using System.Collections.Generic;

namespace MvcSiteMapProvider
{
    /// <summary>
    /// Base class to make it easier to implement a custom visibility provider.
    /// </summary>
    public abstract class SiteMapNodeVisibilityProviderBase
        : ISiteMapNodeVisibilityProvider
    {
        #region ISiteMapNodeVisibilityProvider Members

        /// <summary>
        /// Determines whether the node is visible. Override this member to provide alternate implementations of VisibilityProvider.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="sourceMetadata">The source meta-data.</param>
        /// <returns>
        /// 	<c>true</c> if the specified node is visible; otherwise, <c>false</c>.
        /// </returns>
        public abstract bool IsVisible(ISiteMapNode node, IDictionary<string, object> sourceMetadata);

        /// <summary>
        /// Determines whether the provider instance matches the name
        /// </summary>
        /// <param name="providerName">The name of the visibility provider. This can be any string, but for backward compatibility the type name is used.</param>
        /// <returns>
        /// <c>true</c> if the provider name matches; otherwise <c>false</c>.
        /// </returns>
        public virtual bool AppliesTo(string providerName)
        {
            if (string.IsNullOrEmpty(providerName))
                return false;

            return this.GetType().Equals(Type.GetType(providerName, false));
        }

        #endregion
    }
}
