using System;
using System.Collections.Generic;
using System.Linq;
using umbraco.MacroEngines;
using uComponents.Core.uQueryExtensions;

namespace DWTBlog
{
    public class ListOfPosts
    {
        public static void Test(IEnumerable<umbraco.presentation.nodeFactory.Node> nodes)
        {

        }

        public static IEnumerable<umbraco.presentation.nodeFactory.Node> GetListOfNodes(IEnumerable<umbraco.presentation.nodeFactory.Node> nodes, string category)
        {
            var myNodeList = new List<umbraco.presentation.nodeFactory.Node>();

            foreach (var node in nodes)
            {
                var myCategories = node.GetProperty("dwtBlogCategories").Value;

                if (!String.IsNullOrWhiteSpace(myCategories))
                {
                    var myCategoryList = new List<string>(myCategories.Split(','));

                    if (myCategoryList.Any(x => x == category))
                    {
                        myNodeList.Add(node);
                    }
                }
            }

            return myNodeList;
        }

        public static DynamicNodeList GetNodes(DynamicNodeList nodes, string category)
        {
            var myNodeList = new DynamicNodeList();

            foreach (dynamic dynamicNode in nodes)
            {
                var myCategories = dynamicNode.GetProperty("dwtBlogCategories").Value.ToString();

                if (!String.IsNullOrWhiteSpace(myCategories))
                {
                    var myCategoryList = new List<string>(myCategories.Split(','));

                    if (myCategoryList.Any(x => x == category))
                    {
                        myNodeList.Add(dynamicNode);

                    }
                }
            }

            return myNodeList;
        }

        public static string herewego() { return "here"; }

        public static IEnumerable<umbraco.presentation.nodeFactory.Node> GetNodesByMonth(IEnumerable<umbraco.presentation.nodeFactory.Node> nodes, string archiveDate)
        {
            var date = Convert.ToDateTime(archiveDate);
            var nodeList = new List<umbraco.presentation.nodeFactory.Node>();

            foreach (var node in nodes)
            {
                if (node.CreateDate.Month == date.Month && node.CreateDate.Year == date.Year)
                {
                    nodeList.Add(node);
                }
            }

            return nodeList;
        }

        public static DynamicNodeList GetNodesByMonth(DynamicNodeList nodes, string archiveDate)
        {
            var date = Convert.ToDateTime(archiveDate);
            var nodeList = new DynamicNodeList();

            foreach (DynamicNode dynamicNode in nodes)
            {
                if (dynamicNode.CreateDate.Month == date.Month && dynamicNode.CreateDate.Year == date.Year)
                {
                    nodeList.Add(dynamicNode);
                }
            }

            return nodeList;
        }

        public static IEnumerable<umbraco.presentation.nodeFactory.Node> GetNodesByTag(IEnumerable<umbraco.presentation.nodeFactory.Node> nodes, string tagSearch)
        {
            var nodeList = new List<umbraco.presentation.nodeFactory.Node>();

            foreach (var node in nodes)
            {
                if (node.HasProperty("tags"))
                {
                    var tagsList = node.GetProperty("tags").Value.Split(',');

                    foreach (var tag in tagsList)
                    {
                        if (tag.Trim().ToLower() == tagSearch.Trim().ToLower())
                            nodeList.Add(node);
                    }
                }
            }

            return nodeList;
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