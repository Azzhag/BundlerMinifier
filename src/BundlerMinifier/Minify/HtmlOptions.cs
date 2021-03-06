﻿using WebMarkupMin.Core;
using WebMarkupMin.Core.Settings;

namespace BundlerMinifier
{
    class HtmlOptions
    {
        public static HtmlMinificationSettings GetSettings(Bundle bundle)
        {
            HtmlMinificationSettings settings = new HtmlMinificationSettings();
            settings.RemoveOptionalEndTags = GetValue(bundle, "removeOptionalEndTags") == "True";
            settings.RemoveRedundantAttributes = GetValue(bundle, "removeRedundantAttributes") == "True";

            settings.CollapseBooleanAttributes = GetValue(bundle, "collapseBooleanAttributes") == "True";
            settings.MinifyAngularBindingExpressions = GetValue(bundle, "minifyAngularBindingExpressions") == "True";
            settings.MinifyEmbeddedCssCode = GetValue(bundle, "minifyEmbeddedCssCode") == "True";
            settings.MinifyEmbeddedJsCode= GetValue(bundle, "minifyEmbeddedJsCode") == "True";
            settings.MinifyInlineCssCode = GetValue(bundle, "minifyInlineCssCode") == "True";
            settings.MinifyInlineJsCode = GetValue(bundle, "minifyInlineJsCode") == "True";
            settings.MinifyKnockoutBindingExpressions = GetValue(bundle, "minifyKnockoutBindingExpressions") == "True";
            settings.RemoveHtmlComments = GetValue(bundle, "removeHtmlComments") == "True";
            settings.RemoveTagsWithoutContent = GetValue(bundle, "removeTagsWithoutContent") == "True";

            string quotes = GetValue(bundle, "attributeQuotesRemovalMode");

            if (quotes == "html4")
                settings.AttributeQuotesRemovalMode = HtmlAttributeQuotesRemovalMode.Html4;
            else if (quotes == "html5")
                settings.AttributeQuotesRemovalMode = HtmlAttributeQuotesRemovalMode.Html5;
            else if (quotes == "keepQuotes")
                settings.AttributeQuotesRemovalMode = HtmlAttributeQuotesRemovalMode.KeepQuotes;

            return settings;
        }

        internal static string GetValue(Bundle bundle, string key)
        {
            if (bundle.Minify.ContainsKey(key))
                return bundle.Minify[key].ToString();

            return string.Empty;
        }
    }
}
