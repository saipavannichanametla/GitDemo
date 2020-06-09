using System;
using System.Collections.Generic;

namespace GitDemo
{
    class Program
    {
        const string _menuData = "marketing-,r&d-, supply chain-, products-marketing, planning-marketing, component-r&d, software-r&d, hardware-r&d, scm operations-supply chain, monitors-products, hp-monitors, dell-monitors, hp G3-hp, features-planning, amo-planning, prl-planning, find component-component, find irs component-component, features without roots-component,product explorer-software, scmx editor-software, software refresh-software,system rom component-hardware,lifecycle data management-scm operations, reports-, pulsar marketing-reports, amo matrix report-pulsar marketing, channel partner product configuration-pulsar marketing, channel partner usage-pulsar marketing, pulsar r&d-reports, Com. software erd-pulsar r&d, featurebyte decoder-pulsar r&d, hardware qual matrix-pulsar r&d, pulsar supply chain-reports, av action score card-pulsar supply chain, av product offering report-pulsar supply chain";

        static void Main(string[] args)
        {
            List<string> leafNames = GetLeafNames("r&d");

            Console.WriteLine($"Leaf names = {string.Join(", ", leafNames)}");

            Console.ReadLine();
        }

        static List<string> GetLeafNames(string nodeName)
        {
            List<string> finalLeafNames = new List<string>();
            List<string> tempList = new List<string>();
            List<string> childNodes = Process(nodeName);
            do
            {
                for (int i = 0; i < childNodes.Count; i++)
                {
                    var trimedName = childNodes[i].TrimStart();
                    List<string> leafeName = Process(trimedName);
                    if (leafeName.Count > 0)
                    {
                        foreach (string output in leafeName)
                        {
                            tempList.Add(output);
                        }
                        tempList.Remove(childNodes[i]);
                    }
                    if (leafeName.Count == 0)
                    {
                        tempList.Remove(childNodes[i]);
                        finalLeafNames.Add(trimedName);
                    }
                }
                childNodes.Clear();
                foreach (string name in tempList)
                {
                    childNodes.Add(name);
                }
            } while (childNodes.Count > 0);
            return finalLeafNames;
        }

        static List<string> Process(string nodeName)
        {
            var childs = new List<string>();

            string[] values = _menuData.Split(',');
            foreach (string value in values)
            {
                string[] name = value.Split('-');
                if (name[1] == nodeName)
                {
                    childs.Add(name[0]);
                }
            }
            return childs;
        }

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello World!");
        //}
    }
}
