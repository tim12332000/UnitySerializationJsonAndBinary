using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class BytesMapper
{
	private static BinaryFormatter _bf;

	public static BinaryFormatter UnityBinaryFormatter
	{
		get
		{
			if (_bf == null)
			{
				_bf = new BinaryFormatter();

				SurrogateSelector surrogateSelector = new SurrogateSelector();
				Vector2SerializationSurrogate vector2SS = new Vector2SerializationSurrogate();
				Vector3SerializationSurrogate vector3SS = new Vector3SerializationSurrogate();
				surrogateSelector.AddSurrogate(typeof(Vector2), new StreamingContext(StreamingContextStates.All), vector2SS);
				surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), vector3SS);
				_bf.SurrogateSelector = surrogateSelector;
			}
			return _bf;
		}
	}

	public static byte[] ToBytes<T>(T obj)
	{
		if (obj == null)
			return null;

		try
		{
			using (MemoryStream ms = new MemoryStream())
			{
				UnityBinaryFormatter.Serialize(ms, obj);
				return ms.ToArray();
			}
		}
		catch (Exception e)
		{
			Debug.LogErrorFormat("[BytesMapper][ToBytes] get e : {0}", e.Message);
			return null;
		}
	}

	public static T ToObject<T>(byte[] data)
	{
		if (data == null)
			return default(T);

		try
		{
			using (MemoryStream ms = new MemoryStream(data))
			{
				object obj = UnityBinaryFormatter.Deserialize(ms);
				return (T)obj;
			}
		}
		catch (Exception e)
		{
			Debug.LogErrorFormat("[BytesMapper][ToObject] get e : {0}", e.Message);
			return default(T);
		}
	}
}
