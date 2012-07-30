using System;
using System.Collections.Generic;
using System.Linq;
using umbraco.MacroEngines;

namespace DWTBlog
{
    public class Archive
    {
        public static int NumberOfMonthsArchive(IEnumerable<umbraco.presentation.nodeFactory.Node> nodes)
        {
            var monthsDifference = (DateTime.Now.Year * 12 + DateTime.Now.Month) - (nodes.LastOrDefault().CreateDate.Year * 12 + nodes.LastOrDefault().CreateDate.Month);
            return monthsDifference;
        }

        public static int NumberOfMonthsArchive(DynamicNodeList nodes)
        {
            var monthsDifference = (DateTime.Now.Year * 12 + DateTime.Now.Month) - (nodes.Items.LastOrDefault().CreateDate.Year * 12 + nodes.Items.LastOrDefault().CreateDate.Month);
            return monthsDifference;
        }

        public static int NumberOfBlogsInMonth(IEnumerable<umbraco.presentation.nodeFactory.Node> nodes, string archiveDate)
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

            return nodeList.Count();
        }

        public static int NumberOfBlogsInMonth(DynamicNodeList nodes, string archiveDate)
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

            return nodeList.Items.Count;
        }
    }
}