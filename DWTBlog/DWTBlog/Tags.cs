using System;
using System.Collections.Generic;
using uComponents.Core.uQueryExtensions;
using umbraco.MacroEngines;
using System.Linq;

namespace DWTBlog
{
    public class Tags
    {
        public static string TestCheck()
        {
            return "Message from Method";
        }

        /// <summary>
        /// Returns string of tag and number to represent font strength
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static string ReturnTagsString(IEnumerable<umbraco.presentation.nodeFactory.Node> nodes, string baseNodeUrl)
        {
            var tags = new List<String>();

            foreach (var node in nodes)
            {
                if (node.HasProperty("tags"))
                {
                    var tagsList = node.GetProperty("tags").Value.Split(',');

                    foreach (var tag in tagsList)
                    {
                        tags.Add(tag);
                    }
                }
            }

            tags.Sort((x, y) => string.Compare(x, y));

            var tagsAlreadyUsed = "";
            var tagsTalliedAndScored = new List<String[]>();

            var totalCountOfTags = 0;

            // Sort and Score all Tags
            foreach (var tag in tags)
            {
                if (!tagsAlreadyUsed.Contains(tag))
                {
                    tagsAlreadyUsed += tag;
                    var tag1 = tag;
                    var numberOfThisTag = tags.Count(tagCounter => tagCounter == tag1);
                    totalCountOfTags += numberOfThisTag;
                    tagsTalliedAndScored.Add(new String[] { numberOfThisTag.ToString(), tag.Trim() });
                }
            }

            var tagCloudHtml = new List<String>();

            for (var i = 0; i < tagsTalliedAndScored.Count; i++)
            {
                double tagPercentage = Convert.ToDouble(tagsTalliedAndScored[i][0]) / totalCountOfTags;
                var hrefStringBase = "<a href=\"{0}?tag={1}\">{1}</a>";

                if (tagPercentage > .2)
                {
                    var href = String.Format(hrefStringBase, baseNodeUrl, tagsTalliedAndScored[i][1]);
                    tagCloudHtml.Add(String.Format("<span class=\"{0}\">{1}</span>", "Strength1", href));
                }
                else if (tagPercentage > .15)
                {
                    var href = String.Format(hrefStringBase, baseNodeUrl, tagsTalliedAndScored[i][1]);
                    tagCloudHtml.Add(String.Format("<span class=\"{0}\">{1}</span>", "Strength2", href));
                }
                else if (tagPercentage > .1)
                {
                    var href = String.Format(hrefStringBase, baseNodeUrl, tagsTalliedAndScored[i][1]);
                    tagCloudHtml.Add(String.Format("<span class=\"{0}\">{1}</span>", "Strength3", href));
                }
                else if (tagPercentage > .05)
                {
                    var href = String.Format(hrefStringBase, baseNodeUrl, tagsTalliedAndScored[i][1]);
                    tagCloudHtml.Add(String.Format("<span class=\"{0}\">{1}</span>", "Strength4", href));
                }
                else
                {
                    var href = String.Format(hrefStringBase, baseNodeUrl, tagsTalliedAndScored[i][1]);
                    tagCloudHtml.Add(String.Format("<span class=\"{0}\">{1}</span>", "Strength5", href));
                }
            }

            var tagsHtmlString = tagCloudHtml.Aggregate("<div class=\"TagCloud\">", (current, r) => current + r);
            tagsHtmlString += "</div>";
            return tagsHtmlString;
        }

        /// <summary>
        /// Returns string of tag and number to represent font strength
        /// </summary>
        /// <param name="nodes"></param>
        /// <returns></returns>
        public static string ReturnTagsString(DynamicNodeList nodes, string baseNodeUrl)
        {
            var tags = new List<String>();

            foreach (dynamic node in nodes)
            {
                if (node.HasProperty("Tags") && !String.IsNullOrEmpty(node.Tags))
                {
                    var tagsList = node.Tags.ToString().Split(',');

                    foreach (var tag in tagsList)
                    {
                        tags.Add(tag);
                    }
                }
            }

            tags.Sort((x, y) => string.Compare(x, y));

            var tagsAlreadyUsed = "";
            var tagsTalliedAndScored = new List<String[]>();

            var totalCountOfTags = 0;

            // Sort and Score all Tags
            foreach (var tag in tags)
            {
                if (!tagsAlreadyUsed.Contains(tag))
                {
                    tagsAlreadyUsed += tag;
                    var tag1 = tag;
                    var numberOfThisTag = tags.Count(tagCounter => tagCounter == tag1);
                    totalCountOfTags += numberOfThisTag;
                    tagsTalliedAndScored.Add(new String[] { numberOfThisTag.ToString(), tag.Trim() });
                }
            }

            var tagCloudHtml = new List<String>();

            for (var i = 0; i < tagsTalliedAndScored.Count; i++)
            {
                double tagPercentage = Convert.ToDouble(tagsTalliedAndScored[i][0]) / totalCountOfTags;
                var hrefStringBase = "<a href=\"{0}?tag={1}\">{1}</a>";

                if (tagPercentage > .2)
                {
                    var href = String.Format(hrefStringBase, baseNodeUrl, tagsTalliedAndScored[i][1]);
                    tagCloudHtml.Add(String.Format("<span class=\"{0}\">{1}</span>", "Strength1", href));
                }
                else if (tagPercentage > .15)
                {
                    var href = String.Format(hrefStringBase, baseNodeUrl, tagsTalliedAndScored[i][1]);
                    tagCloudHtml.Add(String.Format("<span class=\"{0}\">{1}</span>", "Strength2", href));
                }
                else if (tagPercentage > .1)
                {
                    var href = String.Format(hrefStringBase, baseNodeUrl, tagsTalliedAndScored[i][1]);
                    tagCloudHtml.Add(String.Format("<span class=\"{0}\">{1}</span>", "Strength3", href));
                }
                else if (tagPercentage > .05)
                {
                    var href = String.Format(hrefStringBase, baseNodeUrl, tagsTalliedAndScored[i][1]);
                    tagCloudHtml.Add(String.Format("<span class=\"{0}\">{1}</span>", "Strength4", href));
                }
                else
                {
                    var href = String.Format(hrefStringBase, baseNodeUrl, tagsTalliedAndScored[i][1]);
                    tagCloudHtml.Add(String.Format("<span class=\"{0}\">{1}</span>", "Strength5", href));
                }
            }

            var tagsHtmlString = tagCloudHtml.Aggregate("<div class=\"TagCloud\">", (current, r) => current + r);
            tagsHtmlString += "</div>";
            return tagsHtmlString;
        }

        public static DynamicNodeList GetNodesByTag(DynamicNodeList nodes, string tagSearch)
        {
            var nodeList = new DynamicNodeList();

            foreach (dynamic node in nodes)
            {
                if (node.HasProperty("Tags") && !String.IsNullOrEmpty(node.Tags))
                {
                    var tagsList = node.Tags.ToString().Split(',');

                    foreach (var tag in tagsList)
                    {
                        if (tag.Trim().ToLower() == tagSearch.Trim().ToLower())
                            nodeList.Add(node);
                    }
                }
            }

            return nodeList;
        }
    }
}