1. SCRIPTABLEOBJECT
ScriptableObject là một cách để lưu trữ và quản lý dữ liệu trong Unity mà không cần một thực thể GameObject cụ thể
A ScriptableObject is a data container that you can use to save large amounts of data, independent of class instances. 
One of the main use cases for ScriptableObjects is to reduce your Project’s memory usage by avoiding copies of values. 
This is useful if your Project has a Prefab that stores unchanging data in attached MonoBehaviour scripts
Every time you instantiate that Prefab, it will get its own copy of that data. 
Instead of using this method, and storing duplicated data, you can use a ScriptableObject to store the data and then access it by reference from all of the Prefabs
Just like MonoBehaviours, ScriptableObjects derive from the base Unity object but, unlike MonoBehaviours, you can not attach a ScriptableObject to a GameObject
Instead, you need to save them as Assets in your Project.
The main use cases for ScriptableObjects are:
	+ Saving and storing data during an Editor session
	+ Saving data as an Asset in your Project to use at run time
To use a ScriptableObject, create a script in your application’s Assets folder and make it inherit from the ScriptableObject class. 
You can use the CreateAssetMenu attribute to make it easy to create custom assets using your class
EXAMPLE:
	[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/SpawnManagerScriptableObject", order = 1)]
	public class SpawnManagerScriptableObject : ScriptableObject
	{
	}


2. SATEMACHINE
StateMachine (Máy trạng thái) trong Unity là một cách tổ chức và quản lý luồng điều khiển trong game. 
Nó giúp phân chia logic của game thành các trạng thái khác nhau và chuyển đổi giữa chúng dựa trên điều kiện nhất định
Dùng để:
Tổ chức Logic: Phân chia logic của game thành các phần nhỏ, dễ quản lý và duy trì. 
Mỗi trạng thái có thể chịu trách nhiệm cho một khía cạnh cụ thể của hành vi.

Dễ Mở Rộng: Dễ dàng thêm, xóa hoặc sửa đổi các trạng thái mà không ảnh hưởng đến các phần khác của hệ thống.

Tích hợp với Animator: Trong Unity, StateMachine thường được tích hợp với Animator, giúp điều khiển các trạng thái và chuyển đổi thông qua animation.

Quản lý Trạng Thái Đối Tượng: Cho phép quản lý trạng thái của đối tượng một cách hiệu quả, đồng thời giúp ích trong việc thực hiện hành vi động đặc biệt


3. ENUM
Trong Unity, enum (kiểu liệt kê) được sử dụng như trong ngôn ngữ lập trình C#. 
Enum là một cách để định nghĩa một tập hợp các giá trị hằng số có thể đặt tên, giúp làm cho mã nguồn trở nên rõ ràng và dễ hiểu hơn
	+ Định nghĩa các tùy chọn cho thuộc tính hoặc biến: Enum có thể được sử dụng để định nghĩa các tùy chọn cụ thể cho một thuộc tính hoặc biến. Ví dụ, bạn có thể sử dụng enum để đại diện cho các loại vật liệu, hướng, trạng thái, hoặc bất kỳ điều gì có thể được biểu diễn dưới dạng một số hữu hạn các giá trị cố định.
	Ex: 
	public enum MaterialType
	{
		Wood,
		Metal,
		Plastic
	}

	public class GameObjectProperties
	{
		public MaterialType material;
	}

	+ Quản lý trạng thái: Enum thường được sử dụng để định nghĩa các trạng thái khác nhau trong game hoặc ứng dụng. Ví dụ, bạn có thể sử dụng enum để đại diện cho các trạng thái của một nhân vật như "Đứng yên," "Di chuyển," và "Tấn công."
	Ex:
	public enum CharacterState
	{
		Idle,
		Moving,
		Attacking
	}

	public class Character
	{
		public CharacterState currentState;
	}

	+ Quản lý tùy chọn trong giao diện người dùng: Enum có thể được sử dụng để định nghĩa các lựa chọn trong giao diện người dùng, chẳng hạn như danh sách các loại vật phẩm, các loại kích thước, hoặc các loại đơn vị đo.
	Ex:
	public enum ItemType
    {
		Weapon,
		Armor,
		Potion
	}

	public class InventoryItem
	{
		public ItemType type;
	}
	+ Quản lý các trạng thái trò chơi: Enum có thể được sử dụng để định nghĩa các trạng thái của trò chơi, chẳng hạn như "Menu," "Chơi," "Pause," để giúp quản lý luồng điều khiển của trò chơi
	Ex:
	public enum GameState
	{
		Menu,
		Playing,
		Paused
	}

	public class GameManager
	{
		public GameState currentState;
	}



