using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for OrderedTree
/// </summary>
public class OrderedTree
{
    public string Name { get; set; }
    public int NodeID { get; set; }
    public decimal dNodeID { get; set; }
    public int Depth { get; set; }
    public string Location { get; set; }

	public OrderedTree()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}