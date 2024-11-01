# SKLN Pool Manager
![GitHub](https://img.shields.io/github/license/SkylineIndustries/SKLN_Pooler)
![GitHub release (latest by date)](https://img.shields.io/github/v/release/SkylineIndustries/SKLN_Pooler)
![GitHub Release Date](https://img.shields.io/badge/Unity%20Version-2020.3.0f1-blue)
![GitHub Release Date](https://img.shields.io/badge/CSHARP%20Version-9.0-blue)

**SKLN Pool Manager** is a lightweight and flexible object pooling system designed for Unity. It allows developers to efficiently manage and reuse objects in their game, reducing the need for constant instantiation and destruction of GameObjects, which can improve performance significantly, especially in resource-intensive games.

## Key Features
- **Customizable Pools**: Define multiple pools with unique tags, initial sizes, and expandable options to meet different gameplay needs.
- **Expandable Pools**: Optionally enable pools to expand dynamically when objects run out, ensuring the gameplay experience remains uninterrupted.
- **Easy Integration**: Simple API to spawn objects by tag, position, and rotation, making it easy to incorporate into any project.
- **Debugging Support**: Includes logging to track issues with pool tags, missing components, and expandable pool operations.

## Getting Started
1. Create an empty GameObject in your scene and attach the `PoolManager` script to it.
2. Configure your pools in the inspector by setting the tag, prefab, initial size, and expandable options.
3. Use the PoolableObject component to mark objects that should be managed by the pool.

This package is ideal for developers looking to improve the performance of their Unity projects by minimizing runtime instantiation and leveraging reusable GameObjects.

## Roadmap

This project is currently in development, with the following features planned for future releases - 
see the [ROADMAP](ROADMAP.md) file for more details.

## License
This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgements
- [Unity](https://unity.com/) - The game engine that powers this project.


## Contact
For any questions, issues, or suggestions, please contact start a new issue on the GitHub repository.


## Author
- [Skyline Industries GameStudio - Team Skyline Groningen](https://github.com/SkylineIndustries/SKLN_Pooler)
