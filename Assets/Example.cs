using EasyButtons;
using LitJson;
using System;
using System.IO;
using UnityEngine;

[Serializable]
public class Test
{
	public Vector3 Vec3 = new Vector3(1f, 2f, 3f);
	public Vector2 Vec2 = new Vector2(4f, 5f);
}

public class Example : MonoBehaviour
{
	[Button]
	public void DataToJson()
	{
		string path = Path.Combine(Application.dataPath, "Test.json");
		string json = JsonMapper.ToPrettyJson(new Test());
		File.WriteAllText(path, json);
	}

	[Button]
	public void JsonToData()
	{
		string path = Path.Combine(Application.dataPath, "Test.json");
		string json = File.ReadAllText(path);
		Test test = JsonMapper.ToObject<Test>(json);
		Debug.LogFormat("vec2{0} vec3 {1}", test.Vec2, test.Vec3);
	}

	[Button]
	public void DataToBytes()
	{
		string path = Path.Combine(Application.dataPath, "Test.bytes");
		byte[] b = BytesMapper.ToBytes<Test>(new Test());
		File.WriteAllBytes(path, b);
	}

	[Button]
	public void BytesToData()
	{
		string path = Path.Combine(Application.dataPath, "Test.bytes");
		byte[] b = File.ReadAllBytes(path);
		Test test = BytesMapper.ToObject<Test>(b);
		Debug.LogFormat("vec2{0} vec3 {1}", test.Vec2, test.Vec3);
	}
}
