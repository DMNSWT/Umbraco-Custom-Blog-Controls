using System.Collections.Generic;
using umbraco.MacroEngines;

namespace DWTBlog
{
    public class Authors
    {
        public static int NumberOfBlogsByCreator(DynamicNodeList nodes, string name)
        {
            var nodeList = new DynamicNodeList();

            foreach (DynamicNode dynamicNode in nodes)
            {
                if (dynamicNode.CreatorName == name)
                {
                    nodeList.Add(dynamicNode);
                }
            }

            return nodeList.Items.Count;
        }

        public static int NumberOfBlogsByCreator(IEnumerable<umbraco.presentation.nodeFactory.Node> nodes, string name)
        {
            var nodeList = new List<umbraco.presentation.nodeFactory.Node>();

            foreach (var node in nodes)
            {
                if (node.CreatorName == name)
                {
                    nodeList.Add(node);
                }
            }

            return nodeList.Count;
        }
    }
}