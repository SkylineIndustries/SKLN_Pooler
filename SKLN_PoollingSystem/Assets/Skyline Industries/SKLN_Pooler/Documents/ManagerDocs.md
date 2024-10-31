# Manager

The Manager is the main class that you will interact with when using the Pooler system. 
It is responsible for creating and managing pools of objects. The Manager is a singleton, 
meaning that there is only one instance of it in the scene. 
You can access the Manager instance by calling `Pooler.Manager.Instance`.


## Features
- Create and manage pools of objects
- Automatically spawn objects from pools
- Option to automatically expand pools when they are empty

## Allowed Types
The Pooler system allows you to create pools of any type of gameObject. 
However, the object must implement the `IPoolable` interface. 
This interface requires the object to have a `Reset` method that will be called when the object is spawned from the pool. 
This method should reset the object to its default state.


There is a base class that is provided with the Pooler system called `PoolableGameObject`. 
This class implements the `IPoolable` interface and provides a default implementation of the `Reset` method. 
This class allows you to easily create your own objects.