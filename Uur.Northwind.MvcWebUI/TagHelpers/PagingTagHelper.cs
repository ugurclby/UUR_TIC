﻿using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uur.Northwind.MvcWebUI.TagHelpers
{
    [HtmlTargetElement("product-list-pager")]
    public class PagingTagHelper:TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            StringBuilder sb = new StringBuilder();

            sb.Append("<ul class ='pagination'>");

            for (int i = 1; i <= PageCount; i++)
            {
                //<li class="page-item"><a class="page-link" href="#">1</a></li>
                sb.AppendFormat("<li class ='{0}'>", i == CurrentPage ? "page-item active" : "page-item");
                sb.AppendFormat("<a class='page-link' href='/product/index?page={0}&categoryId={1}'>{2}</a>", i, CurrentCategory, i);
                sb.Append("</li>");
            }
            //sb.Append("</ul>");
            output.Content.SetHtmlContent(sb.ToString());
            base.Process(context, output);
        }
    }
}
