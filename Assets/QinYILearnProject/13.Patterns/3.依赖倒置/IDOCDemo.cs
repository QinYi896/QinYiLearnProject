using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface ITransportData
{
	void TransPortData();
}

public interface IUSB : ITransportData
{
	string TypenName { get; set; }
}

public interface ISATA : ITransportData
{
	string TypenName { get; set; }
}

public class UFlashDisk : IUSB
{
	public string TypenName { get; set; }
	public UFlashDisk(string typeName)
	{
		TypenName = typeName;
	}
	public void TransPortData()
	{
		UnityEngine.Debug.Log(string.Format("优盘型号:{0}传输数据", TypenName));
	}
}

public class HardDisk : ISATA
{
	public string TypenName { get; set; }

	public HardDisk(string typeName)
	{
		TypenName = typeName;
	}

	public void TransPortData()
	{
		UnityEngine.Debug.Log(string.Format("硬盘型号:{0}传输数据", TypenName));
	}
}

public class Computer
{
	ISATA m_HardDisk;

	public void SetHardWare(ISATA hardDisk)
	{
		m_HardDisk = hardDisk;
	}

	public void ReadData()
	{
		if (m_HardDisk == null)
			throw new Exception();
		m_HardDisk.TransPortData();
	}

	public void UseUFlashDisk(IUSB flashDisk)
	{
		flashDisk.TransPortData();
	}
}
public class IDOCDemo : MonoBehaviour
{
	void Start()
	{
		ISATA hardDisk = new HardDisk("西部数据硬盘");
		IUSB uFlashDisk = new UFlashDisk("闪迪优盘");
		var pc = new Computer();
		pc.SetHardWare(hardDisk);
		pc.ReadData();
		pc.UseUFlashDisk(uFlashDisk);
		pc.UseUFlashDisk(new UFlashDisk("西门子优盘"));
	}
}
