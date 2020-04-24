# UnitySerializationJsonAndBinary
Fix Unity Json and Binary Serialization error

對於Unity 序列化 & 反序列化 大致上有的選擇有 Json , Binary , YAML

YAML屬於Unity Prefab 儲存格式沒啥問題先不討論。

Json 我選用 LitJSON

Binary 選用 BinaryFormatter

總之因為這兩個都沒對 Unity 的特定資料結構處理 比如Vector2 Vector3 之類的所以使用上會出現下面的問題

Json 出現的問題 : 

JsonException: Max allowed object depth reached while trying to export from type UnityEngine.Vector2


Binary 出現問題 : 

UnityEngine.Vector2' in Assembly 'UnityEngine.CoreModule, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null' is not marked as serializable.


經過Google一番，總之就是新增定義Unity專用的序列方法，總之我把他解決了並且放在GitHub上。
